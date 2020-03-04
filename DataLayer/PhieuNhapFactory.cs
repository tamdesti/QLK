using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using QuanLyKho.BusinessObject;

namespace QuanLyKho.DataLayer
{
    public class PhieuNhapFactory
    {
        DataService m_Ds = new DataService();

        public void LoadSchema()
        {
           OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_NHAP WHERE ID='-1'");
            m_Ds.Load(cmd);

        }
        public DataTable DanhsachPhieuChi(DateTime fromDate, DateTime toDate)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT ID, NGAY_NHAP, NO_CU, TONG_TIEN, NO_CU + TONG_TIEN AS [Tổng tiền], DA_TRA, CON_NO, ID_NHA_CUNG_CAP FROM PHIEU_NHAP WHERE NGAY_NHAP BETWEEN @date1 AND @date2 ORDER BY ID DESC");
            cmd.Parameters.Add("@date1", OleDbType.Date).Value = fromDate.Date;
            cmd.Parameters.Add("@date2", OleDbType.Date).Value = toDate.Date;
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable DanhsachPhieuChiTuMaNCC(String MaNCC, DateTime fromDate, DateTime toDate)
        {
            if (MaNCC == "0")
            {
                return DanhsachPhieuChi(fromDate, toDate);
            }
            else
            {
                OleDbCommand cmd = new OleDbCommand("SELECT ID, NGAY_NHAP, NO_CU, TONG_TIEN, NO_CU + TONG_TIEN AS [Tổng tiền],  DA_TRA, CON_NO, ID_NHA_CUNG_CAP FROM PHIEU_NHAP WHERE ID_NHA_CUNG_CAP= '" + MaNCC + "' AND  NGAY_NHAP BETWEEN @date1 AND @date2 ORDER BY ID DESC");
                cmd.Parameters.Add("@date1", OleDbType.Date).Value = fromDate.Date;
                cmd.Parameters.Add("@date2", OleDbType.Date).Value = toDate.Date;
                m_Ds.Load(cmd);
                return m_Ds;
            }
        }
        public DataTable DanhsachPhieuNhap()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT ID, NGAY_NHAP, NO_CU, TONG_TIEN, NO_CU + TONG_TIEN AS [Tổng tiền], DA_TRA, CON_NO, ID_NHA_CUNG_CAP FROM PHIEU_NHAP WHERE TONG_TIEN > 0 ORDER BY ID DESC");
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable DanhsachPhieuNhapTuMaNCC(String MaNCC)
        {
            if (MaNCC == "0")
            {
                return DanhsachPhieuNhap();
            }
            else
            {
                OleDbCommand cmd = new OleDbCommand("SELECT ID, NGAY_NHAP, NO_CU, TONG_TIEN, NO_CU + TONG_TIEN AS [Tổng tiền],  DA_TRA, CON_NO, ID_NHA_CUNG_CAP FROM PHIEU_NHAP WHERE TONG_TIEN > 0 AND ID_NHA_CUNG_CAP= '" + MaNCC + "' ORDER BY ID DESC");
                m_Ds.Load(cmd);
                return m_Ds;
            }
        }
        //Dùng để lấy phiếu cuối nên không cần sắp xếp
        public DataTable DanhsachPhieuNhapTuNCC(string ID_NCC)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT ID, NGAY_NHAP, NO_CU, TONG_TIEN, NO_CU + TONG_TIEN AS [Tổng tiền], DA_TRA, CON_NO, ID_NHA_CUNG_CAP FROM PHIEU_NHAP WHERE ID_NHA_CUNG_CAP = '" + ID_NCC + "'");
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable DanhsachPhieuNhapConNo()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT PHIEU_NHAP.* FROM PHIEU_NHAP INNER JOIN NHA_CUNG_CAP ON NHA_CUNG_CAP.ID = PHIEU_NHAP.ID_NHA_CUNG_CAP ORDER BY PHIEU_NHAP.ID DESC");
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable DanhsachPhieuNhapConNo(String NCC)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT PHIEU_NHAP.*, NO_CU + TONG_TIEN AS [Tổng tiền] FROM PHIEU_NHAP INNER JOIN NHA_CUNG_CAP ON NHA_CUNG_CAP.ID = PHIEU_NHAP.ID_NHA_CUNG_CAP " + (NCC == "0" ? "" : "WHERE NHA_CUNG_CAP.ID= '" + NCC + "'") + " ORDER BY PHIEU_NHAP.ID DESC");
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable LayPhieuNhap(String id)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_NHAP WHERE ID = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar,50).Value = id;
            m_Ds.Load(cmd);
            return m_Ds;
        }

        public void ChangePhieuNhap(String id, double tongtien)
        {            
            OleDbCommand cmd = new OleDbCommand("UPDATE PHIEU_NHAP SET TONG_TIEN = @tongtien WHERE ID = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar).Value = id;
            cmd.Parameters.Add("tongtien", OleDbType.Integer).Value = tongtien;
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
        public int ThemPhieuNhap(DataRow row)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO PHIEU_NHAP VALUES(@ID, @NgayNhap, @NoCu, @TongTien, @DaTra, @ConNo, @NCC)");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = row["ID"].ToString();
            cmd.Parameters.Add("NgayNhap", OleDbType.Date).Value = Convert.ToDateTime(row["NGAY_NHAP"].ToString());
            cmd.Parameters.Add("NoCu", OleDbType.Double).Value = Convert.ToDouble(row["NO_CU"].ToString());
            cmd.Parameters.Add("TongTien", OleDbType.Double).Value = Convert.ToDouble(row["TONG_TIEN"].ToString());
            cmd.Parameters.Add("DaTra", OleDbType.Double).Value = Convert.ToDouble(row["DA_TRA"].ToString());
            cmd.Parameters.Add("ConNo", OleDbType.Double).Value = Convert.ToDouble(row["CON_NO"].ToString());
            cmd.Parameters.Add("NCC", OleDbType.VarChar, 50).Value = row["ID_NHA_CUNG_CAP"].ToString();
            return m_Ds.ExecuteNoneQuery(cmd);
        }
        public int ThemPhieuNhap(PhieuNhap PN)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO PHIEU_NHAP VALUES(@ID, @NgayNhap, @NoCu, @TongTien, @DaTra, @ConNo, @NCC)");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = PN.Id;
            cmd.Parameters.Add("NgayNhap", OleDbType.Date).Value = PN.NgayNhap;
            cmd.Parameters.Add("NoCu", OleDbType.Double).Value = PN.NoCu;
            cmd.Parameters.Add("TongTien", OleDbType.Double).Value = PN.TongTien;
            cmd.Parameters.Add("DaTra", OleDbType.Double).Value = PN.DaTra;
            cmd.Parameters.Add("ConNo", OleDbType.Double).Value = PN.ConNo;
            cmd.Parameters.Add("NCC", OleDbType.VarChar, 50).Value = PN.NhaCungCap.Id;
            return m_Ds.ExecuteNoneQuery(cmd);
        }
        public void XoaPhieuNhap(String ID)
        {
            OleDbCommand cmd = new OleDbCommand("DELETE FROM PHIEU_NHAP WHERE ID = @ID");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = ID;
            m_Ds.ExecuteNoneQuery(cmd);
        }
        public decimal LayTongTien(String ID)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT SUM(THANH_TIEN) FROM CHI_TIET_PHIEU_NHAP WHERE ID_PHIEU_NHAP = @ID");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = ID;
            return Convert.ToDecimal(m_Ds.ExecuteScalar(cmd));
        }
        public DataTable TongHopNoCongTy()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT PN.ID_NHA_CUNG_CAP, FIRST(NO_CU) + SUM(TONG_TIEN * 1.05) AS [TONG_MUA], SUM(DA_TRA) AS [TONG_TRA], SUM(TONG_TIEN) + FIRST(NO_CU) - SUM(DA_TRA) AS [TONG_NO] FROM PHIEU_NHAP PN INNER JOIN NHA_CUNG_CAP NCC ON PN.ID_NHA_CUNG_CAP = NCC.ID GROUP BY PN.ID_NHA_CUNG_CAP");
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable LayDanhSachPhieuNhap(String id, String NCC)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_NHAP WHERE ID > @id AND ID_NHA_CUNG_CAP=@NCC ORDER BY ID DESC");
            cmd.Parameters.Add("id", OleDbType.VarChar, 50).Value = id;
            cmd.Parameters.Add("NCC", OleDbType.VarChar, 50).Value = NCC;
            m_Ds.Load(cmd);
            return m_Ds;
        }
    }
}
