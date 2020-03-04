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
    public partial class frmChiTietPhieuThu : Form
    {
        PhieuThanhToanController PTT = new PhieuThanhToanController();
        String IDPhieuBan = "";
        bool isDaiLy = true;
        public frmChiTietPhieuThu()
        {
            InitializeComponent();
        }
        public frmChiTietPhieuThu(String ID_Phieu_Ban)
            :this()
        {
            IDPhieuBan = ID_Phieu_Ban;
            PhieuBanController PB = new PhieuBanController();
            BusinessObject.PhieuBan pb = PB.LayPhieuBan(IDPhieuBan);
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
            lbHoTen.Text = pb.KhachHang.HoTen;
            lbDiaChi.Text = pb.KhachHang.DiaChi;
            lbSDT.Text = pb.KhachHang.DienThoai;
            lbDaiLy.Text = pb.KhachHang.TenDaiLy;
            isDaiLy = pb.KhachHang.LoaiKH;
        }
        private void frmChiTietPhieuThu_Load(object sender, EventArgs e)
        {
            PTT.HienthiPhieuThanhToan(bindingNavigator1, dataGridView1, IDPhieuBan);
        }

        private void toolIn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in");
                return;
            }
            if (isDaiLy)
            {
                frmInPhieuThu phieuthu = new frmInPhieuThu(dataGridView1);
                phieuthu.Size = new Size(900, 550);
                phieuthu.ShowDialog();
            }
            else
            {
                frmInPhieuThuBanLe phieuthu = new frmInPhieuThuBanLe(dataGridView1);
                phieuthu.Size = new Size(900, 550);
                phieuthu.ShowDialog();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataRowView row = (DataRowView)bindingNavigator1.BindingSource.Current;
            //txtHoTen.Text = row["HO_TEN"].ToString();
            //txtDiaChi.Text = row["DIA_CHI"].ToString();
            //txtSDT.Text = row["DIEN_THOAI"].ToString();
            //toolLuu.Enabled = true;
            //btnClear.Enabled = true;
        }
    }
}
