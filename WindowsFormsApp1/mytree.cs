using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Mytree
    {
        public System.Windows.Forms.TreeView treeView;
        public Mytree()
        {
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("directory");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("system");
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("interfaces");
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("at");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("ip");
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("icmp");
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("udp");
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("egp");
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("transmission");
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("snmp");
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("appletalk");
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("ospf");
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("host");
            System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode("mib2", new System.Windows.Forms.TreeNode[] {
            treeNode45,
            treeNode46,
            treeNode47,
            treeNode48,
            treeNode49,
            treeNode50,
            treeNode51,
            treeNode52,
            treeNode53,
            treeNode54,
            treeNode55,
            treeNode56});
            System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode("mgmt", new System.Windows.Forms.TreeNode[] {
            treeNode57});
            System.Windows.Forms.TreeNode treeNode59 = new System.Windows.Forms.TreeNode("experimental");
            System.Windows.Forms.TreeNode treeNode60 = new System.Windows.Forms.TreeNode("xHTimeLocalIPInfo");
            System.Windows.Forms.TreeNode treeNode61 = new System.Windows.Forms.TreeNode("xHTimeLocalGWInfo");
            System.Windows.Forms.TreeNode treeNode62 = new System.Windows.Forms.TreeNode("xHTimeLocalNMInfo");
            System.Windows.Forms.TreeNode treeNode63 = new System.Windows.Forms.TreeNode("xHTimeNTPIPInfo");
            System.Windows.Forms.TreeNode treeNode64 = new System.Windows.Forms.TreeNode("xHTimeNTPGWInfo");
            System.Windows.Forms.TreeNode treeNode65 = new System.Windows.Forms.TreeNode("xHTimeNTPNMInfo");
            System.Windows.Forms.TreeNode treeNode66 = new System.Windows.Forms.TreeNode("xHTimeUTCTimeInfo");
            System.Windows.Forms.TreeNode treeNode67 = new System.Windows.Forms.TreeNode("xHTimePosInfo");
            System.Windows.Forms.TreeNode treeNode68 = new System.Windows.Forms.TreeNode("xHTimeTameStateInfo");
            System.Windows.Forms.TreeNode treeNode69 = new System.Windows.Forms.TreeNode("xHTimeTimeSourceInfo");
            System.Windows.Forms.TreeNode treeNode70 = new System.Windows.Forms.TreeNode("xHTimePtpModeInfo");
            System.Windows.Forms.TreeNode treeNode71 = new System.Windows.Forms.TreeNode("xHTimePtpStateInfo");
            System.Windows.Forms.TreeNode treeNode72 = new System.Windows.Forms.TreeNode("xHTimePtpTimeInfo");
            System.Windows.Forms.TreeNode treeNode73 = new System.Windows.Forms.TreeNode("xHTimeRemoteIpInfo");
            System.Windows.Forms.TreeNode treeNode74 = new System.Windows.Forms.TreeNode("xHTimePtpE1ModeInfo");
            System.Windows.Forms.TreeNode treeNode75 = new System.Windows.Forms.TreeNode("xHTimePtpE1StateInfo");
            System.Windows.Forms.TreeNode treeNode76 = new System.Windows.Forms.TreeNode("xHTimePtpE1TimeInfo");
            System.Windows.Forms.TreeNode treeNode77 = new System.Windows.Forms.TreeNode("xHTimeEntry", new System.Windows.Forms.TreeNode[] {
            treeNode60,
            treeNode61,
            treeNode62,
            treeNode63,
            treeNode64,
            treeNode65,
            treeNode66,
            treeNode67,
            treeNode68,
            treeNode69,
            treeNode70,
            treeNode71,
            treeNode72,
            treeNode73,
            treeNode74,
            treeNode75,
            treeNode76});
            System.Windows.Forms.TreeNode treeNode78 = new System.Windows.Forms.TreeNode("xHTimeTable", new System.Windows.Forms.TreeNode[] {
            treeNode77});
            System.Windows.Forms.TreeNode treeNode79 = new System.Windows.Forms.TreeNode("xHTime", new System.Windows.Forms.TreeNode[] {
            treeNode78});
            System.Windows.Forms.TreeNode treeNode80 = new System.Windows.Forms.TreeNode("private", new System.Windows.Forms.TreeNode[] {
            treeNode79});
            System.Windows.Forms.TreeNode treeNode81 = new System.Windows.Forms.TreeNode("security");
            System.Windows.Forms.TreeNode treeNode82 = new System.Windows.Forms.TreeNode("snmpV2");
            System.Windows.Forms.TreeNode treeNode83 = new System.Windows.Forms.TreeNode("internet", new System.Windows.Forms.TreeNode[] {
            treeNode44,
            treeNode58,
            treeNode59,
            treeNode80,
            treeNode81,
            treeNode82});
            System.Windows.Forms.TreeNode treeNode84 = new System.Windows.Forms.TreeNode("dod", new System.Windows.Forms.TreeNode[] {
            treeNode83});
            System.Windows.Forms.TreeNode treeNode85 = new System.Windows.Forms.TreeNode("org", new System.Windows.Forms.TreeNode[] {
            treeNode84});
            System.Windows.Forms.TreeNode treeNode86 = new System.Windows.Forms.TreeNode("iso", new System.Windows.Forms.TreeNode[] {
            treeNode85});
            this.treeView = new System.Windows.Forms.TreeView();
            // 
            // treeView1
            // 
            this.treeView.Location = new System.Drawing.Point(12, 12);
            this.treeView.Name = "treeView1";
            treeNode44.Name = "directory";
            treeNode44.Text = "directory";
            treeNode45.Name = "system";
            treeNode45.Text = "system";
            treeNode46.Name = "interfaces";
            treeNode46.Text = "interfaces";
            treeNode47.Name = "at";
            treeNode47.Text = "at";
            treeNode48.Name = "ip";
            treeNode48.Text = "ip";
            treeNode49.Name = "icmp";
            treeNode49.Text = "icmp";
            treeNode50.Name = "tcp";
            treeNode50.Text = "udp";
            treeNode51.Name = "egp";
            treeNode51.Text = "egp";
            treeNode52.Name = "transmission";
            treeNode52.Text = "transmission";
            treeNode53.Name = "snmp";
            treeNode53.Text = "snmp";
            treeNode54.Name = "appletalk";
            treeNode54.Text = "appletalk";
            treeNode55.Name = "ospf";
            treeNode55.Text = "ospf";
            treeNode56.Name = "host";
            treeNode56.Text = "host";
            treeNode57.Name = "mib2";
            treeNode57.Text = "mib2";
            treeNode58.Name = "mgmt";
            treeNode58.Text = "mgmt";
            treeNode59.Name = "experimental";
            treeNode59.Text = "experimental";
            treeNode60.Name = "xHTimeLocalIPInfo";
            treeNode60.Text = "xHTimeLocalIPInfo";
            treeNode61.Name = "xHTimeLocalGWInfo";
            treeNode61.Text = "xHTimeLocalGWInfo";
            treeNode62.Name = "xHTimeLocalNMInfo";
            treeNode62.Text = "xHTimeLocalNMInfo";
            treeNode63.Name = "xHTimeNTPIPInfo";
            treeNode63.Text = "xHTimeNTPIPInfo";
            treeNode64.Name = "xHTimeNTPGWInfo";
            treeNode64.Text = "xHTimeNTPGWInfo";
            treeNode65.Name = "xHTimeNTPNMInfo";
            treeNode65.Text = "xHTimeNTPNMInfo";
            treeNode66.Name = "xHTimeUTCTimeInfo";
            treeNode66.Text = "xHTimeUTCTimeInfo";
            treeNode67.Name = "xHTimePosInfo";
            treeNode67.Text = "xHTimePosInfo";
            treeNode68.Name = "xHTimeTameStateInfo";
            treeNode68.Text = "xHTimeTameStateInfo";
            treeNode69.Name = "xHTimeTimeSourceInfo";
            treeNode69.Text = "xHTimeTimeSourceInfo";
            treeNode70.Name = "xHTimePtpModeInfo";
            treeNode70.Text = "xHTimePtpModeInfo";
            treeNode71.Name = "xHTimePtpStateInfo";
            treeNode71.Text = "xHTimePtpStateInfo";
            treeNode72.Name = "xHTimePtpTimeInfo";
            treeNode72.Text = "xHTimePtpTimeInfo";
            treeNode73.Name = "xHTimeRemoteIpInfo";
            treeNode73.Text = "xHTimeRemoteIpInfo";
            treeNode74.Name = "xHTimePtpE1ModeInfo";
            treeNode74.Text = "xHTimePtpE1ModeInfo";
            treeNode75.Name = "xHTimePtpE1StateInfo";
            treeNode75.Text = "xHTimePtpE1StateInfo";
            treeNode76.Name = "xHTimePtpE1TimeInfo";
            treeNode76.Text = "xHTimePtpE1TimeInfo";
            treeNode77.Name = "xHTimeEntry";
            treeNode77.Text = "xHTimeEntry";
            treeNode78.Name = "xHTimeTable";
            treeNode78.Text = "xHTimeTable";
            treeNode79.Name = "xHTime";
            treeNode79.Text = "xHTime";
            treeNode80.Name = "private";
            treeNode80.Text = "private";
            treeNode81.Name = "security";
            treeNode81.Text = "security";
            treeNode82.Name = "snmpV2";
            treeNode82.Text = "snmpV2";
            treeNode83.Name = "internet";
            treeNode83.Text = "internet";
            treeNode84.Name = "dod";
            treeNode84.Text = "dod";
            treeNode85.Name = "org";
            treeNode85.Text = "org";
            treeNode86.Name = "iso";
            treeNode86.Text = "iso";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode86});
            this.treeView.Size = new System.Drawing.Size(139, 191);
            this.treeView.TabIndex = 0;
        }
    }
}
