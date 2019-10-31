using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.BusinessObject
{
    public class PhieuChi
    {
        public PhieuChi() { }
        public PhieuChi(String id)
        {
            m_Id = id;
        }
        private String m_Id;

        public String Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }
        private DateTime m_NgayChi;

        public DateTime NgayChi
        {
            get { return m_NgayChi; }
            set { m_NgayChi = value; }
        }
        private double m_TongTien;

        public double TongTien
        {
            get { return m_TongTien; }
            set { m_TongTien = value; }
        }

        private String m_PhieuNhap;

        public String PhieuNhap
        {
            get { return m_PhieuNhap; }
            set { m_PhieuNhap = value; }
        }

        private String m_GhiChu;

        public String GhiChu
        {
            get { return m_GhiChu; }
            set { m_GhiChu = value; }
        }
	

	
    }
}
