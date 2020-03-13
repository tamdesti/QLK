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
    public partial class frmChiTietPhieuChi : Form
    {
        PhieuChiController PC = new PhieuChiController();
        PhieuNhapController PN = new PhieuNhapController();
        String IDPhieuNhap = "";
        decimal DaTraCu = 0;
        decimal TienThanhToan = 0;
        decimal TongTien = 0;
        public frmChiTietPhieuChi()
        {
            InitializeComponent();
        }
        public frmChiTietPhieuChi(String ID_Phieu_Nhap)
            :this()
        {
            IDPhieuNhap = ID_Phieu_Nhap;
            LoadChiTietPhieuNhap();
        }
        public void LoadChiTietPhieuNhap()
        {
            PhieuNhapController PN = new PhieuNhapController();
            BusinessObject.PhieuNhap pb = PN.LayPhieuNhap(IDPhieuNhap);
            lbMaPhieu.Text = pb.Id;
            if (pb.NoCu > 1000) lbNoCu.Text = pb.NoCu.ToString("#,###");
            else lbNoCu.Text = pb.NoCu.ToString();
            if (pb.TongTien > 1000) lbThanhTien.Text = pb.TongTien.ToString("#,###");
            else lbThanhTien.Text = pb.TongTien.ToString();
            if ((pb.TongTien + pb.NoCu) > 1000) lbTongTien.Text = (pb.TongTien + pb.NoCu).ToString("#,###");
            else lbTongTien.Text = (pb.TongTien + pb.NoCu).ToString();
            TongTien = Convert.ToDecimal(pb.TongTien + pb.NoCu);
            if (pb.DaTra > 1000) lbDaTra.Text = pb.DaTra.ToString("#,###");
            else lbDaTra.Text = pb.DaTra.ToString();
            DaTraCu = Convert.ToDecimal(pb.DaTra);
            if (pb.ConNo > 1000) lbConNo.Text = pb.ConNo.ToString("#,###");
            else lbConNo.Text = pb.ConNo.ToString();
            lbHoTen.Text = pb.NhaCungCap.HoTen;
            lbDiaChi.Text = pb.NhaCungCap.DiaChi;
            lbSDT.Text = pb.NhaCungCap.DienThoai;
        }
        private void frmChiTietPhieuChi_Load(object sender, EventArgs e)
        {
            PC.HienThiDanhSachPhieuChiTheoPhieuNhap(bindingNavigator1, dataGridView1, IDPhieuNhap);
        }

        private void toolIn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in");
                return;
            }
            frmInPhieuChi phieuchi = new frmInPhieuChi(dataGridView1);
            phieuchi.Size = new Size(900, 550);
            phieuchi.ShowDialog();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)bindingNavigator1.BindingSource.Current;
            row["GHI_CHU"] = GhiChu.Text;
            row["TONG_TIEN"] = numThanhToan.Value;
            row["NGAY_CHI"] = dtNgayTra.Value;
            PC.CapNhatChiTietPhieuChi(row);
            dataGridView1.Refresh();
            btnLuu.Enabled = false;
            decimal TienLech = TienThanhToan - numThanhToan.Value;
            decimal DaTraMoi = 0;
            DaTraMoi = DaTraCu - TienLech;
            PN.CapNhatPhieuNhap(IDPhieuNhap, TongTien, DaTraMoi, TongTien - DaTraMoi);
            LoadChiTietPhieuNhap();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            decimal DaTraMoi = 0;
            DaTraMoi = DaTraCu - TienThanhToan;
            PN.CapNhatPhieuNhap(IDPhieuNhap, TongTien, DaTraMoi, TongTien - DaTraMoi);
            LoadChiTietPhieuNhap();
            DataRowView row = (DataRowView)bindingNavigator1.BindingSource.Current;
            PC.XoaPhieuChi(row["ID"].ToString());
            PC.HienThiDanhSachPhieuChiTheoPhieuNhap(bindingNavigator1, dataGridView1, IDPhieuNhap);
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView row = (DataRowView)bindingNavigator1.BindingSource.Current;
            dtNgayTra.Value = Convert.ToDateTime(row["NGAY_CHI"]).Date;
            GhiChu.Text = row["GHI_CHU"].ToString();
            numThanhToan.Value = Convert.ToInt64(row["TONG_TIEN"].ToString());
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            TienThanhToan = numThanhToan.Value;
        }
    }
}
