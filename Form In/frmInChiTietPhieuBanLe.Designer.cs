namespace QuanLyKho
{
    partial class frmInChiTietPhieuBanLe
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
            this.InChiTietPhieuBanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.InChiTietPhieuBanBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // InChiTietPhieuBanBindingSource
            // 
            this.InChiTietPhieuBanBindingSource.DataSource = typeof(QuanLyKho.BusinessObject.InChiTietPhieuBan);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "InPhieuBanLe";
            reportDataSource1.Value = this.InChiTietPhieuBanBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyKho.Report.InPhieuBanLe.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(793, 579);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmInChiTietPhieuBanLe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 579);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmInChiTietPhieuBanLe";
            this.Text = "Chi tiết phiếu bán lẻ";
            this.Load += new System.EventHandler(this.frmInChiTietPhieuBanLe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InChiTietPhieuBanBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource InChiTietPhieuBanBindingSource;
    }
}