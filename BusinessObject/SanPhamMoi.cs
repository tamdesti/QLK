using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.BusinessObject
{
    class SanPhamMoi
    {
        public SanPhamMoi() { }

        private String m_TENHANG;

        public String TENHANG
        {
            get { return TENHANG; }
            set { TENHANG = value; }
        }
        private String m_DVTINH;

        public String DVTINH
        {
            get { return m_DVTINH; }
            set { m_DVTINH = value; }
        }
        private String m_MAHANG;

        public String MAHANG
        {
            get { return m_MAHANG; }
            set { m_MAHANG = value; }
        }
        private String m_QUICACH;

        public String QUICACH
        {
            get { return m_QUICACH; }
            set { m_QUICACH = value; }
        }
        private int m_SOLUONGTON;

        public int SOLUONGTON
        {
            get { return m_SOLUONGTON; }
            set { m_SOLUONGTON = value; }
        }
        private decimal m_DONGIABAN;

        public decimal DONGIABAN
        {
            get { return m_DONGIABAN; }
            set { m_DONGIABAN = value; }
        }
    }
}
