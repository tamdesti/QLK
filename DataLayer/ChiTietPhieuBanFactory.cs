using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace QuanLyKho.DataLayer
{
    public class ChiTietPhieuBanFactory
    {
        DataService m_Ds = new DataService();

      

        public DataTable LayChiTietPhieuBan(String idPhieuBan)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM CHI_TiET_PHIEU_BAN WHERE ID = @id ORDER BY ID DESC");
            cmd.Parameters.Add("id", OleDbType.VarChar , 50).Value = idPhieuBan;
            m_Ds.Load(cmd);
            return m_Ds;
        }

        public DataTable LayChiTietPhieuBan(DateTime dtNgayBan)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT CT.* FROM CHI_TiET_PHIEU_BAN CT INNER JOIN PHIEU_BAN PB ON CT.ID_PHIEU_BAN = PB.ID " +
                    " WHERE PB.NGAY_BAN = @ngayban");
            cmd.Parameters.Add("ngayban", OleDbType.Date).Value = dtNgayBan;
            m_Ds.Load(cmd);
            return m_Ds;
        }

        public DataTable LayChiTietPhieuBan(int thang, int nam)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT CT.* FROM CHI_TiET_PHIEU_BAN CT INNER JOIN PHIEU_BAN PB ON CT.ID_PHIEU_BAN = PB.ID " +
                    " WHERE MONTH(PB.NGAY_BAN) = @thang AND YEAR(PB.NGAY_BAN)= @nam");
            cmd.Parameters.Add("thang", OleDbType.Integer).Value = thang;
            cmd.Parameters.Add("nam", OleDbType.Integer).Value = nam;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable DanhsachChiTietPhieuBan(String sp)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT CTPB.*, SP.ID_DON_VI_TINH FROM CHI_TiET_PHIEU_BAN CTPB INNER JOIN SAN_PHAM SP ON CTPB.ID_SAN_PHAM = SP.ID WHERE ID_PHIEU_BAN=@id ORDER BY CTPB.ID DESC");
            cmd.Parameters.Add("id", OleDbType.VarChar, 50).Value = sp;
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public int ThemChiTietPhieuBan(DataRow row)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO CHI_TIET_PHIEU_BAN VALUES(@ID, @PB, @SP, @SoLuong, @DonGia, @ThanhTien, @Kho, @NgayBan)");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = row["ID"].ToString();
            cmd.Parameters.Add("PB", OleDbType.VarChar, 50).Value = row["ID_PHIEU_BAN"].ToString();
            cmd.Parameters.Add("SP", OleDbType.VarChar, 50).Value = row["ID_SAN_PHAM"].ToString();
            cmd.Parameters.Add("SoLuong", OleDbType.Integer).Value = Convert.ToInt32(row["SO_LUONG"].ToString());
            cmd.Parameters.Add("DonGia", OleDbType.Integer).Value = Convert.ToInt32(row["DON_GIA"].ToString());
            cmd.Parameters.Add("ThanhTien", OleDbType.Double).Value = Convert.ToDouble(row["THANH_TIEN"].ToString());
            cmd.Parameters.Add("Kho", OleDbType.VarChar, 50).Value = row["ID_KHO"].ToString();
            cmd.Parameters.Add("NgayBan", OleDbType.Date).Value = Convert.ToDateTime(row["NGAY_BAN"].ToString());
            return m_Ds.ExecuteNoneQuery(cmd);
        }
        public void XoaChiTietPhieuBan(String ID)
        {
            OleDbCommand cmd = new OleDbCommand("DELETE FROM CHI_TIET_PHIEU_BAN WHERE ID = @ID");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = ID;
            m_Ds.ExecuteNoneQuery(cmd);
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
