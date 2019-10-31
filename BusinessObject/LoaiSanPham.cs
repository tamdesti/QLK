using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.BusinessObject
{
    public class LoaiSanPham
    {
        public LoaiSanPham() { }
        public LoaiSanPham(int id)
        {
            m_ID = id;
        }
        public LoaiSanPham(int id, string ten)
        {
            m_ID = id;
            m_Ten = ten;
        }
        private int m_ID;

        public int Id
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
        private String m_Ten;

        public String Ten
        {
            get { return m_Ten; }
            set { m_Ten = value; }
        }
        private String m_NCC;

        public String NhaCungCap
        {
            get { return m_NCC; }
            set { m_NCC = value; }
        }

    }
}
