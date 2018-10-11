"""
Purpose:   MIB C code generator
Based on:  mib2.c (author Christiaan Simons) in lwIP-1.3.2
Copyright: James Harwood 2011
License:   You may freely use, modify, and distribute this software.
Warranty:  THIS SOFTWARE HAS NO WARRANTY WHATSOEVER. USE AT YOUR OWN RISK. 
Version:   $Id: MibGenerator.py 6 2011-04-28 23:24:57Z jharwood757 $

Notes: 

"""


import sys
import pprint


class MibGenerator:
    """
        Takes the node list, node dictionary, and the syntax dictionary, and
        uses them to generate the C source code file to implement a
        lwIP - SNMP private mib.
    """

    
    def __init__(self, nodelist, nodedict, syntaxdict, fname):
        """ Constructor for the MibGenerator class
            converts the input filename to the output filename
            opens the output file 
            writes some prelude code to the output file
        """
        self.node_list = nodelist
        self.node_dict = nodedict
        self.syntax_dict = syntaxdict
        
        self.out_fname = fname.split('.')[0]+".c"
        self.out_file = open(self.out_fname, 'w')
        
        self.out_file.write('#include "private_mib.h"\n')
        self.out_file.write('#include "lwip/snmp.h"\n')
        self.out_file.write('#include "lwip/snmp_msg.h"\n')
        self.out_file.write('#include "lwip/snmp_asn1.h"\n')
        self.out_file.write('#include "lwip/snmp_structs.h"\n\n')
        self.out_file.write('/**\n * Initialises this private MIB before use.\n *\n */\n')
        self.out_file.write('void lwip_privmib_init(void);\n\n')
        self.out_file.write('void ocstrncpy(u8_t *dst, u8_t *src, u8_t n);\n')
        self.out_file.write('void objectidncpy(s32_t *dst, s32_t *src, u8_t n);\n\n\n')
        
    def testReadOnlyNode(self, node):
        """ tests whether all the kids of a node are read only """
        ro = True
        for kid in node['kids']:
            kid_node = self.node_dict[kid[0]]
            if(not 'read-only' == kid_node['access']):
                ro = False
                break
        return ro
    
    def genGetObjDef(self, f, node):
        """ generates the body of the xxx_get_object_def function
            for the given node
        """
        f.write('  u8_t id;\n\n')
    
        f.write('  /* return to object name, adding index depth (1) */\n')
        f.write('  ident_len += 1;\n')
        f.write('  ident -= 1;\n')
        f.write('  if (ident_len == 2)\n  {\n')
        f.write('    od->id_inst_len = ident_len;\n')
        f.write('    od->id_inst_ptr = ident;\n\n')
    
        f.write('    id = ident[0];\n')
        f.write('    LWIP_DEBUGF(SNMP_MIB_DEBUG,("get_object_def private ')
        f.write(node['name'])
        f.write('.%"U16_F".0\\n",(u16_t)id));\n')
        f.write('    switch (id)\n')
        f.write('    {\n')
        
        for kid in node['kids']:
            kid_node = self.node_dict[kid[0]]
            if('sequenceof' == kid_node['syntax']):
                continue
            f.write('      case ')
            f.write(kid[2])   # kid's subId
            f.write(':    /* ')
            f.write(kid[0])   # kid's name
            f.write('  */\n')
            
            f.write('        od->instance = ')
            if('entry' == node['type']):
                f.write('MIB_OBJECT_TAB;\n')
            else:
                f.write('MIB_OBJECT_SCALAR;\n')
            f.write('        od->access = ')
            if('read-only' == kid_node['access']):
                f.write('MIB_OBJECT_READ_ONLY;\n')
            else:
                f.write('MIB_OBJECT_READ_WRITE;\n')
                
            f.write('        od->asn_type = ')
            f.write(self.syntax_dict[kid_node['syntax'].lower()])
            f.write(';\n')
            if('integer' == kid_node['syntax'].lower() or \
                'integer32' == kid_node['syntax'].lower() or \
                'counter' == kid_node['syntax'].lower() or \
                'guage' == kid_node['syntax'].lower() or \
                'timeticks' == kid_node['syntax']):
                f.write('        od->v_len = // todo:  set the appropriate length eg. sizeof(u32_t);\n')
            if('displaystring' == kid_node['syntax'].lower() or \
                'octet' == kid_node['syntax'].lower()):
                f.write('        od->v_len = // todo:  set the appropriate length eg. sizeof(char_buffer);\n')
            if('object' == kid_node['syntax'].lower()): 
                f.write('        od->v_len = // todo:  set the appropriate length eg. MY_OID_LEN;\n')
            
            f.write('        break;\n')
            
        f.write('      default:\n')
        f.write('        LWIP_DEBUGF(SNMP_MIB_DEBUG,("')
        f.write(node['name'])
        f.write('_get_object_def: no such object\\n"));\n')
        f.write('        od->instance = MIB_OBJECT_NONE;\n')
        f.write('        break;\n')
            
        f.write('    };\n')
        
        f.write('  }\n')
        f.write('  else\n')
        f.write('  {\n')
        f.write('    LWIP_DEBUGF(SNMP_MIB_DEBUG,("private ')
        f.write(node['name'])
        f.write('_get_object_def: no scalar\\n"));\n')
        f.write('    od->instance = MIB_OBJECT_NONE;\n')
        f.write('  }\n')
    
    
    def genGetValue(self, f, node):
        """ generates the body of the xxx_get_value function
            for the given node
        """
        f.write('  u8_t id;\n\n')
        
        if('entry' == node['type']):
            f.write('  /* the index value can be found in: od->id_inst_ptr[1] */\n')
    
        f.write('  id = od->id_inst_ptr[0];\n')
        f.write('  switch (id)\n')
        f.write('  {\n')
        
        for kid in node['kids']:
            kid_node = self.node_dict[kid[0]]
            if('sequenceof' == kid_node['syntax'].lower()):
                continue
            f.write('    case ')
            f.write(kid[2])   # kid's subId
            f.write(':    /* ')
            f.write(kid[0])   # kid's name
            f.write('  */\n')
            if('integer' == kid_node['syntax'].lower() or \
                'integer32' == kid_node['syntax'].lower() or \
                'counter' == kid_node['syntax'].lower() or \
                'guage' == kid_node['syntax'].lower() or \
                'timeticks' == kid_node['syntax'].lower()):
                f.write('      {\n')
                f.write('        s32_t *sint_ptr = value;\n')
                f.write('        *sint_ptr = ; /* todo: set appropriate value */\n')
                f.write('      }\n')
            if('displaystring' == kid_node['syntax'].lower() or \
                'octet' == kid_node['syntax'].lower()):
                f.write('      ocstrncpy(value,(u8_t*)your_string_pointer,len);\n')
            if('object' == kid_node['syntax'].lower()): 
                f.write('      objectidncpy(value,(u32_t*)your_oid_pointer,len);\n')
            f.write('      break;\n')
        f.write('  };\n')
    
    def genSetTest(self, f, node):
        """ generates the body of the xxx_set_test function
            for the given node
        """
        f.write('  u8_t id, set_ok;\n\n')
        
        if('entry' == node['type']):
            f.write('  /* the index value can be found in: od->id_inst_ptr[1] */\n')
    
        f.write('  set_ok = 0;\n')
        f.write('  id = od->id_inst_ptr[0];\n')
        f.write('  switch (id)\n')
        f.write('  {\n')
        
        for kid in node['kids']:
            kid_node = self.node_dict[kid[0]]
            if('sequenceof' == kid_node['syntax'].lower()):
                continue
            if('read-only' == kid_node['access'].lower()):
                continue
            f.write('    case ')
            f.write(kid[2])   # kid's subId
            f.write(':    /* ')
            f.write(kid[0])   # kid's name
            f.write('  */\n')
            f.write('  /* validate the value argument and set ok  */\n')
            
            f.write('      break;\n')
        f.write('  };\n')
        f.write('  return set_ok;\n')
    
    def genSetValue(self, f, node):
        """ generates the body of the xxx_set_value function
            for the given node
        """
        f.write('  u8_t id;\n\n')
        
        if('entry' == node['type']):
            f.write('  /* the index value can be found in: od->id_inst_ptr[1] */\n')
    
        f.write('  id = od->id_inst_ptr[0];\n')
        f.write('  switch (id)\n')
        f.write('  {\n')
        
        for kid in node['kids']:
            kid_node = self.node_dict[kid[0]]
            if('sequenceof' == kid_node['syntax'].lower()):
                continue
            if('read-only' == kid_node['access'].lower()):
                continue
            f.write('    case ')
            f.write(kid[2])   # kid's subId
            f.write(':    /* ')
            f.write(kid[0])   # kid's name
            f.write('  */\n')
            if('integer' == kid_node['syntax'].lower() or \
                'integer32' == kid_node['syntax'].lower() or \
                'counter' == kid_node['syntax'].lower() or \
                'guage' == kid_node['syntax'].lower() or \
                'timeticks' == kid_node['syntax'].lower()):
                f.write('      {\n')
                f.write('        s32_t *sint_ptr = value;\n')
                f.write('         = *sint_ptr;  /* do something with the value */\n')
                f.write('      }\n')
            if('displaystring' == kid_node['syntax'].lower() or \
                'octet' == kid_node['syntax'].lower()):
                f.write('      ocstrncpy((u8_t*)your_string_pointer,value,len);\n')
            if('object' == kid_node['syntax'].lower()): 
                f.write('      objectidncpy((u32_t*)your_oid_pointer,value,len);\n')
            
            f.write('      break;\n')
        f.write('  };\n')

    
    def generateInst(self, f, node):
        """ generate the instrumentation functions for the given node
            xxx_get_object_def
            xxx_get_value
            xxx_set_test    }
            xxx_set_value   } only if at least one of the kids is read-write
        """
        f.write('static void ')
        f.write(node['name'])
        f.write('_get_object_def(u8_t ident_len, s32_t *ident, struct obj_def *od)\n{\n')
        self.genGetObjDef(f, node)
        f.write('}\n\n')
            
        f.write('static void ')
        f.write(node['name'])
        f.write('_get_value(struct obj_def *od, u16_t len, void *value)\n{\n')
        self.genGetValue(f, node)
        f.write('}\n\n')
        
        if not (self.testReadOnlyNode(node)):
            f.write('static u8_t ')
            f.write(node['name'])
            f.write('_set_test(struct obj_def *od, u16_t len, void *value)\n{\n')
            self.genSetTest(f, node)
            f.write('}\n\n')
            
            f.write('static void ')
            f.write(node['name'])
            f.write('_set_value(struct obj_def *od, u16_t len, void *value)\n{\n')
            self.genSetValue(f, node)
            f.write('}\n\n')
        
    def generateLeafs(self, file, node):
        """ generates the instrumentation functions for the given
            node, then either a scalar node declaration, or a
            list root node declaration, depending on type
        """
        self.generateInst(file, node)
        if('ident' == node['type']):
            file.write('const mib_scalar_node ')
            file.write(node['name'])
            file.write('_scalar = {\n')
            file.write('  &')
            file.write(node['name'])
            file.write('_get_object_def,\n')
            file.write('  &')
            file.write(node['name'])
            file.write('_get_value,\n')
            if not(self.testReadOnlyNode(node)):
                file.write('  &')
                file.write(node['name'])
                file.write('_set_test,\n')
                file.write('  &')
                file.write(node['name'])
                file.write('_set_value,\n')
            else:
                file.write('  &noleafs_set_test,\n')
                file.write('  &noleafs_set_value,\n')
            file.write('  MIB_NODE_SC,\n  0\n};\n\n')
            
        if('entry' == node['type']):
            file.write('struct mib_list_rootnode ')
            file.write(node['name'])
            file.write('_root = {\n')
            file.write('  &')
            file.write(node['name'])
            file.write('_get_object_def,\n')
            file.write('  &')
            file.write(node['name'])
            file.write('_get_value,\n')
            if not(self.testReadOnlyNode(node)):
                file.write('  &')
                file.write(node['name'])
                file.write('_set_test,\n')
                file.write('  &')
                file.write(node['name'])
                file.write('_set_value,\n')
            else:
                file.write('  &noleafs_set_test,\n')
                file.write('  &noleafs_set_value,\n')
            file.write('  MIB_NODE_LR,\n  0,\n  NULL,\n  NULL,  0,\n};\n\n')
            
            
        
    
    def generateOID(self, oid, node):
        """ recursive function to build a node's
            oid. adds its own subid first then its
            parent's and so on up to the root node.
            the resulting list should then be reversed
        """
        oid.append(node['subId'])
        if node['parent'] in self.node_dict:
            parent = self.node_dict[node['parent']]
            self.generateOID(oid, parent)
    
    def generateNode(self, file, node):
        """ generates a mib node structure declaration
            along with arrays of its sub node ids
        """
        
        # provide a comment showing the oid of this node 
        file.write('/* ')
        file.write(node['name'])
        file.write('  .1.3.6.1')
        oid = []
        self.generateOID(oid, node)
        oid.reverse()
        for num in oid:
            file.write('.{0}'.format(num))
        file.write('    */\n')
        #end of comment
        
        if('table' == node['type']):
            file.write('s32_t ')
        else:
            file.write('const s32_t ')
            
        # sub ids array
        file.write(node['name'])
        file.write('_ids[')
        kids = node['kids']
        file.write('{0}'.format(len(kids)))
        file.write('] = { ')
        i = 0
        for kid in kids:
            if(i > 0):
                file.write(', ')
            file.write(kid[2])   # kid's subId
            i += 1
        file.write(' };\n')
        
        # sub nodes array
        if('table' == node['type']):
            file.write('struct mib_node* ')
        else:
            file.write('struct mib_node* const ')
        file.write(node['name'])
        file.write('_nodes[')
        file.write('{0}'.format(len(kids)))
        file.write('] = { \n')
        i = 0
        for kid in kids:
            if(i > 0):
                file.write(',\n')
            file.write('  (struct mib_node* const)&')
            if('object' == kid[1]):
                file.write(node['name'])
                if('ident' == node['type']):
                    file.write('_scalar')
                if('entry' == node['type']):
                    file.write('_root')
            else:
                file.write(kid[0])   # kid's name
            i += 1
        
        file.write('\n};\n\n')
        
        # the node's mib node structure
        if('table' == node['type']):
            file.write('struct mib_ram_array_node ')
            file.write(node['name'])
            file.write(' = {\n')
            file.write('  &noleafs_get_object_def,\n')
            file.write('  &noleafs_get_value,\n')
            file.write('  &noleafs_set_test,\n')
            file.write('  &noleafs_set_value,\n')
            file.write('  MIB_NODE_RA,\n  ')
            file.write('0,\n  ')
            file.write(node['name'])
            file.write('_ids,\n  ')
            file.write(node['name'])
            file.write('_nodes\n')
            file.write('};\n\n')
        else:
            file.write('const struct mib_array_node ')
            file.write(node['name'])
            file.write(' = {\n')
            file.write('  &noleafs_get_object_def,\n')
            file.write('  &noleafs_get_value,\n')
            file.write('  &noleafs_set_test,\n')
            file.write('  &noleafs_set_value,\n')
            file.write('  MIB_NODE_AR,\n  ')
            file.write('{0},\n  '.format(len(kids)))
            file.write(node['name'])
            file.write('_ids,\n  ')
            file.write(node['name'])
            file.write('_nodes\n')
            file.write('};\n\n')
        
        
        
    def processNodeList(self):
        """ process each mib node in the list
            starting from lowest leaves and working
            backwards to the root node - 'private'
        """
        #print "node_list = "
        for node in self.node_list:
            #pprint.pprint( node )
            type = node['type']
            if('ident' == type or 'entry' == type or 'table' == type):
                hasLeafs = False
                for kid in node['kids']:
                    if('object' == kid[1]):  # kid's type
                        hasLeafs = True
                        break
                if( hasLeafs ):
                    self.generateLeafs(self.out_file, node)
                self.generateNode(self.out_file, node)
                
        self.out_file.write('void\nlwip_privmib_init(void)\n{\n}\n\n')
        self.out_file.close()
        print
        print ("Generation of source code file "+self.out_fname+" complete.")
        print ("Please check source code carefully for any errors.")
