namespace Pronto.Common
{
    partial class SetTime
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
            this.components = new System.ComponentModel.Container();
            this.OkButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.StopArrivalTime = new System.Windows.Forms.Label();
            this.StopDepartTime = new System.Windows.Forms.Label();
            this.StopTimeAllot = new System.Windows.Forms.Label();
            this.ArivalTime = new System.Windows.Forms.DateTimePicker();
            this.DepartTime = new System.Windows.Forms.DateTimePicker();
            this.TimeDiff = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(132, 106);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.TimeDiff, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.DepartTime, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.StopArrivalTime, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.StopDepartTime, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.StopTimeAllot, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ArivalTime, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(195, 76);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // StopArrivalTime
            // 
            this.StopArrivalTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.StopArrivalTime.AutoSize = true;
            this.StopArrivalTime.Location = new System.Drawing.Point(7, 6);
            this.StopArrivalTime.Name = "StopArrivalTime";
            this.StopArrivalTime.Size = new System.Drawing.Size(87, 13);
            this.StopArrivalTime.TabIndex = 0;
            this.StopArrivalTime.Text = "Stop Arrival Time";
            // 
            // StopDepartTime
            // 
            this.StopDepartTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.StopDepartTime.AutoSize = true;
            this.StopDepartTime.Location = new System.Drawing.Point(4, 32);
            this.StopDepartTime.Name = "StopDepartTime";
            this.StopDepartTime.Size = new System.Drawing.Size(90, 13);
            this.StopDepartTime.TabIndex = 1;
            this.StopDepartTime.Text = "Stop Depart Time";
            // 
            // StopTimeAllot
            // 
            this.StopTimeAllot.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.StopTimeAllot.AutoSize = true;
            this.StopTimeAllot.Location = new System.Drawing.Point(16, 58);
            this.StopTimeAllot.Name = "StopTimeAllot";
            this.StopTimeAllot.Size = new System.Drawing.Size(78, 13);
            this.StopTimeAllot.TabIndex = 2;
            this.StopTimeAllot.Text = "Stop Time Allot";
            // 
            // ArivalTime
            // 
            this.ArivalTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ArivalTime.CustomFormat = "hh:mm:tt";
            this.ArivalTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ArivalTime.Location = new System.Drawing.Point(100, 3);
            this.ArivalTime.Name = "ArivalTime";
            this.ArivalTime.ShowUpDown = true;
            this.ArivalTime.Size = new System.Drawing.Size(92, 20);
            this.ArivalTime.TabIndex = 3;
            this.ArivalTime.ValueChanged += new System.EventHandler(this.ArivalTime_ValueChanged);
            // 
            // DepartTime
            // 
            this.DepartTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DepartTime.CustomFormat = "hh:mm:tt";
            this.DepartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DepartTime.Location = new System.Drawing.Point(100, 29);
            this.DepartTime.Name = "DepartTime";
            this.DepartTime.ShowUpDown = true;
            this.DepartTime.Size = new System.Drawing.Size(92, 20);
            this.DepartTime.TabIndex = 4;
            this.DepartTime.ValueChanged += new System.EventHandler(this.ArivalTime_ValueChanged);
            // 
            // TimeDiff
            // 
            this.TimeDiff.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TimeDiff.Enabled = false;
            this.TimeDiff.Location = new System.Drawing.Point(100, 55);
            this.TimeDiff.Name = "TimeDiff";
            this.TimeDiff.Size = new System.Drawing.Size(92, 20);
            this.TimeDiff.TabIndex = 3;
            this.TimeDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TimeDiff.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // SetTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 139);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetTime";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SetTime";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SetTime_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label StopArrivalTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label StopDepartTime;
        private System.Windows.Forms.Label StopTimeAllot;
        private System.Windows.Forms.DateTimePicker ArivalTime;
        private System.Windows.Forms.DateTimePicker DepartTime;
        private System.Windows.Forms.TextBox TimeDiff;
    }
}