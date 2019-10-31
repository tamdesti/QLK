using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.BusinessObject
{
    public class PhieuBan
    {
        private String m_Id;

        public String Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        private KhachHang m_KH;

        public KhachHang KhachHang
        {
            get { return m_KH; }
            set { m_KH = value; }
        }

        private DateTime m_NgayBan;

        public DateTime NgayBan
        {
            get { return m_NgayBan; }
            set { m_NgayBan = value; }
        }
        private double m_NoCu;

        public double NoCu
        {
            get { return m_NoCu; }
            set { m_NoCu = value; }
        }
        private double m_TongTien;

        public double TongTien
        {
            get { return m_TongTien; }
            set { m_TongTien = value; }
        }
        private double m_DaTra;

        public double DaTra
        {
            get { return m_DaTra; }
            set { m_DaTra = value; }
        }
        private double m_ConNo;

        public double ConNo
        {
            get { return m_ConNo; }
            set { m_ConNo = value; }
        }

        private IList<ChiTietPhieuBan> m_ChiTiet;

        public IList<ChiTietPhieuBan> ChiTiet
        {
            get { return m_ChiTiet; }
            set { m_ChiTiet = value; }
        }

	
    }
}
