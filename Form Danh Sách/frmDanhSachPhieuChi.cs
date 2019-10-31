using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuanLyKho.BusinessObject;
using QuanLyKho.Controller;

namespace QuanLyKho
{
    public partial class frmDanhSachPhieuChi : Form
    {
        PhieuNhapController ctrl = new PhieuNhapController();
        NhaCungCapController ctrlNCC = new NhaCungCapController();
        public frmDanhSachPhieuChi()
        {
            InitializeComponent();
        }
        private void fromDate_CloseUp(object sender, EventArgs e)
        {
            if (fromDate.Value > toDate.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải lớn hơn ngày kết thúc", "Lỗi ngày nhập");
                fromDate.Value = toDate.Value;
            }
            ctrlNCC.HienthiDataGridviewComboBox(colNhaCungCap);
            ctrl.HienthiPhieuChiTuMaNCC(bindingNavigator1, dataGridView, cbNhaCungCap.SelectedValue.ToString(), fromDate.Value, toDate.Value);
            Util.AdjustColumnOrder(ref dataGridView);
        }

        private void frmDanhSachPhieuChi_Load(object sender, EventArgs e)
        {
            fromDate.Value = DateTime.Now.AddMonths(-1);
            ctrlNCC.HienthiDataGridviewComboBox(colNhaCungCap);
            ctrlNCC.HienthiAllComboBox(cbNhaCungCap, false);
            ctrl.HienthiPhieuChiTuMaNCC(bindingNavigator1, dataGridView, cbNhaCungCap.SelectedValue.ToString(), fromDate.Value, toDate.Value);
            dataGridView.AutoGenerateColumns = false;
            Util.AdjustColumnOrder(ref dataGridView);
        }
        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        frmChiTietPhieuChi ChiTietPhieuChi = null;
        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (ChiTietPhieuChi == null || ChiTietPhieuChi.IsDisposed)
            {
                DataRowView row = (DataRowView)bindingNavigator1.BindingSource.Current;
                ChiTietPhieuChi = new frmChiTietPhieuChi(row["ID"].ToString());
                ChiTietPhieuChi.WindowState = FormWindowState.Maximized;
                ChiTietPhieuChi.MdiParent = this.MdiParent;
                foreach (var f in this.MdiParent.MdiChildren)
                {
                    if (f != ChiTietPhieuChi)
                        f.Close();
                }
                ChiTietPhieuChi.Show();
            }
            else
                ChiTietPhieuChi.Activate();
        }

        private void cbNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            ctrl.HienthiPhieuChiTuMaNCC(bindingNavigator1, dataGridView, cbNhaCungCap.SelectedValue.ToString(), fromDate.Value, toDate.Value);
        }

        private void fromDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (fromDate.Value > toDate.Value)
                {
                    MessageBox.Show("Ngày bắt đầu phải lớn hơn ngày kết thúc", "Lỗi ngày nhập");
                    fromDate.Value = toDate.Value;
                }
                ctrlNCC.HienthiDataGridviewComboBox(colNhaCungCap);
                ctrl.HienthiPhieuChiTuMaNCC(bindingNavigator1, dataGridView, cbNhaCungCap.SelectedValue.ToString(), fromDate.Value, toDate.Value);
                Util.AdjustColumnOrder(ref dataGridView);
            }
        }
    }
}
