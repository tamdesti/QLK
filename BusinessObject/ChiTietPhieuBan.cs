using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.BusinessObject
{
    public class ChiTietPhieuBan
    {
        private int m_ID;
        public int ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
        private PhieuBan m_PhieuBan;

        public PhieuBan PhieuBan
        {
            get { return m_PhieuBan; }
            set { m_PhieuBan = value; }
        }
        private SanPham m_SP;
        public SanPham SanPham
        {
            get { return m_SP; }
            set { m_SP = value; }
        }
        private int m_SoLuong;

        public int SoLuong
        {
            get { return m_SoLuong; }
            set { m_SoLuong = value; }
        }
        private double m_DonGia;

        public double DonGia
        {
            get { return m_DonGia; }
            set { m_DonGia = value; }
        }
        private double m_ThanhTien;

        public double ThanhTien
        {
            get { return m_ThanhTien; }
            set { m_ThanhTien = value; }
        }
        private string m_KhoHang;
        public string KhoHang
        {
            get { return m_KhoHang; }
            set { m_KhoHang = value; }
        }
        
    }
}
