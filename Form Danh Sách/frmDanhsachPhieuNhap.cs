using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuanLyKho.Controller;
using QuanLyKho.BusinessObject;

namespace QuanLyKho
{
    public partial class frmDanhsachPhieuNhap : Form
    {
        public frmDanhsachPhieuNhap()
        {
            InitializeComponent();
        }

        PhieuNhapController ctrl = new PhieuNhapController();
        NhaCungCapController ctrlNCC = new NhaCungCapController();

        private void frmDanhsachPhieuNhap_Load(object sender, EventArgs e)
        {
            ctrlNCC.HienthiAllComboBox(cbNhaCungCap.ComboBox, false);
            ctrlNCC.HienthiDataGridviewComboBox(colNhaCungCap);
            ctrl.HienthiPhieuNhapTuMaNCC(bindingNavigator, dataGridView, "0");
            dataGridView.Columns["colNgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
            BusinessObject.Util.AdjustColumnOrder(ref dataGridView);
        }
        frmNhapHang NhapHang = null;
        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (NhapHang == null || NhapHang.IsDisposed)
            {
                NhapHang = new frmNhapHang(ctrl, (DataRowView)bindingNavigator.BindingSource.Current);
                NhapHang.WindowState = FormWindowState.Maximized;
                NhapHang.MdiParent = this.MdiParent;
                foreach (var f in this.MdiParent.MdiChildren)
                {
                    if (f != NhapHang)
                        f.Close();
                }
                NhapHang.Show();
            }
            else
                NhapHang.Activate();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (NhapHang == null || NhapHang.IsDisposed)
            {
                NhapHang = new frmNhapHang();
                NhapHang.WindowState = FormWindowState.Maximized;
                NhapHang.MdiParent = this.MdiParent;
                foreach (var f in this.MdiParent.MdiChildren)
                {
                    if (f != NhapHang)
                        f.Close();
                }
                NhapHang.Show();
            }
            else
                NhapHang.Activate();
        }

        private void cbNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNhaCungCap.ComboBox.SelectedValue != null)
            {
                ctrlNCC.HienthiDataGridviewComboBox(colNhaCungCap);
                ctrl.HienthiPhieuNhapTuMaNCC(bindingNavigator, dataGridView, cbNhaCungCap.ComboBox.SelectedValue.ToString());
            }
        }

        private void toolXoa_Click(object sender, EventArgs e)
        {
            if (bindingNavigator.BindingSource.Count == 0) return;
            SanPhamController ctrlSanPham = new SanPhamController();
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            string IDPhieuNhap = row["ID"].ToString();
            ChiTietPhieuNhapController CTPN = new ChiTietPhieuNhapController();
            IList<ChiTietPhieuNhap> DSChiTietPhieuNhap = new List<ChiTietPhieuNhap>();
            DSChiTietPhieuNhap = CTPN.ChiTietPhieuNhap(IDPhieuNhap);
            bool daban = false;
            foreach (ChiTietPhieuNhap msp in DSChiTietPhieuNhap)
            {
                //if (msp.SoLuongTon != (msp.SoLuong + msp.KhuyenMai))
                //{
                //    daban = true;
                //    break;
                //}
            }
            if (MessageBox.Show(daban ? "Trong phiếu nhập hiện tại có lô hàng đã được bán, khi xóa sẽ ảnh hưởng đến các phiếu bán đó! \nBạn có chắc chắn xóa không?" : "Bạn có chắc chắn xóa không?", "Phiếu nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (ChiTietPhieuNhap msp in DSChiTietPhieuNhap)
                {
                    SanPham sp = new SanPham();
                    sp = msp.SanPham;
                    //if (sp != null)
                    //    ctrlSanPham.CapNhatSoLuongSanPham(sp.Id, sp.SoLuong - (msp.SoLuong + msp.KhuyenMai));
                    CTPN.XoaChiTietPhieuNhap(msp.Id);
                }
                PhieuNhap PN = ctrl.LayPhieuNhap(IDPhieuNhap);
                PN.ConNo = PN.NoCu;
                ctrl.CapNhatChuoiNoCu(PN);
                ctrl.XoaPhieuNhap(IDPhieuNhap);
                ctrl.HienthiPhieuNhapTuMaNCC(bindingNavigator, dataGridView, cbNhaCungCap.ComboBox.SelectedValue.ToString());
            }
        }
    }
}