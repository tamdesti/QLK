namespace QuanLyKho
{
    partial class frmInChiTietXuatKhoTheoSanPham
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ChiTietXuatKhoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ChiTietXuatKhoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ChiTietXuatKhoBindingSource
            // 
            this.ChiTietXuatKhoBindingSource.DataSource = typeof(QuanLyKho.BusinessObject.ChiTietXuatKho);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetChiTietXuatKhoTheoKhachHang";
            reportDataSource1.Value = this.ChiTietXuatKhoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyKho.Report.InChiTietXuatKhoTheoSanPham.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(865, 482);
            this.reportViewer1.TabIndex = 2;
            // 
            // frmInChiTietXuatKhoTheoSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 482);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmInChiTietXuatKhoTheoSanPham";
            this.Text = "frmInChiTietXuatKho";
            this.Load += new System.EventHandler(this.frmInChiTietXuatKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChiTietXuatKhoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ChiTietXuatKhoBindingSource;
    }
}