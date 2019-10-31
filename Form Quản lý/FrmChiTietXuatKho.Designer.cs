namespace QuanLyKho
{
    partial class FrmChiTietXuatKho
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupbox3 = new System.Windows.Forms.GroupBox();
            this.DateGroup = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbKho = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSanPham = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupbox3.SuspendLayout();
            this.DateGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 168);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(911, 264);
            this.dataGridView1.TabIndex = 4;
            // 
            // groupbox3
            // 
            this.groupbox3.Controls.Add(this.DateGroup);
            this.groupbox3.Controls.Add(this.label2);
            this.groupbox3.Controls.Add(this.btnPrint);
            this.groupbox3.Controls.Add(this.label11);
            this.groupbox3.Controls.Add(this.cmbKho);
            this.groupbox3.Controls.Add(this.label1);
            this.groupbox3.Controls.Add(this.cmbSanPham);
            this.groupbox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupbox3.Location = new System.Drawing.Point(0, 0);
            this.groupbox3.Name = "groupbox3";
            this.groupbox3.Size = new System.Drawing.Size(911, 168);
            this.groupbox3.TabIndex = 3;
            this.groupbox3.TabStop = false;
            // 
            // DateGroup
            // 
            this.DateGroup.Controls.Add(this.label3);
            this.DateGroup.Controls.Add(this.label4);
            this.DateGroup.Controls.Add(this.fromDate);
            this.DateGroup.Controls.Add(this.toDate);
            this.DateGroup.Location = new System.Drawing.Point(307, 19);
            this.DateGroup.Name = "DateGroup";
            this.DateGroup.Size = new System.Drawing.Size(176, 111);
            this.DateGroup.TabIndex = 40;
            this.DateGroup.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Từ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Đến:";
            // 
            // fromDate
            // 
            this.fromDate.CustomFormat = "dd/MM/yyyy";
            this.fromDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.fromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromDate.Location = new System.Drawing.Point(48, 29);
            this.fromDate.Name = "fromDate";
            this.fromDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fromDate.Size = new System.Drawing.Size(100, 20);
            this.fromDate.TabIndex = 36;
            this.fromDate.CloseUp += new System.EventHandler(this.fromDate_ValueChanged);
            this.fromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fromDate_KeyDown);
            this.fromDate.Leave += new System.EventHandler(this.fromDate_ValueChanged);
            // 
            // toDate
            // 
            this.toDate.CustomFormat = "dd/MM/yyyy";
            this.toDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.toDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toDate.Location = new System.Drawing.Point(48, 63);
            this.toDate.Name = "toDate";
            this.toDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toDate.Size = new System.Drawing.Size(100, 20);
            this.toDate.TabIndex = 37;
            this.toDate.CloseUp += new System.EventHandler(this.toDate_ValueChanged);
            this.toDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toDate_KeyDown);
            this.toDate.Leave += new System.EventHandler(this.toDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(516, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "In Báo Cáo";
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::QuanLyKho.Properties.Resources.printer;
            this.btnPrint.Location = new System.Drawing.Point(523, 43);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(42, 34);
            this.btnPrint.TabIndex = 34;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(46, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Kho:";
            // 
            // cmbKho
            // 
            this.cmbKho.FormattingEnabled = true;
            this.cmbKho.Location = new System.Drawing.Point(127, 26);
            this.cmbKho.Name = "cmbKho";
            this.cmbKho.Size = new System.Drawing.Size(158, 21);
            this.cmbKho.TabIndex = 29;
            this.cmbKho.SelectedIndexChanged += new System.EventHandler(this.cmbKho_SelectedIndexChanged);
            this.cmbKho.Leave += new System.EventHandler(this.cmbKho_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Sản phẩm";
            // 
            // cmbSanPham
            // 
            this.cmbSanPham.FormattingEnabled = true;
            this.cmbSanPham.Location = new System.Drawing.Point(128, 59);
            this.cmbSanPham.Name = "cmbSanPham";
            this.cmbSanPham.Size = new System.Drawing.Size(159, 21);
            this.cmbSanPham.TabIndex = 31;
            this.cmbSanPham.SelectedIndexChanged += new System.EventHandler(this.cmbSanPham_SelectedIndexChanged);
            this.cmbSanPham.Leave += new System.EventHandler(this.cmbSanPham_Leave);
            // 
            // FrmChiTietXuatKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 432);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupbox3);
            this.Name = "FrmChiTietXuatKho";
            this.Text = "FrmChiTietXuatKho";
            this.Load += new System.EventHandler(this.FrmChiTietXuatKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupbox3.ResumeLayout(false);
            this.groupbox3.PerformLayout();
            this.DateGroup.ResumeLayout(false);
            this.DateGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupbox3;
        private System.Windows.Forms.GroupBox DateGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker fromDate;
        private System.Windows.Forms.DateTimePicker toDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbKho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSanPham;
    }
}