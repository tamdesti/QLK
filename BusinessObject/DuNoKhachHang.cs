using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.BusinessObject
{
    public class DuNoKhachHang
    {
        private KhachHang m_KH;

        public KhachHang KhachHang
        {
            get { return m_KH; }
            set { m_KH = value; }
        }
        private int m_Thang;

        public int Thang
        {
            get { return m_Thang; }
            set { m_Thang = value; }
        }
        private int m_Nam;

        public int Nam
        {
            get { return m_Nam; }
            set { m_Nam = value; }
        }
        private decimal m_DauKy;

        public decimal DauKy
        {
            get { return m_DauKy; }
            set { m_DauKy = value; }
        }
        private decimal m_PhatSinh;

        public decimal PhatSinh
        {
            get { return m_PhatSinh; }
            set { m_PhatSinh = value; }
        }

        private decimal m_DaTra;

        public decimal DaTra
        {
            get { return m_DaTra; }
            set { m_DaTra = value; }
        }
        private decimal m_CuoiKy;

        public decimal CuoiKy
        {
            get { return m_CuoiKy; }
            set { m_CuoiKy = value; }
        }


    }
}
