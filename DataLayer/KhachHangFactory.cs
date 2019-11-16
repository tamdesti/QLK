using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace QuanLyKho.DataLayer
{
    public class KhachHangFactory
    {
        DataService m_Ds = new DataService();

        public DataTable DanhsachKhachHang(bool loai)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM KHACH_HANG WHERE LOAI_KH = " + loai + " ORDER BY " + (loai ? "DAI_LY" : "HO_TEN"));
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable DanhsachKhachHangXuatKho(bool loai, string IDKHO, DateTime fromDate, DateTime toDate)
        {
            string WhereString = "";
            if (IDKHO != "0")
            {
                WhereString += " AND CHI_TIET_PHIEU_BAN.ID_KHO=@IDKHO";
            }
            OleDbCommand cmd = new OleDbCommand("SELECT KHACH_HANG.ID, KHACH_HANG.HO_TEN, KHACH_HANG.DIA_CHI, KHACH_HANG.DIEN_THOAI, KHACH_HANG.LOAI_KH, KHACH_HANG.DAI_LY " +
                                                "FROM ((KHACH_HANG INNER JOIN PHIEU_BAN ON KHACH_HANG.ID = PHIEU_BAN.ID_KHACH_HANG) INNER JOIN CHI_TIET_PHIEU_BAN ON PHIEU_BAN.ID = CHI_TIET_PHIEU_BAN.ID_PHIEU_BAN) " +
                                                "WHERE LOAI_KH = " + loai + " AND CHI_TIET_PHIEU_BAN.NGAY_BAN >= @date1 AND CHI_TIET_PHIEU_BAN.NGAY_BAN <= @date2 " + WhereString +
                                                " GROUP BY KHACH_HANG.ID, KHACH_HANG.HO_TEN, KHACH_HANG.DIA_CHI, KHACH_HANG.DIEN_THOAI, KHACH_HANG.LOAI_KH, KHACH_HANG.DAI_LY " +
                                                " ORDER BY " + (loai ? "DAI_LY" : "HO_TEN"));
            cmd.Parameters.Add("date1", OleDbType.Date).Value = fromDate.Date;
            cmd.Parameters.Add("date2", OleDbType.Date).Value = toDate.Date;
            if (IDKHO != "0") cmd.Parameters.Add("IDKHO", OleDbType.VarChar, 50).Value = IDKHO;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable DanhsachKhachHangXuatKhoTheoSanPham(bool loai, string IDKHO, string IDSP, DateTime fromDate, DateTime toDate)
        {
            string WhereString = "";
            if (IDSP != "0")
            {
                WhereString = " AND CHI_TIET_PHIEU_BAN.ID_SAN_PHAM=@IDSP ";
                if (IDKHO != "0")
                {
                    WhereString += " AND CHI_TIET_PHIEU_BAN.ID_KHO=@IDKHO";
                }
            }
            else
            {
                if (IDKHO != "0")
                {
                    WhereString += " AND CHI_TIET_PHIEU_BAN.ID_KHO=@IDKHO";
                }
            }
            OleDbCommand cmd = new OleDbCommand("SELECT KHACH_HANG.ID, KHACH_HANG.HO_TEN, KHACH_HANG.DIA_CHI, KHACH_HANG.DIEN_THOAI, KHACH_HANG.LOAI_KH, KHACH_HANG.DAI_LY " +
                                                "FROM ((KHACH_HANG INNER JOIN PHIEU_BAN ON KHACH_HANG.ID = PHIEU_BAN.ID_KHACH_HANG) INNER JOIN CHI_TIET_PHIEU_BAN ON PHIEU_BAN.ID = CHI_TIET_PHIEU_BAN.ID_PHIEU_BAN) " +
                                                "WHERE LOAI_KH = " + loai + " AND CHI_TIET_PHIEU_BAN.NGAY_BAN >= @date1 AND CHI_TIET_PHIEU_BAN.NGAY_BAN <= @date2 " + WhereString +
                                                " GROUP BY KHACH_HANG.ID, KHACH_HANG.HO_TEN, KHACH_HANG.DIA_CHI, KHACH_HANG.DIEN_THOAI, KHACH_HANG.LOAI_KH, KHACH_HANG.DAI_LY " +
                                                " ORDER BY " + (loai ? "DAI_LY" : "HO_TEN"));
            cmd.Parameters.Add("date1", OleDbType.Date).Value = fromDate.Date;
            cmd.Parameters.Add("date2", OleDbType.Date).Value = toDate.Date;
            if (IDSP != "0") cmd.Parameters.Add("IDSP", OleDbType.VarChar, 50).Value = IDSP;
            if (IDKHO != "0") cmd.Parameters.Add("IDKHO", OleDbType.VarChar, 50).Value = IDKHO;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable TimHoTen(String hoten, bool loai)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM KHACH_HANG WHERE HO_TEN LIKE '%' + @hoten + '%' AND LOAI_KH = " + loai);
            cmd.Parameters.Add("hoten", OleDbType.VarChar).Value = hoten;
            m_Ds.Load(cmd);

            return m_Ds;
        }

        public DataTable TimDiaChi(String diachi, bool loai)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM KHACH_HANG WHERE DIA_CHI LIKE '%' + @diachi + '%' AND LOAI_KH = " + loai);
            cmd.Parameters.Add("diachi", OleDbType.VarChar).Value = diachi;
            m_Ds.Load(cmd);

            return m_Ds;
        }

        public DataTable DanhsachKhachHang()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM KHACH_HANG ORDER BY HO_TEN");
            m_Ds.Load(cmd);

            return m_Ds;
        }

        public DataTable LayKhachHang(String id)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM KHACH_HANG WHERE ID = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar,50).Value = id;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable LayKhachHangTuTen(String ten)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM KHACH_HANG WHERE HO_TEN=@Ten AND LOAI_KH=false");
            cmd.Parameters.Add("Ten", OleDbType.VarChar, 50).Value = ten;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable LayDaiLyTuTenDaiLy(String ten)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM KHACH_HANG WHERE DAI_LY=@DL AND LOAI_KH=True");
            cmd.Parameters.Add("DL", OleDbType.VarChar, 50).Value = ten;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public int ThemDaiLy(DataRow row)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO KHACH_HANG VALUES(@ID, @Ten, @Diachi, @DienThoai, true, @DaiLy)");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = row["ID"].ToString();
            cmd.Parameters.Add("Ten", OleDbType.VarChar, 50).Value = row["HO_TEN"].ToString();
            cmd.Parameters.Add("Diachi", OleDbType.VarChar, 50).Value = row["DIA_CHI"].ToString();
            cmd.Parameters.Add("DienThoai", OleDbType.VarChar, 50).Value = row["DIEN_THOAI"].ToString();
            cmd.Parameters.Add("DaiLy", OleDbType.VarChar, 50).Value = row["DAI_LY"].ToString();
            return m_Ds.ExecuteNoneQuery(cmd);
        }
        public int ThemKhachHang(DataRow row)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO KHACH_HANG VALUES(@ID, @Ten, @Diachi, @DienThoai, false, '')");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = row["ID"].ToString();
            cmd.Parameters.Add("Ten", OleDbType.VarChar, 50).Value = row["HO_TEN"].ToString();
            cmd.Parameters.Add("Diachi", OleDbType.VarChar, 50).Value = row["DIA_CHI"].ToString();
            cmd.Parameters.Add("DienThoai", OleDbType.VarChar, 50).Value = row["DIEN_THOAI"].ToString();
            return m_Ds.ExecuteNoneQuery(cmd);
        }
        public int ThemKhachHang(BusinessObject.KhachHang KH)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO KHACH_HANG VALUES(@ID, @Ten, @Diachi, @DienThoai, false, '')");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = KH.Id;
            cmd.Parameters.Add("Ten", OleDbType.VarChar, 50).Value = KH.HoTen;
            cmd.Parameters.Add("Diachi", OleDbType.VarChar, 50).Value = KH.DiaChi;
            cmd.Parameters.Add("DienThoai", OleDbType.VarChar, 50).Value = KH.DienThoai;
            return m_Ds.ExecuteNoneQuery(cmd);
        }
        public void XoaKhachHang(String ID)
        {
            OleDbCommand cmd = new OleDbCommand("DELETE FROM KHACH_HANG WHERE ID = @ID");
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
