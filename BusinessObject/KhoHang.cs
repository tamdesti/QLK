using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.BusinessObject
{
    class KhoHang
    {
        public KhoHang() { }
        public KhoHang(String id)
        {
            m_Id = id;
        }
        public KhoHang(String id, String tenkho)
        {
            m_Id = id;
            m_TenKho = tenkho;
        }
        private String m_Id;

        public String Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }
        private String m_TenKho;

        public String TenKho
        {
            get { return m_TenKho; }
            set { m_TenKho = value; }
        }
        private String m_DiaChiKho;

        public String DiaChiKho
        {
            get { return m_DiaChiKho; }
            set { m_DiaChiKho = value; }
        }
    }
}
