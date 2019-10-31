using System;
using System.Collections.Generic;
using System.Text;


namespace QuanLyKho.BusinessObject
{
    public class TonKho
    {
        public TonKho(){
        }
        
        private String m_Id;

        private SanPham m_SanPham;

        public SanPham SanPham
        {
            get { return m_SanPham; }
            set { m_SanPham = value; }
        }
        
        private string m_KhoHang;
        public string KhoHang
        {
            get { return m_KhoHang; }
            set { m_KhoHang = value; }
        }

        private long m_SoLuongTon;
        public long SoLuongTon
        {
            get { return m_SoLuongTon; }
            set { m_SoLuongTon = value; }
        }
    }
}
