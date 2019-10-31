using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;


namespace QuanLyKho.DataLayer
{
    class SanPhamMoiFactory
    {
        DataService m_Ds = new DataService();

        public DataTable DanhsachSanPham()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM HANGHOA");
            m_Ds.Load(cmd);
            return m_Ds;
        }
    }
}
