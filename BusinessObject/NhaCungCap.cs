using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.BusinessObject
{
    public class NhaCungCap
    {
        public NhaCungCap() { }
        public NhaCungCap(String id)
        {
            m_Id = id;
        }
        public NhaCungCap(String id, String hoten)
        {
            m_Id = id;
            m_HoTen = hoten;
        }
        private String m_Id;

        public String Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }
        private String m_HoTen;

        public String HoTen
        {
            get { return m_HoTen; }
            set { m_HoTen = value; }
        }
        private String m_DiaChi;

        public String DiaChi
        {
            get { return m_DiaChi; }
            set { m_DiaChi = value; }
        }
        private String m_DienThoai;

        public String DienThoai
        {
            get { return m_DienThoai; }
            set { m_DienThoai = value; }
        }
        private int m_thoihanno;
        public int ThoiHanNo
        {
            get { return m_thoihanno; }
            set { m_thoihanno = value; }
        }

    }
}
