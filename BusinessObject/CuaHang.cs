using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.BusinessObject
{
    public class CuaHang
    {
        private long m_NgayBaoHetHan;
        public long NgayBaoHetHan
        {
            get { return m_NgayBaoHetHan; }
            set { m_NgayBaoHetHan = value; }
        }
        private long m_NgayTraNhaCungCap;
        public long NgayTraNhaCungCap
        {
            get { return m_NgayTraNhaCungCap; }
            set { m_NgayTraNhaCungCap = value; }
        }
    }
}
