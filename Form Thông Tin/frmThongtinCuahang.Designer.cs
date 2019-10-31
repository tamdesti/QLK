namespace QuanLyKho
{
    partial class frmThongtinCuahang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongtinCuahang));
            this.ckHethan = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numSPHethan = new System.Windows.Forms.NumericUpDown();
            this.ckHetHanTra = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numHetHanTra = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSPHethan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHetHanTra)).BeginInit();
            this.SuspendLayout();
            // 
            // ckHethan
            // 
            this.ckHethan.AutoSize = true;
            this.ckHethan.Location = new System.Drawing.Point(59, 29);
            this.ckHethan.Name = "ckHethan";
            this.ckHethan.Size = new System.Drawing.Size(186, 17);
            this.ckHethan.TabIndex = 8;
            this.ckHethan.Text = "Thông báo sản phẩm sắp hết hạn";
            this.ckHethan.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Báo trước:";
            // 
            // numSPHethan
            // 
            this.numSPHethan.Location = new System.Drawing.Point(130, 62);
            this.numSPHethan.Name = "numSPHethan";
            this.numSPHethan.Size = new System.Drawing.Size(61, 20);
            this.numSPHethan.TabIndex = 10;
            this.numSPHethan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ckHetHanTra
            // 
            this.ckHetHanTra.AutoSize = true;
            this.ckHetHanTra.Location = new System.Drawing.Point(59, 97);
            this.ckHetHanTra.Name = "ckHetHanTra";
            this.ckHetHanTra.Size = new System.Drawing.Size(211, 17);
            this.ckHetHanTra.TabIndex = 11;
            this.ckHetHanTra.Text = "Thông báo sắp hết hạn trả cho công ty";
            this.ckHetHanTra.UseVisualStyleBackColor = true;
            this.ckHetHanTra.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Báo trước:";
            this.label2.Visible = false;
            // 
            // numHetHanTra
            // 
            this.numHetHanTra.Location = new System.Drawing.Point(130, 128);
            this.numHetHanTra.Name = "numHetHanTra";
            this.numHetHanTra.Size = new System.Drawing.Size(61, 20);
            this.numHetHanTra.TabIndex = 13;
            this.numHetHanTra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numHetHanTra.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "(ngày)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "(ngày)";
            this.label4.Visible = false;
            // 
            // button1
            // 
            this.button1.Image = global::QuanLyKho.Properties.Resources.cancel;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(175, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 60);
            this.button1.TabIndex = 16;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::QuanLyKho.Properties.Resources.Ok;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(97, 170);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(57, 60);
            this.btnOK.TabIndex = 7;
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmThongtinCuahang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 242);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numHetHanTra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ckHetHanTra);
            this.Controls.Add(this.numSPHethan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckHethan);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongtinCuahang";
            this.Text = "Tùy chọn thông báo";
            this.Load += new System.EventHandler(this.frmThongtinCuahang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSPHethan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHetHanTra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox ckHethan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numSPHethan;
        private System.Windows.Forms.CheckBox ckHetHanTra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numHetHanTra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}