using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class frmInChiTietPhieuBanLe : Form
    {
        QuanLyKho.BusinessObject.PhieuBan m_PhieuBan;
        public frmInChiTietPhieuBanLe(QuanLyKho.BusinessObject.PhieuBan ph)
        {
            InitializeComponent();
            m_PhieuBan = ph;
        }
        IList<BusinessObject.InChiTietPhieuBan> listIn = new List<BusinessObject.InChiTietPhieuBan>();
        void GetData()
        {
            int i = 1;
            double tongsoluong = 0;
            Num2Str num2Str = new Num2Str();
            foreach (BusinessObject.ChiTietPhieuBan ct in m_PhieuBan.ChiTiet)
            {
                BusinessObject.InChiTietPhieuBan inchitiet = new BusinessObject.InChiTietPhieuBan();
                inchitiet.STT = i;
                i++;
                inchitiet.IDPhieuBan = m_PhieuBan.Id;
                inchitiet.NgayLapPhieu = NgayThanhChu(m_PhieuBan.NgayBan);
                inchitiet.TenSanPham = ct.SanPham.TenSanPham;
                if (ct.SanPham.Loai != "Mài") tongsoluong += ct.SoLuong;
                inchitiet.TenDonViTinh = ct.SanPham.DonViTinh.Ten;
                inchitiet.NoCu = m_PhieuBan.NoCu;
                inchitiet.TongTien = m_PhieuBan.TongTien;
                inchitiet.DaTra = m_PhieuBan.DaTra;
                inchitiet.ConNo = m_PhieuBan.ConNo;
                inchitiet.DonGia = ct.DonGia;
                inchitiet.ThanhTien = ct.ThanhTien;
                inchitiet.SoLuong = ct.SoLuong;
                inchitiet.HoTen = m_PhieuBan.KhachHang.HoTen;
                inchitiet.DiaChi = m_PhieuBan.KhachHang.DiaChi;
                inchitiet.DienThoai = m_PhieuBan.KhachHang.DienThoai;
                inchitiet.KhoiLuong = ct.SanPham.Dai * 0.001 * ct.SanPham.Rong * 0.001 * 2.4 * ct.SanPham.Li * ct.SoLuong;
                if (inchitiet.DaTra > 0)
                    inchitiet.TienBangChu = num2Str.NumberToString(inchitiet.ConNo.ToString());
                else inchitiet.TienBangChu = num2Str.NumberToString((inchitiet.NoCu + inchitiet.TongTien).ToString());
                listIn.Add(inchitiet);
            }
            foreach (BusinessObject.InChiTietPhieuBan ct in listIn)
            {
                ct.TongSoLuong = tongsoluong;
            }
        }
        private string NgayThanhChu(DateTime dt)
        {
            return "(Ngày " + dt.Day + " Tháng " + (dt.Month < 10 ? ("0" + dt.Month) : dt.Month.ToString()) + " Năm " + dt.Year + ")";
        }
        private void frmInChiTietPhieuBanLe_Load(object sender, EventArgs e)
        {
            GetData();
            this.InChiTietPhieuBanBindingSource.DataSource = listIn;
            this.reportViewer1.RefreshReport();
        }
    }
}
