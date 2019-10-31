using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace QuanLyKho.DataLayer
{
    public class NhaCungCapFactory
    {
        DataService m_Ds = new DataService();

        public DataTable DanhsachNCC()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM NHA_CUNG_CAP ORDER BY HO_TEN");
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable TimDiaChi(String diachi)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM NHA_CUNG_CAP WHERE DIA_CHI LIKE '%' + @diachi + '%' ");
            cmd.Parameters.Add("diachi", OleDbType.VarChar).Value = diachi;
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable TimHoTen(String hoten)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM NHA_CUNG_CAP WHERE HO_TEN LIKE '%' + @hoten + '%' ");
            cmd.Parameters.Add("hoten", OleDbType.VarChar).Value = hoten;
            m_Ds.Load(cmd);

            return m_Ds;
        }

        public DataTable LayNCC(String id)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM NHA_CUNG_CAP WHERE ID = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar,50).Value = id;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable LayNCCTuTen(String Ten)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM NHA_CUNG_CAP WHERE HO_TEN = @ten");
            cmd.Parameters.Add("ten", OleDbType.VarChar, 50).Value = Ten;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataRow NewRow()
        {
            return m_Ds.NewRow();
        }
        public void Add(DataRow row)
        {
            m_Ds.Rows.Add(row);
        }
        public bool Save()
        {
            return m_Ds.ExecuteNoneQuery() > 0;
        }
        public int ThemNhaCungCap(DataRow row)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO NHA_CUNG_CAP VALUES(@ID, @Ten, @DiaChi, @DienThoai, @HanNo)");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = row["ID"].ToString();
            cmd.Parameters.Add("Ten", OleDbType.VarChar, 50).Value = row["HO_TEN"].ToString();
            cmd.Parameters.Add("DiaChi", OleDbType.VarChar, 50).Value = row["DIA_CHI"].ToString();
            cmd.Parameters.Add("DienThoai", OleDbType.VarChar, 50).Value = row["DIEN_THOAI"].ToString();
            cmd.Parameters.Add("HanNo", OleDbType.Integer).Value = Convert.ToInt32(row["THOI_HAN_NO"].ToString());
            return m_Ds.ExecuteNoneQuery(cmd);
        }
        public void XoaNhaCungCap(String ID)
        {
            OleDbCommand cmd = new OleDbCommand("DELETE FROM NHA_CUNG_CAP WHERE ID = @ID");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = ID;
            m_Ds.ExecuteNoneQuery(cmd);
        }
    }
}
