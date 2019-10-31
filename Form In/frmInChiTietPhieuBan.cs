using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class frmInChiTietPhieuBan : Form
    {
        QuanLyKho.BusinessObject.PhieuBan m_PhieuBan;
        public frmInChiTietPhieuBan(QuanLyKho.BusinessObject.PhieuBan ph)
        {
            InitializeComponent();            
            m_PhieuBan = ph;
        }
        IList<BusinessObject.InChiTietPhieuBan> listIn = new List<BusinessObject.InChiTietPhieuBan>();
        void GetData()
        {
            int i = 1;
            foreach (BusinessObject.ChiTietPhieuBan ct in m_PhieuBan.ChiTiet)
            {
                BusinessObject.InChiTietPhieuBan inchitiet = new BusinessObject.InChiTietPhieuBan();
                inchitiet.STT = i;                
                inchitiet.IDPhieuBan = m_PhieuBan.Id;
                inchitiet.NgayLapPhieu = NgayThanhChu(m_PhieuBan.NgayBan);
                inchitiet.TenSanPham = ct.SanPham.TenSanPham;
                inchitiet.TenDonViTinh = ct.SanPham.DonViTinh.Ten;
                inchitiet.NoCu = m_PhieuBan.NoCu;
                inchitiet.TongTien = m_PhieuBan.TongTien;
                inchitiet.DaTra = m_PhieuBan.DaTra;
                inchitiet.ConNo = m_PhieuBan.ConNo;
                inchitiet.DonGia = ct.DonGia;
                inchitiet.ThanhTien = ct.ThanhTien;
                inchitiet.SoLuong = ct.SoLuong;
                inchitiet.TenDaiLy = m_PhieuBan.KhachHang.TenDaiLy;
                inchitiet.DiaChi = m_PhieuBan.KhachHang.DiaChi;
                inchitiet.DienThoai = m_PhieuBan.KhachHang.DienThoai;
                listIn.Add(inchitiet);
                i++;
            }
            
        }
        private string NgayThanhChu(DateTime dt)
        {
            return "(Ngày " + dt.Day + " Tháng " + (dt.Month < 10 ? ("0" + dt.Month) : dt.Month.ToString()) + " Năm " + dt.Year +  ")";
        }
        private void frmInChiTietPhieuBan_Load(object sender, EventArgs e)
        {
            GetData();
            this.InChiTietPhieuBanBindingSource.DataSource = listIn;
            this.reportViewer1.RefreshReport();
        }
    }
}
