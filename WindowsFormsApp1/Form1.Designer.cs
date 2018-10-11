namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("directory");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("system");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("interfaces");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("at");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("ip");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("icmp");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("udp");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("egp");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("transmission");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("snmp");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("appletalk");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("ospf");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("host");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("mib2", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("mgmt", new System.Windows.Forms.TreeNode[] {
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("experimental");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("private");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("security");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("snmpV2");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("internet", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("dod", new System.Windows.Forms.TreeNode[] {
            treeNode20});
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("org", new System.Windows.Forms.TreeNode[] {
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("iso", new System.Windows.Forms.TreeNode[] {
            treeNode22});
            this.ms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.walkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTest = new System.Windows.Forms.TextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblMIB = new System.Windows.Forms.Label();
            this.lblOID = new System.Windows.Forms.Label();
            this.cbbIP = new System.Windows.Forms.ComboBox();
            this.cbbOID = new System.Windows.Forms.ComboBox();
            this.cbbMethod = new System.Windows.Forms.ComboBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDescr = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ms
            // 
            this.ms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setToolStripMenuItem,
            this.getToolStripMenuItem,
            this.walkToolStripMenuItem,
            this.nextToolStripMenuItem});
            this.ms.Name = "ms";
            this.ms.Size = new System.Drawing.Size(106, 92);
            this.ms.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ms_ItemClicked);
            // 
            // setToolStripMenuItem
            // 
            this.setToolStripMenuItem.Name = "setToolStripMenuItem";
            this.setToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.setToolStripMenuItem.Text = "Set";
            // 
            // getToolStripMenuItem
            // 
            this.getToolStripMenuItem.Name = "getToolStripMenuItem";
            this.getToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.getToolStripMenuItem.Text = "Get";
            // 
            // walkToolStripMenuItem
            // 
            this.walkToolStripMenuItem.Name = "walkToolStripMenuItem";
            this.walkToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.walkToolStripMenuItem.Text = "Walk";
            // 
            // nextToolStripMenuItem
            // 
            this.nextToolStripMenuItem.Name = "nextToolStripMenuItem";
            this.nextToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.nextToolStripMenuItem.Text = "Next";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtTest
            // 
            this.txtTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTest.Location = new System.Drawing.Point(199, 327);
            this.txtTest.Multiline = true;
            this.txtTest.Name = "txtTest";
            this.txtTest.Size = new System.Drawing.Size(589, 82);
            this.txtTest.TabIndex = 2;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(12, 12);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(17, 12);
            this.lblIP.TabIndex = 4;
            this.lblIP.Text = "IP";
            // 
            // lblMIB
            // 
            this.lblMIB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblMIB.Location = new System.Drawing.Point(12, 43);
            this.lblMIB.Name = "lblMIB";
            this.lblMIB.Size = new System.Drawing.Size(181, 23);
            this.lblMIB.TabIndex = 8;
            this.lblMIB.Text = "MIB树";
            this.lblMIB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOID
            // 
            this.lblOID.AutoSize = true;
            this.lblOID.Location = new System.Drawing.Point(193, 11);
            this.lblOID.Name = "lblOID";
            this.lblOID.Size = new System.Drawing.Size(23, 12);
            this.lblOID.TabIndex = 9;
            this.lblOID.Text = "OID";
            // 
            // cbbIP
            // 
            this.cbbIP.FormattingEnabled = true;
            this.cbbIP.Location = new System.Drawing.Point(35, 7);
            this.cbbIP.Name = "cbbIP";
            this.cbbIP.Size = new System.Drawing.Size(137, 20);
            this.cbbIP.TabIndex = 11;
            this.cbbIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbIP_KeyPress);
            // 
            // cbbOID
            // 
            this.cbbOID.FormattingEnabled = true;
            this.cbbOID.Location = new System.Drawing.Point(222, 7);
            this.cbbOID.Name = "cbbOID";
            this.cbbOID.Size = new System.Drawing.Size(137, 20);
            this.cbbOID.TabIndex = 12;
            this.cbbOID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbOID_KeyPress);
            // 
            // cbbMethod
            // 
            this.cbbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMethod.FormattingEnabled = true;
            this.cbbMethod.Items.AddRange(new object[] {
            "Get",
            "Set"});
            this.cbbMethod.Location = new System.Drawing.Point(397, 7);
            this.cbbMethod.Name = "cbbMethod";
            this.cbbMethod.Size = new System.Drawing.Size(74, 20);
            this.cbbMethod.TabIndex = 13;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(488, 7);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(33, 21);
            this.btnGo.TabIndex = 14;
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            this.btnGo.Paint += new System.Windows.Forms.PaintEventHandler(this.btnGo_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(199, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(589, 231);
            this.dataGridView1.TabIndex = 15;
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "OID";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Syntax";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Value";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // lblDescr
            // 
            this.lblDescr.AutoSize = true;
            this.lblDescr.Location = new System.Drawing.Point(200, 309);
            this.lblDescr.Name = "lblDescr";
            this.lblDescr.Size = new System.Drawing.Size(53, 12);
            this.lblDescr.TabIndex = 16;
            this.lblDescr.Text = "提示信息";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.ContextMenuStrip = this.ms;
            this.treeView1.Location = new System.Drawing.Point(12, 66);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "directory";
            treeNode1.Text = "directory";
            treeNode2.Name = "system";
            treeNode2.Text = "system";
            treeNode3.Name = "interfaces";
            treeNode3.Text = "interfaces";
            treeNode4.Name = "at";
            treeNode4.Text = "at";
            treeNode5.Name = "ip";
            treeNode5.Text = "ip";
            treeNode6.Name = "icmp";
            treeNode6.Text = "icmp";
            treeNode7.Name = "tcp";
            treeNode7.Text = "udp";
            treeNode8.Name = "egp";
            treeNode8.Text = "egp";
            treeNode9.Name = "transmission";
            treeNode9.Text = "transmission";
            treeNode10.Name = "snmp";
            treeNode10.Text = "snmp";
            treeNode11.Name = "appletalk";
            treeNode11.Text = "appletalk";
            treeNode12.Name = "ospf";
            treeNode12.Text = "ospf";
            treeNode13.Name = "host";
            treeNode13.Text = "host";
            treeNode14.Name = "mib2";
            treeNode14.Text = "mib2";
            treeNode15.Name = "mgmt";
            treeNode15.Text = "mgmt";
            treeNode16.Name = "experimental";
            treeNode16.Text = "experimental";
            treeNode17.Name = "private";
            treeNode17.Text = "private";
            treeNode18.Name = "security";
            treeNode18.Text = "security";
            treeNode19.Name = "snmpV2";
            treeNode19.Text = "snmpV2";
            treeNode20.Name = "internet";
            treeNode20.Text = "internet";
            treeNode21.Name = "dod";
            treeNode21.Text = "dod";
            treeNode22.Name = "org";
            treeNode22.Text = "org";
            treeNode23.Name = "iso";
            treeNode23.Text = "iso";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode23});
            this.treeView1.Size = new System.Drawing.Size(181, 372);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDescr);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.cbbMethod);
            this.Controls.Add(this.cbbOID);
            this.Controls.Add(this.cbbIP);
            this.Controls.Add(this.lblOID);
            this.Controls.Add(this.lblMIB);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.txtTest);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTest;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblMIB;
        private System.Windows.Forms.Label lblOID;
        private System.Windows.Forms.ComboBox cbbIP;
        private System.Windows.Forms.ComboBox cbbOID;
        private System.Windows.Forms.ComboBox cbbMethod;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ContextMenuStrip ms;
        private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem walkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label lblDescr;
        private System.Windows.Forms.TreeView treeView1;
    }
}

