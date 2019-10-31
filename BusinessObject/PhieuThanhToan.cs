using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.BusinessObject
{
    public class PhieuThanhToan
    {
        public PhieuThanhToan() { }
        public PhieuThanhToan(String id)
        {
            m_Id = id;
        }
        private String m_Id;

        public String Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }
        private DateTime m_NgayNhap;

        public DateTime NgayThanhToan
        {
            get { return m_NgayNhap; }
            set { m_NgayNhap = value; }
        }
        private double m_TongTien;

        public double TongTien
        {
            get { return m_TongTien; }
            set { m_TongTien = value; }
        }

        private String m_KH;

        public String KhachHang
        {
            get { return m_KH; }
            set { m_KH = value; }
        }

        private String m_GhiChu;

        public String GhiChu
        {
            get { return m_GhiChu; }
            set { m_GhiChu = value; }
        }
        private String m_PB;

        public String PhieuBan
        {
            get { return m_PB; }
            set { m_PB = value; }
        }


    }
}
