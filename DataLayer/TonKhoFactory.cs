using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using QuanLyKho.BusinessObject;

namespace QuanLyKho.DataLayer
{
    class TonKhoFactory
    {
        DataService m_Ds = new DataService();
        public int ThemTonKho(DataRow row)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO TON_KHO VALUES(@SP, @Kho, @SoLuong)");
            cmd.Parameters.Add("SP", OleDbType.VarChar, 50).Value = row["ID_SAN_PHAM"].ToString();
            cmd.Parameters.Add("Kho", OleDbType.VarChar, 50).Value = row["ID_KHO"].ToString();
            cmd.Parameters.Add("SoLuong", OleDbType.Integer).Value = Convert.ToInt32(row["SO_LUONG"].ToString());
            return m_Ds.ExecuteNoneQuery(cmd);
        }
        public int ThemTonKho(TonKho TK)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO TON_KHO VALUES(@SP, @Kho, @SoLuong)");
            cmd.Parameters.Add("SP", OleDbType.VarChar, 50).Value = TK.SanPham.Id;
            cmd.Parameters.Add("Kho", OleDbType.VarChar, 50).Value = TK.KhoHang;
            cmd.Parameters.Add("SoLuong", OleDbType.Integer).Value = TK.SoLuongTon;
            return m_Ds.ExecuteNoneQuery(cmd);
        }
        public DataTable LayTonKho(string IDSP, string IDKHO)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM TON_KHO WHERE (ID_SAN_PHAM=@IDSP AND ID_KHO=@IDKHO)");
            cmd.Parameters.Add("IDSP", OleDbType.VarChar, 50).Value = IDSP;
            cmd.Parameters.Add("IDKHO", OleDbType.VarChar, 50).Value = IDKHO;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public long LaySoLuongTon(string IDSP, string IDKHO)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT SO_LUONG_TON " +
                                                 "FROM TON_KHO " +
                                                 "WHERE (ID_KHO=@IDKHO AND ID_SAN_PHAM=@IDSP);");
            cmd.Parameters.Add("IDKHO", OleDbType.VarChar, 50).Value = IDKHO;
            cmd.Parameters.Add("IDSP", OleDbType.VarChar, 50).Value = IDSP;
            return Convert.ToInt64(m_Ds.ExecuteScalar(cmd));
        }
        public void CapNhatSoLuongTon_Them(string IDSP, string IDKHO, decimal so_luong)
        {
            DataService ds = new DataService();
            OleDbCommand cmd = new OleDbCommand("UPDATE TON_KHO SET SO_LUONG_TON = SO_LUONG_TON + @so WHERE (ID_KHO=@IDKHO AND ID_SAN_PHAM=@IDSP)");
            cmd.Parameters.Add("so", OleDbType.Integer).Value = so_luong;
            cmd.Parameters.Add("IDKHO", OleDbType.VarChar, 50).Value = IDKHO;
            cmd.Parameters.Add("IDSP", OleDbType.VarChar, 50).Value = IDSP;
            ds.ExecuteNoneQuery(cmd);
        }
        public void CapNhatSoLuongTon(string IDSP, string IDKHO, decimal so_luong)
        {
            DataService ds = new DataService();
            OleDbCommand cmd = new OleDbCommand("UPDATE TON_KHO SET SO_LUONG_TON = @so WHERE (ID_KHO=@IDKHO AND ID_SAN_PHAM=@IDSP)");
            cmd.Parameters.Add("so", OleDbType.Integer).Value = so_luong;
            cmd.Parameters.Add("IDKHO", OleDbType.VarChar, 50).Value = IDKHO;
            cmd.Parameters.Add("IDSP", OleDbType.VarChar, 50).Value = IDSP;
            ds.ExecuteNoneQuery(cmd);
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
    }
}
