"""
Purpose:      SNMP MIB Parser
Based on:     idlParse.py example (author Paul McGuire) in pyparsing-1.5.5
Dependencies: pyparsing-1.5.5 module
Copyright:    James Harwood 2011
License:      You may freely use, modify, and distribute this software.
Warranty:     THIS SOFTWARE HAS NO WARRANTY WHATSOEVER. USE AT YOUR OWN RISK.
Version:      $Id: MibParser.py 5 2011-04-28 23:06:46Z jharwood757 $
 
Notes: 
        ** The current version cannot handle Textual Convention statements **
        Sorry, you'll have to comment them out.
        I hope to fix this soon. 

"""
from pyparsing import *
import sys
import pprint
from MibGenerator import MibGenerator
import json

node_list = None
node_dict = None
syntax_dict = None

def NodeDict():
    global node_dict
    
    if not node_dict:
        node_dict = {}
    return node_dict
    
def NodeList():
    global node_list
    
    if not node_list:
        node_list = []
    return node_list

def SyntaxDict():
    global syntax_dict
    if not syntax_dict:    
        asn1_int         = '(SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_INTEG)'
        asn1_octstr      = '(SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OC_STR)'
        asn1_objid       = '(SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OBJ_ID)'
        asn1_gauge       = '(SNMP_ASN1_APPLIC | SNMP_ASN1_PRIMIT | SNMP_ASN1_GAUGE)'
        asn1_counter     = '(SNMP_ASN1_APPLIC | SNMP_ASN1_PRIMIT | SNMP_ASN1_COUNTER)'
        asn1_tmticks     = '(SNMP_ASN1_APPLIC | SNMP_ASN1_PRIMIT | SNMP_ASN1_TIMETICKS)'
        asn1_ipaddress   = '(SNMP_ASN1_APPLIC | SNMP_ASN1_PRIMIT | SNMP_ASN1_IPADDR)'
        
        # add other syntax types here
        syntax_dict = { 'integer':asn1_int, 'integer32':asn1_int, \
                        'octet':asn1_octstr, 'displaystring':asn1_octstr, \
                        'object':asn1_objid, 'timeticks':asn1_tmticks, \
                        'gauge':asn1_gauge, 'counter':asn1_counter, \
                        'gauge32':asn1_gauge, 'counter32':asn1_counter, \
                        'ipaddress':asn1_ipaddress, 'physaddress':asn1_octstr, \
                        'networkaddress':asn1_ipaddress
                        }
    return syntax_dict

def addNode( node ):
    node_list = NodeList()
    node_dict = NodeDict()
    node_list.append(node)
    node["kids"] = []
    node_dict[node["name"]] = node
    parent = node_dict[node["parent"]]
    kid = (node["name"], node["type"], node["subId"])
    parent["kids"].append(kid)

def objectTypeAction( toks ):
    node = toks.asDict()
    syntax_dict = SyntaxDict()
    node["type"] = "object"
    # smooth out the syntax processing
    # for table and entry objects
    if( not isinstance( node['syntax'], str)):
        node['syntax'] = 'sequenceof'
        node["type"] = "table"
    else:
        if( not (node['syntax'].lower() in syntax_dict)):
            print("syntax not found: "+node['syntax']+" - treating as entry")
            node["type"] = "entry"
    addNode(node)

def objectIdentifierAction(toks):
    node = toks.asDict()
    node["type"] = "ident"
    addNode(node)
    
def identityAction(toks):
    node = toks.asDict()
    node["type"] = "ident"
    addNode(node)
    
