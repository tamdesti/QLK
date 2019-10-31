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
    public partial class frmDanhsachPhieuBanSi : Form
    {
        public frmDanhsachPhieuBanSi()
        {
            InitializeComponent();
        }

        PhieuBanController ctrl = new PhieuBanController();
        KhachHangController ctrlKH = new KhachHangController();
        private void frmDanhsachPhieuNhap_Load(object sender, EventArgs e)
        {
            ctrlKH.HienthiAllDaiLyAutoComboBox(cbDaiLy.ComboBox);
            ctrlKH.HienthiDaiLyDataGridviewComboBox(colKhachhang);
            ctrl.LayDanhSachPhieuBanTuMaKH(bindingNavigator, dataGridView, "0", true);
            dataGridView.Columns["colNgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
            Util.AdjustColumnOrder(ref dataGridView);
        }
        frmBanSi BanHang = null;
        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (BanHang == null || BanHang.IsDisposed)
            {
                BanHang = new frmBanSi(ctrl, (DataRowView)bindingNavigator.BindingSource.Current);
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
                BanHang = new frmBanSi();
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
            if (bindingNavigator.BindingSource.Count == 0) return;
            DataRowView view =  (DataRowView)bindingNavigator.BindingSource.Current;
            if (view != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Phiếu Bán Sỉ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void toolIn_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            if (row != null)
            {
                PhieuBanController ctrlPB = new PhieuBanController();
                String ma_phieu = row["ID"].ToString();
                QuanLyKho.BusinessObject.PhieuBan ph = ctrlPB.LayPhieuBan(ma_phieu);
                frmInChiTietPhieuBan PhieuBan = new frmInChiTietPhieuBan(ph);
                PhieuBan.Show();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để in");
            }
        }
        private void cbDaiLy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDaiLy.ComboBox.SelectedValue != null)
            {
                ctrlKH.HienthiDaiLyDataGridviewComboBox(colKhachhang);
                ctrl.LayDanhSachPhieuBanTuMaKH(bindingNavigator, dataGridView, cbDaiLy.ComboBox.SelectedValue.ToString(), true);
            }
        }
    }
}