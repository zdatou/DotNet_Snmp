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


static void xHTimeEntry_get_object_def(u8_t ident_len, s32_t *ident, struct obj_def *od)
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
    LWIP_DEBUGF(SNMP_MIB_DEBUG,("get_object_def private xHTimeEntry.%"U16_F".0\n",(u16_t)id));
    switch (id)
    {
      case 1:    /* xHTimeLocalIPInfo  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_WRITE;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OC_STR);
        od->v_len = // todo:  set the appropriate length eg. sizeof(char_buffer);
        break;
      case 2:    /* xHTimeLocalGWInfo  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_WRITE;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OC_STR);
        od->v_len = // todo:  set the appropriate length eg. sizeof(char_buffer);
        break;
      case 3:    /* xHTimeLocalNMInfo  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_WRITE;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OC_STR);
        od->v_len = // todo:  set the appropriate length eg. sizeof(char_buffer);
        break;
      case 4:    /* xHTimeNTPIPInfo  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_WRITE;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OC_STR);
        od->v_len = // todo:  set the appropriate length eg. sizeof(char_buffer);
        break;
      case 5:    /* xHTimeNTPGWInfo  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_WRITE;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OC_STR);
        od->v_len = // todo:  set the appropriate length eg. sizeof(char_buffer);
        break;
      case 6:    /* xHTimeNTPNMInfo  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_WRITE;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OC_STR);
        od->v_len = // todo:  set the appropriate length eg. sizeof(char_buffer);
        break;
      case 7:    /* xHTimeUTCTimeInfo  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_ONLY;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OC_STR);
        od->v_len = // todo:  set the appropriate length eg. sizeof(char_buffer);
        break;
      case 8:    /* xHTimePosInfo  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_ONLY;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OC_STR);
        od->v_len = // todo:  set the appropriate length eg. sizeof(char_buffer);
        break;
      case 9:    /* xHTimeTameStateInfo  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_ONLY;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OC_STR);
        od->v_len = // todo:  set the appropriate length eg. sizeof(char_buffer);
        break;
      case 10:    /* xHTimeTimeSourceInfo  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_WRITE;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OC_STR);
        od->v_len = // todo:  set the appropriate length eg. sizeof(char_buffer);
        break;
      case 11:    /* xHTimePtpModeInfo  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_WRITE;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OC_STR);
        od->v_len = // todo:  set the appropriate length eg. sizeof(char_buffer);
        break;
      case 12:    /* xHTimePtpStateInfo  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_ONLY;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OC_STR);
        od->v_len = // todo:  set the appropriate length eg. sizeof(char_buffer);
        break;
      case 13:    /* xHTimePtpTimeInfo  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_ONLY;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OC_STR);
        od->v_len = // todo:  set the appropriate length eg. sizeof(char_buffer);
        break;
      case 14:    /* xHTimeRemoteIpInfo  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_ONLY;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OC_STR);
        od->v_len = // todo:  set the appropriate length eg. sizeof(char_buffer);
        break;
      case 15:    /* xHTimePtpE1ModeInfo  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_WRITE;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OC_STR);
        od->v_len = // todo:  set the appropriate length eg. sizeof(char_buffer);
        break;
      case 16:    /* xHTimePtpE1StateInfo  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_ONLY;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OC_STR);
        od->v_len = // todo:  set the appropriate length eg. sizeof(char_buffer);
        break;
      case 17:    /* xHTimePtpE1TimeInfo  */
        od->instance = MIB_OBJECT_TAB;
        od->access = MIB_OBJECT_READ_ONLY;
        od->asn_type = (SNMP_ASN1_UNIV | SNMP_ASN1_PRIMIT | SNMP_ASN1_OC_STR);
        od->v_len = // todo:  set the appropriate length eg. sizeof(char_buffer);
        break;
      default:
        LWIP_DEBUGF(SNMP_MIB_DEBUG,("xHTimeEntry_get_object_def: no such object\n"));
        od->instance = MIB_OBJECT_NONE;
        break;
    };
  }
  else
  {
    LWIP_DEBUGF(SNMP_MIB_DEBUG,("private xHTimeEntry_get_object_def: no scalar\n"));
    od->instance = MIB_OBJECT_NONE;
  }
}

