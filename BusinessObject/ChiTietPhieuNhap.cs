using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.BusinessObject
{
    public class ChiTietPhieuNhap
    {
        public ChiTietPhieuNhap() {
        }
        public ChiTietPhieuNhap(String id, int so_luong)
        {
            m_Id = id;
            m_SoLuong = so_luong;
        }

        private String m_Id;

        public String Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        private SanPham m_SanPham;

        public SanPham SanPham
        {
            get { return m_SanPham; }
            set { m_SanPham = value; }
        }
        private double m_GiaNhap;

        public double GiaNhap
        {
            get { return m_GiaNhap; }
            set { m_GiaNhap = value; }
        }
        private int m_SoLuong;

        public int SoLuong
        {
            get { return m_SoLuong; }
            set { m_SoLuong = value; }
        }
        private double m_ThanhTien;

        public double ThanhTien
        {
            get { return m_ThanhTien; }
            set { m_ThanhTien = value; }
        }
        private DateTime m_NgayNhap;

        public DateTime NgayNhap
        {
            get { return m_NgayNhap; }
            set { m_NgayNhap = value; }
        }
        
        private PhieuNhap m_PhieuNhap;

        public PhieuNhap PhieuNhap
        {
            get { return m_PhieuNhap; }
            set { m_PhieuNhap = value; }
        }

        private string m_KhoHang;
        public string KhoHang
        {
            get { return m_KhoHang; }
            set { m_KhoHang = value; }
        }

    }
}
