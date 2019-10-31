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
    public partial class frmDanhsachPhieuBanLe : Form
    {
        public frmDanhsachPhieuBanLe()
        {
            InitializeComponent();
        }

        PhieuBanController ctrl = new PhieuBanController();
        KhachHangController ctrlKH = new KhachHangController();
        private void frmDanhsachPhieuNhap_Load(object sender, EventArgs e)
        {
            ctrlKH.HienthiAllKhachHangAutoComboBox(cbKhachHang.ComboBox);
            ctrlKH.HienthiKhachHangDataGridviewComboBox(colKhachhang);
            ctrl.LayDanhSachPhieuBanTuMaKH(bindingNavigator, dataGridView, cbKhachHang.ComboBox.SelectedValue.ToString(), false);
            dataGridView.Columns["colNgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
            Util.AdjustColumnOrder(ref dataGridView);
        }
        frmBanLe BanHang = null;
        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (BanHang == null || BanHang.IsDisposed)
            {
                BanHang = new frmBanLe(ctrl, (DataRowView)bindingNavigator.BindingSource.Current);
                BanHang.WindowState = FormWindowState.Maximized;
                BanHang.MdiParent = this.MdiParent;
                foreach (var f in this.MdiParent.MdiChildren)
                {
                    if (f != BanHang)
                        f.Close();
                }
                BanHang.Show();
            }
            else
                BanHang.Activate();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (BanHang == null || BanHang.IsDisposed)
            {
                BanHang = new frmBanLe();
                BanHang.WindowState = FormWindowState.Maximized;
                BanHang.MdiParent = this.MdiParent;
                foreach (var f in this.MdiParent.MdiChildren)
                {
                    if (f != BanHang)
                        f.Close();
                }
                BanHang.Show();
            }
            else
                BanHang.Activate();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DataRowView view = (DataRowView)bindingNavigator.BindingSource.Current;
            if (view != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Phieu Ban Le", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ChiTietPhieuBanController CTPBCtrl = new ChiTietPhieuBanController();
                    PhieuThanhToanController PTTCtrl = new PhieuThanhToanController();
                    IList<ChiTietPhieuBan> ds = CTPBCtrl.ChiTietPhieuBan(view["ID"].ToString());
                    foreach (ChiTietPhieuBan ct in ds)
                    {
                        //QuanLyKho.DataLayer.ChiTietPhieuNhapFactory.CapNhatSoLuong(ct.ChiTietPhieuNhap.Id, ct.SoLuong + ct.KhuyenMai);
                        CTPBCtrl.XoaChiTietPhieuBan(ct.ID.ToString());
                        PTTCtrl.XoaPhieuThanhToanTheoIDPhieuBan(ct.PhieuBan.Id);
                    }
                    bindingNavigator.BindingSource.RemoveCurrent();
                    ctrl.Save();
                }
            }
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void cbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKhachHang.ComboBox.SelectedValue != null)
            {
                ctrlKH.HienthiKhachHangDataGridviewComboBox(colKhachhang);
                ctrl.LayDanhSachPhieuBanTuMaKH(bindingNavigator, dataGridView, cbKhachHang.ComboBox.SelectedValue.ToString(), false);
            }
        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            if (row != null)
            {
                PhieuBanController ctrlPB = new PhieuBanController();
                String ma_phieu = row["ID"].ToString();
                QuanLyKho.BusinessObject.PhieuBan ph = ctrlPB.LayPhieuBan(ma_phieu);
                frmInChiTietPhieuBanLe PhieuBan = new frmInChiTietPhieuBanLe(ph);
                PhieuBan.Show();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để in");
            }
        }
    }
}