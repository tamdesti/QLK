using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.BusinessObject
{
    public class PhieuNhap
    {
        public PhieuNhap() { }
        public PhieuNhap(String id)
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

        public DateTime NgayNhap
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
        private double m_Datra;

        public double DaTra
        {
            get { return m_Datra; }
            set { m_Datra = value; }
        }

        private double m_ConNo;

        public double ConNo
        {
            get { return m_ConNo; }
            set { m_ConNo = value; }
        }

        private NhaCungCap m_NCC;

        public NhaCungCap NhaCungCap
        {
            get { return m_NCC; }
            set { m_NCC = value; }
        }

	

        private IList<ChiTietPhieuNhap> m_ChiTiet;

        public IList<ChiTietPhieuNhap> ChiTiet
        {
            get { return m_ChiTiet; }
            set { m_ChiTiet = value; }
        }
        private double m_NoCu;

        public double NoCu
        {
            get { return m_NoCu; }
            set { m_NoCu = value; }
        }

    }
}