static void xHTimeEntry_get_value(struct obj_def *od, u16_t len, void *value)
{
  u8_t id;

  /* the index value can be found in: od->id_inst_ptr[1] */
  id = od->id_inst_ptr[0];
  switch (id)
  {
    case 1:    /* xHTimeLocalIPInfo  */
      ocstrncpy(value,(u8_t*)your_string_pointer,len);
      break;
    case 2:    /* xHTimeLocalGWInfo  */
      ocstrncpy(value,(u8_t*)your_string_pointer,len);
      break;
    case 3:    /* xHTimeLocalNMInfo  */
      ocstrncpy(value,(u8_t*)your_string_pointer,len);
      break;
    case 4:    /* xHTimeNTPIPInfo  */
      ocstrncpy(value,(u8_t*)your_string_pointer,len);
      break;
    case 5:    /* xHTimeNTPGWInfo  */
      ocstrncpy(value,(u8_t*)your_string_pointer,len);
      break;
    case 6:    /* xHTimeNTPNMInfo  */
      ocstrncpy(value,(u8_t*)your_string_pointer,len);
      break;
    case 7:    /* xHTimeUTCTimeInfo  */
      ocstrncpy(value,(u8_t*)your_string_pointer,len);
      break;
    case 8:    /* xHTimePosInfo  */
      ocstrncpy(value,(u8_t*)your_string_pointer,len);
      break;
    case 9:    /* xHTimeTameStateInfo  */
      ocstrncpy(value,(u8_t*)your_string_pointer,len);
      break;
    case 10:    /* xHTimeTimeSourceInfo  */
      ocstrncpy(value,(u8_t*)your_string_pointer,len);
      break;
    case 11:    /* xHTimePtpModeInfo  */
      ocstrncpy(value,(u8_t*)your_string_pointer,len);
      break;
    case 12:    /* xHTimePtpStateInfo  */
      ocstrncpy(value,(u8_t*)your_string_pointer,len);
      break;
    case 13:    /* xHTimePtpTimeInfo  */
      ocstrncpy(value,(u8_t*)your_string_pointer,len);
      break;
    case 14:    /* xHTimeRemoteIpInfo  */
      ocstrncpy(value,(u8_t*)your_string_pointer,len);
      break;
    case 15:    /* xHTimePtpE1ModeInfo  */
      ocstrncpy(value,(u8_t*)your_string_pointer,len);
      break;
    case 16:    /* xHTimePtpE1StateInfo  */
      ocstrncpy(value,(u8_t*)your_string_pointer,len);
      break;
    case 17:    /* xHTimePtpE1TimeInfo  */
      ocstrncpy(value,(u8_t*)your_string_pointer,len);
      break;
  };
}

static u8_t xHTimeEntry_set_test(struct obj_def *od, u16_t len, void *value)
{
  u8_t id, set_ok;

  /* the index value can be found in: od->id_inst_ptr[1] */
  set_ok = 0;
  id = od->id_inst_ptr[0];
  switch (id)
  {
    case 1:    /* xHTimeLocalIPInfo  */
  /* validate the value argument and set ok  */
      break;
    case 2:    /* xHTimeLocalGWInfo  */
  /* validate the value argument and set ok  */
      break;
    case 3:    /* xHTimeLocalNMInfo  */
  /* validate the value argument and set ok  */
      break;
    case 4:    /* xHTimeNTPIPInfo  */
  /* validate the value argument and set ok  */
      break;
    case 5:    /* xHTimeNTPGWInfo  */
  /* validate the value argument and set ok  */
      break;
    case 6:    /* xHTimeNTPNMInfo  */
  /* validate the value argument and set ok  */
      break;
    case 10:    /* xHTimeTimeSourceInfo  */
  /* validate the value argument and set ok  */
      break;
    case 11:    /* xHTimePtpModeInfo  */
  /* validate the value argument and set ok  */
      break;
    case 15:    /* xHTimePtpE1ModeInfo  */
  /* validate the value argument and set ok  */
      break;
  };
  return set_ok;
}

