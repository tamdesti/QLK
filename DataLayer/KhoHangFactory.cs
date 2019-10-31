using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace QuanLyKho.DataLayer
{
    public class KhoHangFactory
    {
        DataService m_Ds = new DataService();

        public DataTable DanhSachKho()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM KHO_HANG ORDER BY TEN_KHO");
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public long LaySoLuongTonByKho(String IDSP, String IDKHO)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT Sum(CHI_TIET_PHIEU_NHAP.SO_LUONG_TON) " +
                                                    "FROM CHI_TIET_PHIEU_NHAP " +
                                                    "WHERE (((CHI_TIET_PHIEU_NHAP.ID_KHO)=@IDKHO) AND ((CHI_TIET_PHIEU_NHAP.ID_SAN_PHAM)=@IDSP));");
            cmd.Parameters.Add("IDKHO", OleDbType.VarChar, 50).Value = IDKHO;
            cmd.Parameters.Add("IDSP", OleDbType.VarChar, 50).Value = IDSP;
            return Convert.ToInt64(m_Ds.ExecuteScalar(cmd));
        }
        public DataTable LayChiTietPhieuNhapConHang(String IDSP, String IDKHO)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM CHI_TIET_PHIEU_NHAP WHERE ID_SAN_PHAM = @SP AND ID_KHO=@KHO AND SO_LUONG_TON > 0 ORDER BY ID");
            cmd.Parameters.Add("SP", OleDbType.VarChar, 50).Value = IDSP;
            cmd.Parameters.Add("KHO", OleDbType.VarChar, 50).Value = IDKHO;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable LayKho(int id)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM KHO_HANG WHERE ID = @id");
            cmd.Parameters.Add("id", OleDbType.Integer).Value = id;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable LayKho(string ten)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM KHO_HANG WHERE TEN_KHO = @ten");
            cmd.Parameters.Add("ten", OleDbType.VarChar, 50).Value = ten;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public int ThemKho(DataRow row)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO KHO_HANG VALUES(@ID, @Ten, @DiaChi)");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = row["ID"].ToString();
            cmd.Parameters.Add("Ten", OleDbType.VarChar, 50).Value = row["TEN_KHO"].ToString();
            cmd.Parameters.Add("Ten", OleDbType.VarChar, 50).Value = row["DIA_CHI_KHO"].ToString();
            return m_Ds.ExecuteNoneQuery(cmd);
        }
        public void XoaKho(String ID)
        {
            OleDbCommand cmd = new OleDbCommand("DELETE FROM KHO_HANG WHERE ID = @ID");
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
