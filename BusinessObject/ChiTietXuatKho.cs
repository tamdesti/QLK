using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.BusinessObject
{
    class ChiTietXuatKho
    {
        private int m_STT;
        public int STT
        {
            get { return m_STT; }
            set { m_STT = value; }
        }
        private String m_TenKhachHang;

        public String TenKhachHang
        {
            get { return m_TenKhachHang; }
            set { m_TenKhachHang = value; }
        }
        private String m_MatHang;

        public String MatHang
        {
            get { return m_MatHang; }
            set { m_MatHang = value; }
        }
        private DateTime m_NgayBan;
        public DateTime NgayBan
        {
            get { return m_NgayBan; }
            set { m_NgayBan = value; }
        }
        private double m_DonGia;
        public double DonGia
        {
            get { return m_DonGia; }
            set { m_DonGia = value; }
        }
        private double m_TienHang;
        public double TienHang
        {
            get { return m_TienHang; }
            set { m_TienHang = value; }
        }
        private int m_SoLuongBan;

        public int SoLuongBan
        {
            get { return m_SoLuongBan; }
            set { m_SoLuongBan = value; }
        }
        private String m_NgayLapPhieu;

        public String NgayLapPhieu
        {
            get { return m_NgayLapPhieu; }
            set { m_NgayLapPhieu = value; }
        }
    }
}
