using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace QuanLyKho.DataLayer
{
    public class PhieuThanhToanFactory
    {
        DataService m_Ds = new DataService();

        public DataTable DanhsachPhieuThanhToan()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_THU");
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable DanhsachPhieuThanhToanTheoPhieuBan(String IDPhieuBan)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_THU WHERE ID_PHIEU_BAN=@PB");
            cmd.Parameters.Add("PB", OleDbType.VarChar, 50).Value = IDPhieuBan;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable LayPhieuThanhToan(String id)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_THU WHERE ID = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar,50).Value = id;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public static long LayTongTien(String kh, int thang, int nam)
        {
            DataService ds = new DataService();
            OleDbCommand cmd = new OleDbCommand("SELECT SUM(TONG_TIEN) FROM PHIEU_THU WHERE ID_KHACH_HANG = @kh AND MONTH(NGAY_THANH_TOAN)=@thang AND YEAR(NGAY_THANH_TOAN)= @nam");
            cmd.Parameters.Add("kh", OleDbType.VarChar, 50).Value = kh;
            cmd.Parameters.Add("thang", OleDbType.Integer).Value = thang;
            cmd.Parameters.Add("nam", OleDbType.Integer).Value = nam;

            object obj = ds.ExecuteScalar(cmd);
            
            if (obj == null)
                return 0;
            else
                return Convert.ToInt64(obj);
        }
        public int ThemPhieuThanhToan(BusinessObject.PhieuThanhToan PTT)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO PHIEU_THU VALUES(@ID, @NgayThanhToan, @TongTien, @KH, @GhiChu, @PB)");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = PTT.Id;
            cmd.Parameters.Add("NgayThanhToan", OleDbType.Date).Value = PTT.NgayThanhToan;
            cmd.Parameters.Add("TongTien", OleDbType.Double).Value = PTT.TongTien;
            cmd.Parameters.Add("KH", OleDbType.VarChar, 50).Value = PTT.KhachHang;
            cmd.Parameters.Add("GhiChu", OleDbType.VarChar, 50).Value = PTT.GhiChu;
            cmd.Parameters.Add("PB", OleDbType.VarChar, 50).Value = PTT.PhieuBan;
            return m_Ds.ExecuteNoneQuery(cmd);
        }
        public int XoaPhieuThanhToanTheoIDPhieuBan(String IDPhieuBan)
        {
            OleDbCommand cmd = new OleDbCommand("DELETE FROM PHIEU_THU WHERE ID_PHIEU_BAN = @ID");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = IDPhieuBan;
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
