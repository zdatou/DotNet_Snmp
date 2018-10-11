using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string info1, string info2):this()
        {
            PTPMonitorInfo = info1;
            NTPMonitorInfo = info2;
        }

        public string PTPMonitorInfo { get; set; }
        public string NTPMonitorInfo { get; set; }

        private void Form2_Load(object sender, EventArgs e)
        {
            MessageBox.Show(PTPMonitorInfo);
            MessageBox.Show(NTPMonitorInfo);
        }
    }
}
