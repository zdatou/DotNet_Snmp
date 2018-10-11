using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using SnmpSharpNet;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        char lastCharIP = '\0';
        char lastCharOID = '\0';


        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cbbMethod.SelectedIndex = 0;
            TreeViewInit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string IPText = this.cbbIP.Text;
            string OIDText = this.cbbOID.Text;
            string re = @"(?=(\b|\D))(((\d{1,2})|(1\d{1,2})|(2[0-4]\d)|(25[0-5]))\.){3}((\d{1,2})|(1\d{1,2})|(2[0-4]\d)|(25[0-5]))(?=(\b|\D))";

            if (false == Regex.IsMatch(IPText, re))
            {
                MessageBox.Show("IP地址格式不对！！！");
                this.cbbIP.Focus();
                return;
            }
            if (false == this.cbbIP.Items.Contains(IPText))
            {
                this.cbbIP.Items.Add(IPText);
            }
            if (false == this.cbbOID.Items.Contains(OIDText))
            {
                this.cbbOID.Items.Add(OIDText);
            }

            if(this.cbbMethod.SelectedIndex == 0) //Get
            {
                Snmp_Get(IPText, OIDText, "public");
            }
            else //Set
            {
                Snmp_Set(IPText, OIDText, "public");
            }

        }

        private void Snmp_Set(string ip, string oid, string comm)
        {
            Form3 form3 = new Form3
            {
                Name = "Set",
                OID = oid,
                IP  = ip,
                comm = comm
            };
            form3.ShowDialog();
        }

        private void Snmp_Get(string ip, string oid, string comm)
        {
            OctetString community = new OctetString(comm);
            AgentParameters param = new AgentParameters(community);
            param.Version = SnmpVersion.Ver1;
            IpAddress agent = new IpAddress(ip);
            UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);
            Pdu pdu = new Pdu(PduType.Get);
            pdu.VbList.Add(oid);
            SnmpV1Packet result = (SnmpV1Packet)target.Request(pdu, param);

            if (result != null)
            {
                if (result.Pdu.ErrorStatus != 0)
                {
                    this.txtTest.Text += string.Format("Error in SNMP reply. Error {0} index {1} \r\n", result.Pdu.ErrorStatus, result.Pdu.ErrorIndex);
                }
                else
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells[0].Value = "hello";
                    this.dataGridView1.Rows[index].Cells[1].Value = result.Pdu.VbList[0].Oid.ToString();
                    this.dataGridView1.Rows[index].Cells[2].Value = SnmpConstants.GetTypeName(result.Pdu.VbList[0].Value.Type);
                    this.dataGridView1.Rows[index].Cells[3].Value = result.Pdu.VbList[0].Value.ToString();
                }
            }
        }

        private void btnGo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;   //抗锯齿
            Brush brush = new SolidBrush(Color.Blue);
            Point p1 = new Point(8, 1);
            Point p2 = new Point(8, this.btnGo.Height - 1);
            Point p3 = new Point(this.btnGo.Width - 5, this.btnGo.Height / 2);
            g.FillPolygon(brush, new Point[] { p1, p2, p3 }); //填充三角形     
        }

        private void cbbIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //排除输入的值为非数字和非小数点以及连续输入小数点
            if (((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == '.') || (e.KeyChar == '\b')) && !((lastCharIP == '.') && (e.KeyChar == '.')))
            {
                lastCharIP = e.KeyChar;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cbbOID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //排除输入的值为非数字和非小数点以及连续输入小数点
            if (((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == '.') || (e.KeyChar == '\b')) && !((lastCharOID == '.') && (e.KeyChar == '.')))
            {
                lastCharOID = e.KeyChar;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ((TreeView)sender).ContextMenuStrip.Items[0].Enabled = true; //激活右键菜单中的指定项
            ((TreeView)sender).ContextMenuStrip.Items[1].Enabled = true; //激活右键菜单中的指定项
            ((TreeView)sender).ContextMenuStrip.Items[3].Enabled = true; //激活右键菜单中的指定项
            if (e.Node.Parent != null && e.Node.Nodes.Count == 0)        //只处理最后一层节点的右键动作
            {
                string fullpath = e.Node.FullPath;                       //得到当前点击节点的路径
                string[] paths = fullpath.Split(new char[] { '\\' });   //以‘\’分隔路径得到从根路径开始的子路径
                TreeNode node = ((TreeView)sender).Nodes[0];     //得到根节点
                string OID = "1";          //OID 从1开始   根节点对应1
                for (int i = 1; i < paths.Length; i++) //开始遍历子路径 逐步得到完整的OID
                {
                    node = node.Nodes.Find(paths[i], false)[0]; //开始搜索子路径， 第二个参数用来设置是否递归搜索全部的子节点  false表示只搜索下一层节点                  
                    OID += "." + (node.Index + 1);   //逐步得到OID  节点的index代表的当前节点所在层的下标
                }
                if (e.Node.Tag.ToString()[0] == '4')  //Tag中保存了读写权限和数据类型  4为只读
                {
                    ((TreeView)sender).ContextMenuStrip.Items[0].Enabled = false;
                }
            }
            else
            {
                ((TreeView)sender).ContextMenuStrip.Items[0].Enabled = false; //不是最后一层的节点关闭右键菜单
                ((TreeView)sender).ContextMenuStrip.Items[1].Enabled = false; //不是最后一层的节点关闭右键菜单
                ((TreeView)sender).ContextMenuStrip.Items[3].Enabled = false; //不是最后一层的节点关闭右键菜单
            }
        }

        private void ms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == this.ms.Items[0])
            {
                MessageBox.Show("set" + this.treeView1.SelectedNode.Text);
            }
            else if (e.ClickedItem == this.ms.Items[1])
            {
                MessageBox.Show("get");
            }
            else if (e.ClickedItem == this.ms.Items[2])
            {
                MessageBox.Show("walk");
            }
            else if (e.ClickedItem == this.ms.Items[3])
            {
                MessageBox.Show("next");
            }
        }

        private void TreeViewInit()
        {
            string text = System.IO.File.ReadAllText(@"I:\SNMP\prvmibgen\test.txt");
            JArray jsonObj = JArray.Parse(text);

            TreeNode[] nodeArray = func("enterprises", jsonObj);
      
            for (int i = 0; i < nodeArray.Length; i++)
            {
                this.treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes[3].Nodes.Add(nodeArray[i]);
            }
        }
        //在字典中找到name为str的成员，并用该成员创建一个treeview节点
        private TreeNode[] func(string str, JArray jsonObj)
        {
            foreach (var jObject in jsonObj)
            {
                if(jObject["name"].ToString() == str) //遍历整个字典 找到str对应的那一项
                {
                    ArrayList treeList = new ArrayList();
                    foreach (var kid in jObject["kids"]) //遍历该项的子节点 
                    {
                        System.Windows.Forms.TreeNode treeNode1;
                        if (((JArray)kid).Count != 0) //当子节点不为空时 继续递归
                        {
                            TreeNode[] treeArray = func(kid[0].ToString(), jsonObj);
                            //递归完之后开始定义节点， 并将递归的返回值即子节点挂载在该节点上
                            treeNode1 = new System.Windows.Forms.TreeNode(jObject["name"].ToString(), treeArray);
                            treeNode1.Name = treeNode1.Text;
                        }
                        else//当该节点没有子节点时 直接定义一个treeview节点，不需要挂载子节点
                        {
                            treeNode1 = new System.Windows.Forms.TreeNode(jObject["name"].ToString());
                            treeNode1.Name = treeNode1.Text;       
                        }
                        treeNode1.Tag = LookForNodeInfo(kid[0].ToString(), kid[2].ToString(), jsonObj);
                        treeList.Add(treeNode1);
                    }
                    return (TreeNode[])treeList.ToArray(typeof(TreeNode));
                }
            }
            return null;//执行到这一步说明没有找到对应的节点信息
        }
        
        private string LookForNodeInfo(string name, string id, JArray jsonObj)
        {
            string tag = "";
            foreach (var jObject in jsonObj)
            {
                if((name == jObject["name"].ToString()))
                {
                    switch (jObject["access"].ToString())
                    {
                        case "read-write":
                            tag += "6,";
                            tag += jObject["syntax"].ToString();
                            break;
                        case "read-only":
                            tag += "4,";
                            tag += jObject["syntax"].ToString();
                            break;
                        case "write-only":
                            tag += "2,";
                            tag += jObject["syntax"].ToString();
                            break;
                        default:
                            break;
                    }
                    break;
                }
            }
            return tag;
        }
    }
}
//Console.WriteLine("name:" + jObject["name"] + "\taccess:" + jObject["access"]);