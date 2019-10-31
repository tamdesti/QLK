using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.BusinessObject
{
    public class KhachHang
    {
        public KhachHang() { }
        public KhachHang(String id)
        {
            m_Id = id;
        }
        public KhachHang(String id, String hoten)
        {
            m_Id = id;
            m_HoTen = hoten;
        }
        public KhachHang(String id, String hoten, string daily)
        {
            m_Id = id;
            m_HoTen = hoten;
            m_TenDaiLy = daily;
        }
        private String m_Id;

        public String Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }
        private String m_HoTen;

        public String HoTen
        {
            get { return m_HoTen; }
            set { m_HoTen = value; }
        }
        private String m_DiaChi;

        public String DiaChi
        {
            get { return m_DiaChi; }
            set { m_DiaChi = value; }
        }
        private String m_DienThoai;

        public String DienThoai
        {
            get { return m_DienThoai; }
            set { m_DienThoai = value; }
        }
        private bool m_LoaiKH;

        public bool LoaiKH
        {
            get { return m_LoaiKH; }
            set { m_LoaiKH = value; }
        }
        private String m_TenDaiLy;
        public string TenDaiLy
        {
            get { return m_TenDaiLy; }
            set { m_TenDaiLy = value; }
        }
    }
}