bnf = None
def SMI_BNF():
    global bnf
    
    if not bnf:

        # punctuation
        colon  = Literal(":")
        lbrace = Literal("{")
        rbrace = Literal("}")
        lbrack = Literal("[")
        rbrack = Literal("]")
        lparen = Literal("(")
        rparen = Literal(")")
        equals = Literal("=")
        comma  = Literal(",")
        dot    = Literal(".")
        slash  = Literal("/")
        bslash = Literal("\\")
        star   = Literal("*")
        semi   = Literal(";")
        langle = Literal("<")
        rangle = Literal(">")
        
        # keywords
        assign_       = Keyword("::=")
        define_       = Keyword("DEFINITIONS")
        begin_        = Keyword("BEGIN")
        end_          = Keyword("END")
        imports_      = Keyword("IMPORTS")
        from_         = Keyword("FROM")
        identity_     = Keyword("MODULE-IDENTITY")
        updated_      = Keyword("LAST-UPDATED")
        org_          = Keyword("ORGANIZATION")
        contact_      = Keyword("CONTACT-INFO")
        descr_        = Keyword("DESCRIPTION")
        object_       = Keyword("OBJECT")
        identifier_   = Keyword("IDENTIFIER")
        octet_        = Keyword("OCTET")
        string_       = Keyword("STRING")
        obj_type_     = Keyword("OBJECT-TYPE")
        syntax_       = Keyword("SYNTAX")
        access_       = Keyword("ACCESS")
        max_access_   = Keyword("MAX-ACCESS")
        status_       = Keyword("STATUS")
        index_        = Keyword("INDEX")
        sequence_     = Keyword("SEQUENCE")
        of_           = Keyword("OF")
        size_         = Keyword("SIZE")
        
        
        identifier = Word( alphas + "-", alphanums + "-" ).setName("identifier")
        text = QuotedString('"', multiline=True)
        subId = Word(nums)
        
        importsList = delimitedList(identifier)
        importsItem = importsList + from_ + identifier
        importsDef = imports_ + ZeroOrMore( importsItem ) + semi
        
        assignment = (lbrace + identifier.setResultsName("parent") + subId.setResultsName("subId") + rbrace)
        
        updated = (updated_ + text).suppress()
        org = (org_ + text).suppress()
        contact = (contact_ + text).suppress()
        descr = (descr_ + text).suppress()
        identityBody = updated + org + contact + descr
        identityDef = (identifier.setResultsName("name") + identity_ + identityBody + assign_ + assignment).setParseAction(identityAction)
        
        objectIdentifier = Forward().setParseAction(objectIdentifierAction)
        objectIdentifier << identifier.setResultsName("name") + object_ + identifier_ + assign_ + assignment
        
        bounds = QuotedString('(', endQuoteChar=')').setName("bounds")
        sizeDef = Word("(", max=1) + size_ + bounds + Word(")", max=1)
        syntaxEnum = QuotedString('{', multiline=True, endQuoteChar='}').setName("syntaxEnum")
        
        syntaxOpts = (syntaxEnum | sizeDef | bounds).setName("syntaxOpts")  
        
        integer = identifier + (Optional(syntaxOpts))
        
        sequenceOf = Group(sequence_ + of_ + identifier)
        synObjId = (object_ + identifier_)
        synOctetString = (octet_ + string_)
        syntax = (syntax_ + (synObjId | synOctetString | sequenceOf | integer).setResultsName("syntax"))
        access = ((max_access_ | access_) + identifier.setResultsName("access"))
        status = status_ + identifier
        indexDef = index_ + QuotedString('{', multiline=True, endQuoteChar='}')
        objectBody = (syntax + access + status + Optional(descr) + Optional(indexDef))
        objectType = (identifier.setResultsName("name") + obj_type_ + objectBody + assign_ + assignment).setParseAction(objectTypeAction)
        sequenceItem = identifier + identifier
        sequenceDef = (identifier + assign_ + sequence_ + QuotedString('{', multiline=True, endQuoteChar='}'))
        
        # textualConv = (lineStart + identifier + White() + assign_ + White() + OneOrMore(Word(alphas)+White(' \t')) + lineEnd).leaveWhitespace().setDebug()
        moduleItem = (importsDef | identityDef | objectIdentifier | objectType | sequenceDef)
        
        moduleDef = identifier + define_ + assign_ + begin_ + ZeroOrMore( moduleItem ) + end_
        
        bnf = ( moduleDef )

        singleLineComment = "--" + restOfLine
        bnf.ignore( singleLineComment )
        
    return bnf


def parse( fname ):
    node_list = NodeList()
    
    private = {'subId':4, 'type':'ident', 'name':'private', 'parent':'.1.3.6.1', 'kids':[('enterprises', 'ident', '1')]}
    enterprises = {'subId':1, 'type':'ident', 'name':'enterprises', 'parent':'private', 'kids':[]}
    node_dict = NodeDict()
    syntax_dict = SyntaxDict()
    node_dict["private"] = private
    node_dict["enterprises"] = enterprises
    node_list.append(private)
    node_list.append(enterprises)
    
    try:
        bnf = SMI_BNF()
        tokens = bnf.parseFile( fname )
        node_list.reverse()
        print("Parsing of "+fname+" complete.")        
        #pprint.pprint(node_dict)
        #pprint.pprint(json_dict)
        myfile = open('./test.txt', 'w')       
        # for obj in node_dict:
        #     temp_node = {}
        #     temp_node[obj] = node_dict[obj]
        #     myfile.write(json.dumps(temp_node))     
        myfile.write(json.dumps(node_list))
        myfile.close()
        print('*****************************************************\n*****************************************************')
        #pprint.pprint(node_list)
        #gen = MibGenerator(node_list, node_dict, syntax_dict, fname)
        #gen.processNodeList()        
    except ParseException as err:
        print(err.line)
        print(" "*(err.column-1) + "^")
        print(err)
    except IOError as err:
        print("could not open input mib file "+fname)
    print
    
    

if __name__ == "__main__":
    args = sys.argv[1:]
    if len(args) != 1:
        print("usage: mibparser.py <mib-file>")
    else:
        parse(args[0])
        
