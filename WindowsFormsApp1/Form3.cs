using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnmpSharpNet;


namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public string IP { get; set; }
        public string OID { get; set; }
        public string comm { get; set; }

        public Form3()
        {
            InitializeComponent();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            IpAddress agent = new IpAddress(this.IP);
            UdpTarget target = new UdpTarget((IPAddress)agent, 162, 2000, 1);

            Pdu pdu = new Pdu(PduType.Set);
            //pdu.VbList.Add(this.OID, new Integer32());


            OctetString community = new OctetString(this.comm);
            AgentParameters param = new AgentParameters(community);
            param.Version = SnmpVersion.Ver1;
 
            
            
            SnmpV1Packet result = (SnmpV1Packet)target.Request(pdu, param);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.cbbType.SelectedIndex = 0;
        }
    }
}
