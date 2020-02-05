using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace QuanLyKho.DataLayer
{
    public class DonViTinhFactory
    {
        DataService m_Ds = new DataService();

        public DataTable DanhsachDVT()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM DON_VI_TINH ORDER BY TEN_DON_VI");
            m_Ds.Load(cmd);

            return m_Ds;
        }


        public DataTable LayDVT(int id)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM DON_VI_TINH WHERE ID = @id");
            cmd.Parameters.Add("id", OleDbType.Integer).Value = id;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable LayDVT(string ten)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM DON_VI_TINH WHERE TEN_DON_VI = @ten");
            cmd.Parameters.Add("ten", OleDbType.VarChar, 50).Value = ten;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public int ThemDonViTinh(DataRow row)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO DON_VI_TINH VALUES(@ID, @Ten)");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = row["ID"].ToString();
            cmd.Parameters.Add("Ten", OleDbType.VarChar, 50).Value = row["TEN_DON_VI"].ToString();
            return m_Ds.ExecuteNoneQuery(cmd);
        }
        public void XoaDonViTinh(String ID)
        {
            OleDbCommand cmd = new OleDbCommand("DELETE FROM DON_VI_TINH WHERE ID = @ID");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = ID;
            m_Ds.ExecuteNoneQuery(cmd);
        }
        public bool Save()
        {
            return m_Ds.ExecuteNoneQuery() > 0;
        }
        public DataRow NewRow()
        {
            return m_Ds.NewRow();
        }
        public void Add(DataRow row)
        {
            m_Ds.Rows.Add(row);
        }
    }
}
