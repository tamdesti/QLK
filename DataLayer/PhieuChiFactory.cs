using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace QuanLyKho.DataLayer
{
    public class PhieuChiFactory
    {
        DataService m_Ds = new DataService();
        public DataTable DanhsachPhieuChiTheoPhieuNhap(String IDPhieuNhap)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_CHI WHERE ID_PHIEU_NHAP=@PN");
            cmd.Parameters.Add("PN", OleDbType.VarChar, 50).Value = IDPhieuNhap;
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public int ThemPhieuChi(BusinessObject.PhieuChi PC)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO PHIEU_CHI VALUES(@ID, @NgayChi, @TongTien, @PN, @GhiChu)");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = PC.Id;
            cmd.Parameters.Add("NgayChi", OleDbType.Date).Value = PC.NgayChi;
            cmd.Parameters.Add("TongTien", OleDbType.Double).Value = PC.TongTien;
            cmd.Parameters.Add("PN", OleDbType.VarChar, 50).Value = PC.PhieuNhap;
            cmd.Parameters.Add("GhiChu", OleDbType.VarChar, 50).Value = PC.GhiChu;
            return m_Ds.ExecuteNoneQuery(cmd);
        }
        public int XoaPhieuChiTheoIDPhieuNhap(String IDPhieuNhap)
        {
            OleDbCommand cmd = new OleDbCommand("DELETE FROM PHIEU_CHI WHERE ID_PHIEU_NHAP = @ID");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = IDPhieuNhap;
            return m_Ds.ExecuteNoneQuery(cmd);
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