static void xHTimeEntry_set_value(struct obj_def *od, u16_t len, void *value)
{
  u8_t id;

  /* the index value can be found in: od->id_inst_ptr[1] */
  id = od->id_inst_ptr[0];
  switch (id)
  {
    case 1:    /* xHTimeLocalIPInfo  */
      ocstrncpy((u8_t*)your_string_pointer,value,len);
      break;
    case 2:    /* xHTimeLocalGWInfo  */
      ocstrncpy((u8_t*)your_string_pointer,value,len);
      break;
    case 3:    /* xHTimeLocalNMInfo  */
      ocstrncpy((u8_t*)your_string_pointer,value,len);
      break;
    case 4:    /* xHTimeNTPIPInfo  */
      ocstrncpy((u8_t*)your_string_pointer,value,len);
      break;
    case 5:    /* xHTimeNTPGWInfo  */
      ocstrncpy((u8_t*)your_string_pointer,value,len);
      break;
    case 6:    /* xHTimeNTPNMInfo  */
      ocstrncpy((u8_t*)your_string_pointer,value,len);
      break;
    case 10:    /* xHTimeTimeSourceInfo  */
      ocstrncpy((u8_t*)your_string_pointer,value,len);
      break;
    case 11:    /* xHTimePtpModeInfo  */
      ocstrncpy((u8_t*)your_string_pointer,value,len);
      break;
    case 15:    /* xHTimePtpE1ModeInfo  */
      ocstrncpy((u8_t*)your_string_pointer,value,len);
      break;
  };
}

struct mib_list_rootnode xHTimeEntry_root = {
  &xHTimeEntry_get_object_def,
  &xHTimeEntry_get_value,
  &xHTimeEntry_set_test,
  &xHTimeEntry_set_value,
  MIB_NODE_LR,
  0,
  NULL,
  NULL,  0,
};

/* xHTimeEntry  .1.3.6.1.4.1.22566.1.1    */
const s32_t xHTimeEntry_ids[17] = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
struct mib_node* const xHTimeEntry_nodes[17] = { 
  (struct mib_node* const)&xHTimeEntry_root,
  (struct mib_node* const)&xHTimeEntry_root,
  (struct mib_node* const)&xHTimeEntry_root,
  (struct mib_node* const)&xHTimeEntry_root,
  (struct mib_node* const)&xHTimeEntry_root,
  (struct mib_node* const)&xHTimeEntry_root,
  (struct mib_node* const)&xHTimeEntry_root,
  (struct mib_node* const)&xHTimeEntry_root,
  (struct mib_node* const)&xHTimeEntry_root,
  (struct mib_node* const)&xHTimeEntry_root,
  (struct mib_node* const)&xHTimeEntry_root,
  (struct mib_node* const)&xHTimeEntry_root,
  (struct mib_node* const)&xHTimeEntry_root,
  (struct mib_node* const)&xHTimeEntry_root,
  (struct mib_node* const)&xHTimeEntry_root,
  (struct mib_node* const)&xHTimeEntry_root,
  (struct mib_node* const)&xHTimeEntry_root
};

const struct mib_array_node xHTimeEntry = {
  &noleafs_get_object_def,
  &noleafs_get_value,
  &noleafs_set_test,
  &noleafs_set_value,
  MIB_NODE_AR,
  17,
  xHTimeEntry_ids,
  xHTimeEntry_nodes
};

/* xHTimeTable  .1.3.6.1.4.1.22566.1    */
s32_t xHTimeTable_ids[1] = { 1 };
struct mib_node* xHTimeTable_nodes[1] = { 
  (struct mib_node* const)&xHTimeEntry
};

struct mib_ram_array_node xHTimeTable = {
  &noleafs_get_object_def,
  &noleafs_get_value,
  &noleafs_set_test,
  &noleafs_set_value,
  MIB_NODE_RA,
  0,
  xHTimeTable_ids,
  xHTimeTable_nodes
};

/* xHTime  .1.3.6.1.4.1.22566    */
const s32_t xHTime_ids[1] = { 1 };
struct mib_node* const xHTime_nodes[1] = { 
  (struct mib_node* const)&xHTimeTable
};

const struct mib_array_node xHTime = {
  &noleafs_get_object_def,
  &noleafs_get_value,
  &noleafs_set_test,
  &noleafs_set_value,
  MIB_NODE_AR,
  1,
  xHTime_ids,
  xHTime_nodes
};

/* enterprises  .1.3.6.1.4.1    */
const s32_t enterprises_ids[1] = { 22566 };
struct mib_node* const enterprises_nodes[1] = { 
  (struct mib_node* const)&xHTime
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

