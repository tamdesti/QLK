using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.BusinessObject
{
    class InKhoanPhaiThu
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
        private String m_DiaChi;

        public String DiaChi
        {
            get { return m_DiaChi; }
            set { m_DiaChi = value; }
        }
        private double m_NoDauKy;
        public double NoDauKy
        {
            get { return m_NoDauKy; }
            set { m_NoDauKy = value; }
        }
        private double m_NoHienTai;
        public double NoHienTai
        {
            get { return m_NoHienTai; }
            set { m_NoHienTai = value; }
        }
        private double m_PhatSinhTang;
        public double PhatSingTang
        {
            get { return m_PhatSinhTang; }
            set { m_PhatSinhTang = value; }
        }
        private double m_PhatSinhGiam;
        public double PhatSinhGiam
        {
            get { return m_PhatSinhGiam; }
            set { m_PhatSinhGiam = value; }
        }
        private String m_NgayLapPhieu;

        public String NgayLapPhieu
        {
            get { return m_NgayLapPhieu; }
            set { m_NgayLapPhieu = value; }
        }
    }
}
