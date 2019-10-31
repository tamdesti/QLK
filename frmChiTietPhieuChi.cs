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
        String IDPhieuNhap = "";
        public frmChiTietPhieuChi()
        {
            InitializeComponent();
        }
        public frmChiTietPhieuChi(String ID_Phieu_Nhap)
            :this()
        {
            IDPhieuNhap = ID_Phieu_Nhap;
            PhieuNhapController PN = new PhieuNhapController();
            BusinessObject.PhieuNhap pb = PN.LayPhieuNhap(IDPhieuNhap);
            lbMaPhieu.Text = pb.Id;
            if (pb.NoCu > 1000) lbNoCu.Text = pb.NoCu.ToString("#,###");
            else lbNoCu.Text = pb.NoCu.ToString();
            if (pb.TongTien > 1000) lbThanhTien.Text = pb.TongTien.ToString("#,###");
            else lbThanhTien.Text = pb.TongTien.ToString();
            if ((pb.TongTien + pb.NoCu) > 1000) lbTongTien.Text = (pb.TongTien + pb.NoCu).ToString("#,###");
            else lbTongTien.Text = (pb.TongTien + pb.NoCu).ToString();
            if (pb.DaTra > 1000) lbDaTra.Text = pb.DaTra.ToString("#,###");
            else lbDaTra.Text = pb.DaTra.ToString();
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
    }
}
