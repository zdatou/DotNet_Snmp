#include "private_mib.h"
#include "lwip/snmp.h"
#include "lwip/snmp_msg.h"
#include "lwip/snmp_asn1.h"
#include "lwip/snmp_structs.h"

/**
 * Initialises this private MIB before use.
 *
 */
void lwip_privmib_init(void);

void ocstrncpy(u8_t *dst, u8_t *src, u8_t n);
void objectidncpy(s32_t *dst, s32_t *src, u8_t n);


static void zkClassInfoEntry2_get_object_def(u8_t ident_len, s32_t *ident, struct obj_def *od)
{
  u8_t id;

  /* return to object name, adding index depth (1) */
  ident_len += 1;
  ident -= 1;
  if (ident_len == 2)
  {
    od->id_inst_len = ident_len;
    od->id_inst_ptr = ident;

    id = ident[0];
    LWIP_DEBUGF(SNMP_MIB_DEBUG,("get_object_def private zkClassInfoEntry2.%"U16_F".0\n",(u16_t)id));
    switch (id)
    {
      case 1:    /* zkClassInfoSex2  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_WRITE;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_INTEG);
        od->v_len = // todo:  set the appropriate length eg. sizeof(u32_t);
        break;
      default:
        LWIP_DEBUGF(SNMP_MIB_DEBUG,("zkClassInfoEntry2_get_object_def: no such object\n"));
        od->instance = MIB_OBJECT_NONE;
        break;
    };
  }
  else
  {
    LWIP_DEBUGF(SNMP_MIB_DEBUG,("private zkClassInfoEntry2_get_object_def: no scalar\n"));
    od->instance = MIB_OBJECT_NONE;
  }
}

static void zkClassInfoEntry2_get_value(struct obj_def *od, u16_t len, void *value)
{
  u8_t id;

  /* the index value can be found in: od->id_inst_ptr[1] */
  id = od->id_inst_ptr[0];
  switch (id)
  {
    case 1:    /* zkClassInfoSex2  */
      {
        s32_t *sint_ptr = value;
        *sint_ptr = ; /* todo: set appropriate value */
      }
      break;
  };
}

static u8_t zkClassInfoEntry2_set_test(struct obj_def *od, u16_t len, void *value)
{
  u8_t id, set_ok;

  /* the index value can be found in: od->id_inst_ptr[1] */
  set_ok = 0;
  id = od->id_inst_ptr[0];
  switch (id)
  {
    case 1:    /* zkClassInfoSex2  */
  /* validate the value argument and set ok  */
      break;
  };
  return set_ok;
}

static void zkClassInfoEntry2_set_value(struct obj_def *od, u16_t len, void *value)
{
  u8_t id;

  /* the index value can be found in: od->id_inst_ptr[1] */
  id = od->id_inst_ptr[0];
  switch (id)
  {
    case 1:    /* zkClassInfoSex2  */
      {
        s32_t *sint_ptr = value;
         = *sint_ptr;  /* do something with the value */
      }
      break;
  };
}

struct mib_list_rootnode zkClassInfoEntry2_root = {
  &zkClassInfoEntry2_get_object_def,
  &zkClassInfoEntry2_get_value,
  &zkClassInfoEntry2_set_test,
  &zkClassInfoEntry2_set_value,
  MIB_NODE_LR,
  0,
  NULL,
  NULL,  0,
};

/* zkClassInfoEntry2  .1.3.6.1.4.1.22566.2.1    */
const s32_t zkClassInfoEntry2_ids[1] = { 1 };
struct mib_node* const zkClassInfoEntry2_nodes[1] = { 
  (struct mib_node* const)&zkClassInfoEntry2_root
};

const struct mib_array_node zkClassInfoEntry2 = {
  &noleafs_get_object_def,
  &noleafs_get_value,
  &noleafs_set_test,
  &noleafs_set_value,
  MIB_NODE_AR,
  1,
  zkClassInfoEntry2_ids,
  zkClassInfoEntry2_nodes
};

/* zkClassInfoTable2  .1.3.6.1.4.1.22566.2    */
s32_t zkClassInfoTable2_ids[1] = { 1 };
struct mib_node* zkClassInfoTable2_nodes[1] = { 
  (struct mib_node* const)&zkClassInfoEntry2
};

struct mib_ram_array_node zkClassInfoTable2 = {
  &noleafs_get_object_def,
  &noleafs_get_value,
  &noleafs_set_test,
  &noleafs_set_value,
  MIB_NODE_RA,
  0,
  zkClassInfoTable2_ids,
  zkClassInfoTable2_nodes
};

static void zkClassInfoEntry_get_object_def(u8_t ident_len, s32_t *ident, struct obj_def *od)
{
  u8_t id;

  /* return to object name, adding index depth (1) */
  ident_len += 1;
  ident -= 1;
  if (ident_len == 2)
  {
    od->id_inst_len = ident_len;
    od->id_inst_ptr = ident;

    id = ident[0];
    LWIP_DEBUGF(SNMP_MIB_DEBUG,("get_object_def private zkClassInfoEntry.%"U16_F".0\n",(u16_t)id));
    switch (id)
    {
      case 1:    /* zkClassInfoIndex  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_WRITE;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_INTEG);
        od->v_len = // todo:  set the appropriate length eg. sizeof(u32_t);
        break;
      case 2:    /* zkClassInfoSex  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_WRITE;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_INTEG);
        od->v_len = // todo:  set the appropriate length eg. sizeof(u32_t);
        break;
      case 3:    /* zkClassInfoAge  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_WRITE;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_INTEG);
        od->v_len = // todo:  set the appropriate length eg. sizeof(u32_t);
        break;
      case 4:    /* zkCLassInfoName  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_WRITE;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OC_STR);
        od->v_len = // todo:  set the appropriate length eg. sizeof(char_buffer);
        break;
      case 5:    /* zkClassInfoAddress  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_WRITE;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OC_STR);
        od->v_len = // todo:  set the appropriate length eg. sizeof(char_buffer);
        break;
      default:
        LWIP_DEBUGF(SNMP_MIB_DEBUG,("zkClassInfoEntry_get_object_def: no such object\n"));
        od->instance = MIB_OBJECT_NONE;
        break;
    };
  }
  else
  {
    LWIP_DEBUGF(SNMP_MIB_DEBUG,("private zkClassInfoEntry_get_object_def: no scalar\n"));
    od->instance = MIB_OBJECT_NONE;
  }
}

static void zkClassInfoEntry_get_value(struct obj_def *od, u16_t len, void *value)
{
  u8_t id;

  /* the index value can be found in: od->id_inst_ptr[1] */
  id = od->id_inst_ptr[0];
  switch (id)
  {
    case 1:    /* zkClassInfoIndex  */
      {
        s32_t *sint_ptr = value;
        *sint_ptr = ; /* todo: set appropriate value */
      }
      break;
    case 2:    /* zkClassInfoSex  */
      {
        s32_t *sint_ptr = value;
        *sint_ptr = ; /* todo: set appropriate value */
      }
      break;
    case 3:    /* zkClassInfoAge  */
      {
        s32_t *sint_ptr = value;
        *sint_ptr = ; /* todo: set appropriate value */
      }
      break;
    case 4:    /* zkCLassInfoName  */
      ocstrncpy(value,(u8_t*)your_string_pointer,len);
      break;
    case 5:    /* zkClassInfoAddress  */
      ocstrncpy(value,(u8_t*)your_string_pointer,len);
      break;
  };
}

static u8_t zkClassInfoEntry_set_test(struct obj_def *od, u16_t len, void *value)
{
  u8_t id, set_ok;

  /* the index value can be found in: od->id_inst_ptr[1] */
  set_ok = 0;
  id = od->id_inst_ptr[0];
  switch (id)
  {
    case 1:    /* zkClassInfoIndex  */
  /* validate the value argument and set ok  */
      break;
    case 2:    /* zkClassInfoSex  */
  /* validate the value argument and set ok  */
      break;
    case 3:    /* zkClassInfoAge  */
  /* validate the value argument and set ok  */
      break;
    case 4:    /* zkCLassInfoName  */
  /* validate the value argument and set ok  */
      break;
    case 5:    /* zkClassInfoAddress  */
  /* validate the value argument and set ok  */
      break;
  };
  return set_ok;
}

static void zkClassInfoEntry_set_value(struct obj_def *od, u16_t len, void *value)
{
  u8_t id;

  /* the index value can be found in: od->id_inst_ptr[1] */
  id = od->id_inst_ptr[0];
  switch (id)
  {
    case 1:    /* zkClassInfoIndex  */
      {
        s32_t *sint_ptr = value;
         = *sint_ptr;  /* do something with the value */
      }
      break;
    case 2:    /* zkClassInfoSex  */
      {
        s32_t *sint_ptr = value;
         = *sint_ptr;  /* do something with the value */
      }
      break;
    case 3:    /* zkClassInfoAge  */
      {
        s32_t *sint_ptr = value;
         = *sint_ptr;  /* do something with the value */
      }
      break;
    case 4:    /* zkCLassInfoName  */
      ocstrncpy((u8_t*)your_string_pointer,value,len);
      break;
    case 5:    /* zkClassInfoAddress  */
      ocstrncpy((u8_t*)your_string_pointer,value,len);
      break;
  };
}

struct mib_list_rootnode zkClassInfoEntry_root = {
  &zkClassInfoEntry_get_object_def,
  &zkClassInfoEntry_get_value,
  &zkClassInfoEntry_set_test,
  &zkClassInfoEntry_set_value,
  MIB_NODE_LR,
  0,
  NULL,
  NULL,  0,
};

/* zkClassInfoEntry  .1.3.6.1.4.1.22566.1.1    */
const s32_t zkClassInfoEntry_ids[5] = { 1, 2, 3, 4, 5 };
struct mib_node* const zkClassInfoEntry_nodes[5] = { 
  (struct mib_node* const)&zkClassInfoEntry_root,
  (struct mib_node* const)&zkClassInfoEntry_root,
  (struct mib_node* const)&zkClassInfoEntry_root,
  (struct mib_node* const)&zkClassInfoEntry_root,
  (struct mib_node* const)&zkClassInfoEntry_root
};

const struct mib_array_node zkClassInfoEntry = {
  &noleafs_get_object_def,
  &noleafs_get_value,
  &noleafs_set_test,
  &noleafs_set_value,
  MIB_NODE_AR,
  5,
  zkClassInfoEntry_ids,
  zkClassInfoEntry_nodes
};

/* zkClassInfoTable  .1.3.6.1.4.1.22566.1    */
s32_t zkClassInfoTable_ids[1] = { 1 };
struct mib_node* zkClassInfoTable_nodes[1] = { 
  (struct mib_node* const)&zkClassInfoEntry
};

struct mib_ram_array_node zkClassInfoTable = {
  &noleafs_get_object_def,
  &noleafs_get_value,
  &noleafs_set_test,
  &noleafs_set_value,
  MIB_NODE_RA,
  0,
  zkClassInfoTable_ids,
  zkClassInfoTable_nodes
};

/* zkClassInfoTable2  .1.3.6.1.4.1.22566.2    */
const s32_t zkClassInfoTable2_ids[0] = {  };
struct mib_node* const zkClassInfoTable2_nodes[0] = { 

};

const struct mib_array_node zkClassInfoTable2 = {
  &noleafs_get_object_def,
  &noleafs_get_value,
  &noleafs_set_test,
  &noleafs_set_value,
  MIB_NODE_AR,
  0,
  zkClassInfoTable2_ids,
  zkClassInfoTable2_nodes
};

/* zkClassInfoTable  .1.3.6.1.4.1.22566.1    */
const s32_t zkClassInfoTable_ids[0] = {  };
struct mib_node* const zkClassInfoTable_nodes[0] = { 

};

const struct mib_array_node zkClassInfoTable = {
  &noleafs_get_object_def,
  &noleafs_get_value,
  &noleafs_set_test,
  &noleafs_set_value,
  MIB_NODE_AR,
  0,
  zkClassInfoTable_ids,
  zkClassInfoTable_nodes
};

/* xxx  .1.3.6.1.4.1.22566    */
const s32_t xxx_ids[4] = { 1, 2, 1, 2 };
struct mib_node* const xxx_nodes[4] = { 
  (struct mib_node* const)&zkClassInfoTable,
  (struct mib_node* const)&zkClassInfoTable2,
  (struct mib_node* const)&zkClassInfoTable,
  (struct mib_node* const)&zkClassInfoTable2
};

const struct mib_array_node xxx = {
  &noleafs_get_object_def,
  &noleafs_get_value,
  &noleafs_set_test,
  &noleafs_set_value,
  MIB_NODE_AR,
  4,
  xxx_ids,
  xxx_nodes
};

/* enterprises  .1.3.6.1.4.1    */
const s32_t enterprises_ids[1] = { 22566 };
struct mib_node* const enterprises_nodes[1] = { 
  (struct mib_node* const)&xxx
};

const struct mib_array_node enterprises = {
  &noleafs_get_object_def,
  &noleafs_get_value,
  &noleafs_set_test,
  &noleafs_set_value,
  MIB_NODE_AR,
  1,
  enterprises_ids,
  enterprises_nodes
};

/* private  .1.3.6.1.4    */
const s32_t private_ids[1] = { 1 };
struct mib_node* const private_nodes[1] = { 
  (struct mib_node* const)&enterprises
};

const struct mib_array_node private = {
  &noleafs_get_object_def,
  &noleafs_get_value,
  &noleafs_set_test,
  &noleafs_set_value,
  MIB_NODE_AR,
  1,
  private_ids,
  private_nodes
};

void
lwip_privmib_init(void)
{
}

