namespace Pronto
{
    partial class Search
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.from = new System.Windows.Forms.Label();
            this.ServiceCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.helperLabel1 = new System.Windows.Forms.Label();
            this.driverNameLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToPdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ClientZipTxt = new System.Windows.Forms.TextBox();
            this.ClientCityTxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ClientNameTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.driverNameCmb = new System.Windows.Forms.ComboBox();
            this.TruckCombo = new System.Windows.Forms.ComboBox();
            this.HelperCombo = new System.Windows.Forms.ComboBox();
            this.CustomerCombo = new System.Windows.Forms.ComboBox();
            this.ClientPhTxt = new System.Windows.Forms.TextBox();
            this.PtsIdTxt = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.RootNoCombo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // from
            // 
            this.from.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.from.AutoSize = true;
            this.from.Location = new System.Drawing.Point(64, 8);
            this.from.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(51, 19);
            this.from.TabIndex = 3;
            this.from.Text = "From";
            // 
            // ServiceCombo
            // 
            this.ServiceCombo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ServiceCombo.BackColor = System.Drawing.Color.White;
            this.ServiceCombo.FormattingEnabled = true;
            this.ServiceCombo.Location = new System.Drawing.Point(122, 103);
            this.ServiceCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ServiceCombo.Name = "ServiceCombo";
            this.ServiceCombo.Size = new System.Drawing.Size(284, 27);
            this.ServiceCombo.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "To";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(123, 4);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(283, 27);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimePicker2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Location = new System.Drawing.Point(123, 39);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(283, 27);
            this.dateTimePicker2.TabIndex = 5;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Route No";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Customer";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Truck:";
            // 
            // helperLabel1
            // 
            this.helperLabel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.helperLabel1.AutoSize = true;
            this.helperLabel1.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helperLabel1.Location = new System.Drawing.Point(39, 100);
            this.helperLabel1.Name = "helperLabel1";
            this.helperLabel1.Size = new System.Drawing.Size(66, 17);
            this.helperLabel1.TabIndex = 8;
            this.helperLabel1.Text = "HELPER:";
            this.helperLabel1.Click += new System.EventHandler(this.helperLabel1_Click);
            // 
            // driverNameLabel
            // 
            this.driverNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.driverNameLabel.AutoSize = true;
            this.driverNameLabel.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driverNameLabel.Location = new System.Drawing.Point(3, 7);
            this.driverNameLabel.Name = "driverNameLabel";
            this.driverNameLabel.Size = new System.Drawing.Size(102, 17);
            this.driverNameLabel.TabIndex = 6;
            this.driverNameLabel.Text = "Driver\'s Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 392);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1107, 377);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Result";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 24);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1099, 349);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // SearchBtn
            // 
            this.SearchBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.SearchBtn.FlatAppearance.BorderSize = 0;
            this.SearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBtn.ForeColor = System.Drawing.Color.White;
            this.SearchBtn.Location = new System.Drawing.Point(918, 340);
            this.SearchBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(167, 44);
            this.SearchBtn.TabIndex = 8;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = false;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1128, 25);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToExcelToolStripMenuItem,
            this.exportToPdfToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(43, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Image = global::Pronto.Properties.Resources.Excel;
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.exportToExcelToolStripMenuItem.Text = "Export To Excel";
            this.exportToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportToExcelToolStripMenuItem_Click);
            // 
            // exportToPdfToolStripMenuItem
            // 
            this.exportToPdfToolStripMenuItem.Image = global::Pronto.Properties.Resources.iconfinder_1_02_511559;
            this.exportToPdfToolStripMenuItem.Name = "exportToPdfToolStripMenuItem";
            this.exportToPdfToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.exportToPdfToolStripMenuItem.Text = "Export To Pdf";
            this.exportToPdfToolStripMenuItem.Click += new System.EventHandler(this.exportToPdfToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.ClientZipTxt, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.ClientCityTxt, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.ClientNameTxt, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.driverNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.driverNameCmb, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TruckCombo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.helperLabel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.HelperCombo, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.CustomerCombo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ClientPhTxt, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.PtsIdTxt, 1, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(473, 265);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // ClientZipTxt
            // 
            this.ClientZipTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientZipTxt.Location = new System.Drawing.Point(111, 259);
            this.ClientZipTxt.Name = "ClientZipTxt";
            this.ClientZipTxt.Size = new System.Drawing.Size(376, 27);
            this.ClientZipTxt.TabIndex = 19;
            // 
            // ClientCityTxt
            // 
            this.ClientCityTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientCityTxt.Location = new System.Drawing.Point(111, 226);
            this.ClientCityTxt.Name = "ClientCityTxt";
            this.ClientCityTxt.Size = new System.Drawing.Size(376, 27);
            this.ClientCityTxt.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(31, 257);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "Client Zip:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "Client City:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(60, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "PtsId:";
            // 
            // ClientNameTxt
            // 
            this.ClientNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientNameTxt.Location = new System.Drawing.Point(111, 127);
            this.ClientNameTxt.Name = "ClientNameTxt";
            this.ClientNameTxt.Size = new System.Drawing.Size(376, 27);
            this.ClientNameTxt.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(38, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "ClientPh:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "ClientName:";
            // 
            // driverNameCmb
            // 
            this.driverNameCmb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.driverNameCmb.BackColor = System.Drawing.Color.White;
            this.driverNameCmb.FormattingEnabled = true;
            this.driverNameCmb.Location = new System.Drawing.Point(111, 2);
            this.driverNameCmb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.driverNameCmb.Name = "driverNameCmb";
            this.driverNameCmb.Size = new System.Drawing.Size(376, 27);
            this.driverNameCmb.TabIndex = 7;
            this.driverNameCmb.SelectedIndexChanged += new System.EventHandler(this.driverNameCmb_SelectedIndexChanged);
            // 
            // TruckCombo
            // 
            this.TruckCombo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TruckCombo.BackColor = System.Drawing.Color.White;
            this.TruckCombo.FormattingEnabled = true;
            this.TruckCombo.Location = new System.Drawing.Point(111, 64);
            this.TruckCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TruckCombo.Name = "TruckCombo";
            this.TruckCombo.Size = new System.Drawing.Size(376, 27);
            this.TruckCombo.TabIndex = 9;
            this.TruckCombo.SelectedIndexChanged += new System.EventHandler(this.helpercmb1_SelectedIndexChanged);
            // 
            // HelperCombo
            // 
            this.HelperCombo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HelperCombo.BackColor = System.Drawing.Color.White;
            this.HelperCombo.FormattingEnabled = true;
            this.HelperCombo.Location = new System.Drawing.Point(111, 95);
            this.HelperCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HelperCombo.Name = "HelperCombo";
            this.HelperCombo.Size = new System.Drawing.Size(376, 27);
            this.HelperCombo.TabIndex = 10;
            this.HelperCombo.SelectedIndexChanged += new System.EventHandler(this.CustomerCombo_SelectedIndexChanged);
            // 
            // CustomerCombo
            // 
            this.CustomerCombo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CustomerCombo.BackColor = System.Drawing.Color.White;
            this.CustomerCombo.FormattingEnabled = true;
            this.CustomerCombo.Location = new System.Drawing.Point(111, 33);
            this.CustomerCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CustomerCombo.Name = "CustomerCombo";
            this.CustomerCombo.Size = new System.Drawing.Size(376, 27);
            this.CustomerCombo.TabIndex = 10;
            // 
            // ClientPhTxt
            // 
            this.ClientPhTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientPhTxt.Location = new System.Drawing.Point(111, 160);
            this.ClientPhTxt.Name = "ClientPhTxt";
            this.ClientPhTxt.Size = new System.Drawing.Size(376, 27);
            this.ClientPhTxt.TabIndex = 15;
            // 
            // PtsIdTxt
            // 
            this.PtsIdTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PtsIdTxt.Location = new System.Drawing.Point(111, 193);
            this.PtsIdTxt.Name = "PtsIdTxt";
            this.PtsIdTxt.Size = new System.Drawing.Size(376, 27);
            this.PtsIdTxt.TabIndex = 17;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.5102F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.4898F));
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.RootNoCombo, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.from, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.dateTimePicker1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.dateTimePicker2, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.ServiceCombo, 1, 3);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(11, 28);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(468, 126);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(63, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Service";
            // 
            // RootNoCombo
            // 
            this.RootNoCombo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RootNoCombo.BackColor = System.Drawing.Color.White;
            this.RootNoCombo.FormattingEnabled = true;
            this.RootNoCombo.Location = new System.Drawing.Point(122, 72);
            this.RootNoCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RootNoCombo.Name = "RootNoCombo";
            this.RootNoCombo.Size = new System.Drawing.Size(284, 27);
            this.RootNoCombo.TabIndex = 18;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(17, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(521, 222);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Date Range and Service Type:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel1);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(590, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(495, 288);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select Filters:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(727, 340);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 44);
            this.button1.TabIndex = 17;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1128, 782);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label helperLabel1;
        private System.Windows.Forms.Label driverNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label from;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ServiceCombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToPdfToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox driverNameCmb;
        private System.Windows.Forms.ComboBox CustomerCombo;
        private System.Windows.Forms.ComboBox TruckCombo;
        private System.Windows.Forms.ComboBox HelperCombo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ClientNameTxt;
        private System.Windows.Forms.TextBox ClientPhTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PtsIdTxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox RootNoCombo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ClientZipTxt;
        private System.Windows.Forms.TextBox ClientCityTxt;
    }
}