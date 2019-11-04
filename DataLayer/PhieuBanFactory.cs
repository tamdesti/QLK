using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace QuanLyKho.DataLayer
{
    public class PhieuBanFactory
    {
        DataService m_Ds = new DataService();

        public DataTable TimPhieuBan(String idKh, DateTime dt)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_BAN WHERE NGAY_BAN = @ngay AND ID_KHACH_HANG=@kh ORDER BY PB.ID DESC");
            cmd.Parameters.Add("ngay", OleDbType.Date).Value = dt.Date;
            cmd.Parameters.Add("kh", OleDbType.VarChar).Value = idKh;

            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable TimPhieuBan(String idKh, bool loaiKH)
        {
            if (idKh == "0")
            {
                if (loaiKH) return DanhsachPhieuBanSi();
                else return DanhsachPhieuBanLe();
            }
            else
            {
                OleDbCommand cmd = new OleDbCommand("SELECT *, (NO_CU + TONG_TIEN) AS [THANH_TIEN] FROM PHIEU_BAN WHERE ID_KHACH_HANG=@kh ORDER BY ID DESC");
                cmd.Parameters.Add("kh", OleDbType.VarChar).Value = idKh;
                m_Ds.Load(cmd);
            }
            return m_Ds;
        }
        public DataTable DanhsachPhieuBanLe_CoTenKhachHang(DateTime fromDate, DateTime toDate)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT PB.ID, PB.NGAY_BAN, PB.NO_CU, PB.TONG_TIEN, PB.NO_CU + PB.TONG_TIEN AS [Tổng tiền], PB.DA_TRA, PB.CON_NO, KH.HO_TEN AS [Khách hàng] FROM PHIEU_BAN PB INNER JOIN KHACH_HANG KH ON PB.ID_KHACH_HANG=KH.ID WHERE KH.LOAI_KH=FALSE AND PB.NGAY_BAN BETWEEN @date1 AND @date2 ORDER BY PB.ID DESC");
            cmd.Parameters.Add("@date1", OleDbType.Date).Value = fromDate.Date;
            cmd.Parameters.Add("@date2", OleDbType.Date).Value = toDate.Date;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable DanhsachPhieuBanLe_CoTenKhachHang_TheoKhachHang(String ID, DateTime fromDate, DateTime toDate)
        {
            if (ID == "0") return DanhsachPhieuBanLe_CoTenKhachHang(fromDate, toDate);
            OleDbCommand cmd = new OleDbCommand("SELECT PB.ID, PB.NGAY_BAN, PB.NO_CU, PB.TONG_TIEN, PB.NO_CU + PB.TONG_TIEN AS [Tổng tiền], PB.DA_TRA, PB.CON_NO, KH.HO_TEN AS [Khách hàng] FROM PHIEU_BAN PB INNER JOIN KHACH_HANG KH ON PB.ID_KHACH_HANG=KH.ID WHERE KH.ID=@id AND PB.NGAY_BAN BETWEEN @date1 AND @date2 ORDER BY PB.ID DESC");
            cmd.Parameters.Add("@id", OleDbType.VarChar, 50).Value = ID;
            cmd.Parameters.Add("@date1", OleDbType.Date).Value = fromDate.Date;
            cmd.Parameters.Add("@date2", OleDbType.Date).Value = toDate.Date;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable DanhsachPhieuBanLe()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT PB.*, (PB.NO_CU + PB.TONG_TIEN) AS [THANH_TIEN] FROM PHIEU_BAN PB INNER JOIN KHACH_HANG KH ON PB.ID_KHACH_HANG=KH.ID WHERE KH.LOAI_KH=FALSE ORDER BY PB.ID DESC");
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable DanhsachPhieuBanLeConNo()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT PB.* FROM PHIEU_BAN PB INNER JOIN KHACH_HANG KH ON PB.ID_KHACH_HANG=KH.ID WHERE KH.LOAI_KH=0 ORDER BY PB.ID DESC");
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable DanhsachPhieuBanLeConNo(String IDKH)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT PB.*, PB.TONG_TIEN + PB.NO_CU AS [TỔNG TIỀN] FROM PHIEU_BAN PB INNER JOIN KHACH_HANG KH ON PB.ID_KHACH_HANG=KH.ID WHERE KH.LOAI_KH=0 " + (IDKH == "0" ? "" : "AND PB.ID_KHACH_HANG = @KH") + " ORDER BY PB.ID DESC");
            if (IDKH != "0") cmd.Parameters.Add("@KH", OleDbType.VarChar, 50).Value = IDKH;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable DanhsachPhieuBanSi()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT PB.*, (PB.NO_CU + PB.TONG_TIEN) AS [THANH_TIEN] FROM PHIEU_BAN PB INNER JOIN KHACH_HANG KH ON PB.ID_KHACH_HANG=KH.ID WHERE KH.LOAI_KH=TRUE ORDER BY PB.ID DESC");
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable DanhsachPhieuBanSi_CoTenDaiLy(DateTime fromDate, DateTime toDate)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT PB.ID, PB.NGAY_BAN, PB.NO_CU, PB.TONG_TIEN, PB.NO_CU + PB.TONG_TIEN AS [Tổng tiền], PB.DA_TRA, PB.CON_NO, KH.DAI_LY AS [Đại lý] FROM PHIEU_BAN PB INNER JOIN KHACH_HANG KH ON PB.ID_KHACH_HANG=KH.ID WHERE KH.LOAI_KH=TRUE AND PB.NGAY_BAN BETWEEN @date1 AND @date2 ORDER BY PB.ID DESC");
            cmd.Parameters.Add("@date1", OleDbType.Date).Value = fromDate.Date;
            cmd.Parameters.Add("@date2", OleDbType.Date).Value = toDate.Date;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable DanhsachPhieuBanSi_CoTenDaiLy_TheoDaiLy(String ID, DateTime fromDate, DateTime toDate)
        {
            if (ID == "0") return DanhsachPhieuBanSi_CoTenDaiLy(fromDate, toDate);
            OleDbCommand cmd = new OleDbCommand("SELECT PB.ID, PB.NGAY_BAN, PB.NO_CU, PB.TONG_TIEN, PB.NO_CU + PB.TONG_TIEN AS [Tổng tiền], PB.DA_TRA, PB.CON_NO, KH.DAI_LY AS [Đại lý] FROM PHIEU_BAN PB INNER JOIN KHACH_HANG KH ON PB.ID_KHACH_HANG=KH.ID WHERE KH.ID=@id AND PB.NGAY_BAN BETWEEN @date1 AND @date2 ORDER BY PB.ID DESC");
            cmd.Parameters.Add("@id", OleDbType.VarChar, 50).Value = ID;
            cmd.Parameters.Add("@date1", OleDbType.Date).Value = fromDate.Date;
            cmd.Parameters.Add("@date2", OleDbType.Date).Value = toDate.Date;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable DanhsachPhieuBanSiConNo()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT PB.* FROM PHIEU_BAN PB INNER JOIN KHACH_HANG KH ON PB.ID_KHACH_HANG=KH.ID WHERE KH.LOAI_KH=TRUE ORDER BY PB.ID DESC");
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable DanhsachPhieuBanSiConNo(String IDKH)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT PB.*, PB.TONG_TIEN + PB.NO_CU AS [TỔNG TIỀN] FROM PHIEU_BAN PB INNER JOIN KHACH_HANG KH ON PB.ID_KHACH_HANG=KH.ID WHERE KH.LOAI_KH=TRUE " + (IDKH == "0" ? "" : "AND PB.ID_KHACH_HANG = @KH") + " ORDER BY PB.ID DESC");
            if (IDKH != "0")  cmd.Parameters.Add("@KH", OleDbType.VarChar, 50).Value = IDKH;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable DanhsachPhieuBan()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT PB.*, KH.ID FROM PHIEU_BAN PB INNER JOIN KHACH_HANG KH ON PB.ID_KHACH_HANG=KH.ID ORDER BY PB.ID DESC");
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable LayPhieuBan(String id)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_BAN WHERE ID = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar,50).Value = id;
            m_Ds.Load(cmd);
            return m_Ds;
        }

        public static long LayConNo(String kh, int thang, int nam)
        {
            DataService ds = new DataService();
            OleDbCommand cmd = new OleDbCommand("SELECT SUM(CON_NO) FROM PHIEU_BAN WHERE ID_KHACH_HANG = @kh AND MONTH(NGAY_BAN)=@thang AND YEAR(NGAY_BAN)= @nam");
            cmd.Parameters.Add("kh", OleDbType.VarChar, 50).Value = kh;
            cmd.Parameters.Add("thang", OleDbType.Integer).Value = thang;
            cmd.Parameters.Add("nam", OleDbType.Integer).Value = nam;

            object obj = ds.ExecuteScalar(cmd);
            if (obj == null)
                return 0;
            else
                return Convert.ToInt64(obj);
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
        public decimal LayTongTien(String ID)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT SUM(DON_GIA * SO_LUONG) FROM CHI_TIET_PHIEU_BAN WHERE ID_PHIEU_BAN = @ID");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = ID;
            return Convert.ToDecimal(m_Ds.ExecuteScalar(cmd));
        }
        public int ThemPhieuBan(DataRow row)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO PHIEU_BAN VALUES(@ID, @KH, @NgayBan, @NoCu, @TongTien, @DaTra, @ConNo)");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = row["ID"].ToString();
            cmd.Parameters.Add("KH", OleDbType.VarChar, 50).Value = row["ID_KHACH_HANG"].ToString();
            cmd.Parameters.Add("NgayBan", OleDbType.Date).Value = Convert.ToDateTime(row["NGAY_BAN"].ToString());
            cmd.Parameters.Add("NoCu", OleDbType.Double).Value = Convert.ToDouble(row["NO_CU"].ToString());
            cmd.Parameters.Add("TongTien", OleDbType.Double).Value = Convert.ToDouble(row["TONG_TIEN"].ToString());
            cmd.Parameters.Add("DaTra", OleDbType.Double).Value = Convert.ToDouble(row["DA_TRA"].ToString());
            cmd.Parameters.Add("ConNo", OleDbType.Double).Value = Convert.ToDouble(row["CON_NO"].ToString());
            return m_Ds.ExecuteNoneQuery(cmd);
        }
        public DataTable HienThiTongHopNoDaiLy()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT ID_KHACH_HANG, SUM(TONG_TIEN) + FIRST(NO_CU) AS [TONG_MUA], SUM(DA_TRA) AS [TONG_TRA], SUM(TONG_TIEN) + FIRST(NO_CU) - SUM(DA_TRA) AS [TONG_NO] FROM PHIEU_BAN PB INNER JOIN KHACH_HANG KH ON KH.ID = PB.ID_KHACH_HANG WHERE KH.LOAI_KH=true GROUP BY ID_KHACH_HANG");
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable HienThiTongHopNoKhachHang()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT ID_KHACH_HANG, SUM(TONG_TIEN) + FIRST(NO_CU) AS [TONG_MUA], SUM(DA_TRA) AS [TONG_TRA], SUM(TONG_TIEN) + FIRST(NO_CU) - SUM(DA_TRA) AS [TONG_NO] FROM PHIEU_BAN PB INNER JOIN KHACH_HANG KH ON KH.ID = PB.ID_KHACH_HANG WHERE KH.LOAI_KH=false GROUP BY ID_KHACH_HANG");
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable HienThiDanhSachKhoanPhaiThu()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT ID_KHACH_HANG, [HO_TEN] & \"_\" & [DIEN_THOAI] AS [Tên Khách hàng], DIA_CHI AS [Địa chỉ], " +
                                                "[Nợ hiện tại] AS [Nợ đầu kỳ], " +
                                                "DSUM(\"PHIEU_BAN.TONG_TIEN - PHIEU_BAN.DA_TRA\", \"PHIEU_BAN\", \"ID_KHACH_HANG='\" & ID_KHACH_HANG & \"' AND NGAY_BAN= Date() \") AS [Phát sinh tăng], " +
                                                "DSUM(\"PHIEU_THANH_TOAN.TONG_TIEN\", \"PHIEU_THANH_TOAN\", \"ID_KHACH_HANG='\" & ID_KHACH_HANG & \"' AND NGAY_THANH_TOAN= Date() \") AS [Phát sinh giảm], "+
                                                "LAST(CON_NO) AS [Nợ hiện tại] " +
                                                "FROM PHIEU_BAN PB INNER JOIN KHACH_HANG KH ON KH.ID = PB.ID_KHACH_HANG " +
                                                "WHERE KH.LOAI_KH=false " +
                                                "GROUP BY PB.ID_KHACH_HANG, [HO_TEN] & \"_\" & [DIEN_THOAI], KH.DIA_CHI;");
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable ChiTietXuatKhoTheoSanPham(string IDSP, string IDKHO, DateTime fromDate, DateTime toDate)
        {
            string WhereString = "";
            if (IDSP != "0")
            {
                WhereString = "AND ID_SAN_PHAM = @SP ";
                if (IDKHO != "0")
                {
                    WhereString += "AND ID_KHO = @KHO";
                }
            }
            else
            {
                if (IDKHO != "0")
                {
                    WhereString += "AND ID_KHO = @KHO";
                }
            }
            OleDbCommand cmd = new OleDbCommand("SELECT [HO_TEN] & \"_\" & [DIEN_THOAI] AS [Tên Khách hàng], CTPB.NGAY_BAN AS [Ngày], CTPB.SO_LUONG AS [Số lượng], DON_GIA AS [Đơn giá], THANH_TIEN AS [Tiền hàng], SP.LOAI AS [Loại] " +
                                                "FROM ((CHI_TIET_PHIEU_BAN CTPB INNER JOIN PHIEU_BAN PB ON PB.ID = CTPB.ID_PHIEU_BAN) INNER JOIN KHACH_HANG KH ON KH.ID = PB.ID_KHACH_HANG) INNER JOIN SAN_PHAM SP ON SP.ID = CTPB.ID_SAN_PHAM " +
                                                "WHERE CTPB.NGAY_BAN >= @date1 AND CTPB.NGAY_BAN <= @date2 " + WhereString +
                                                " ORDER BY CTPB.NGAY_BAN");
            cmd.Parameters.Add("date1", OleDbType.Date).Value = fromDate.Date;
            cmd.Parameters.Add("date2", OleDbType.Date).Value = toDate.Date;
            if (IDSP != "0") cmd.Parameters.Add("SP", OleDbType.VarChar, 50).Value = IDSP;
            if (IDKHO != "0") cmd.Parameters.Add("KHO", OleDbType.VarChar, 50).Value = IDKHO;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable ChiTietXuatKhoTheoKhachHang(string IDKH, string IDKHO, DateTime fromDate, DateTime toDate)
        {
            string WhereString = "";
            if (IDKH != "0")
            {
                WhereString = "AND PB.ID_KHACH_HANG = @KH ";
                if (IDKHO != "0")
                {
                    WhereString += "AND CTPB.ID_KHO = @KHO";
                }
            }
            else
            {
                if (IDKHO != "0")
                {
                    WhereString += "AND CTPB.ID_KHO = @KHO";
                }
            }
            OleDbCommand cmd = new OleDbCommand("SELECT SP.TEN_SAN_PHAM AS [Mặt hàng], CTPB.NGAY_BAN AS [Ngày], CTPB.SO_LUONG AS [Số lượng], DON_GIA AS [Đơn giá], THANH_TIEN AS [Tiền hàng], SP.LOAI AS [Loại] " +
                                                "FROM ((CHI_TIET_PHIEU_BAN CTPB INNER JOIN PHIEU_BAN PB ON PB.ID = CTPB.ID_PHIEU_BAN) INNER JOIN KHACH_HANG KH ON KH.ID = PB.ID_KHACH_HANG) INNER JOIN SAN_PHAM SP ON SP.ID = CTPB.ID_SAN_PHAM " +
                                                "WHERE CTPB.NGAY_BAN >= @date1 AND CTPB.NGAY_BAN <= @date2 " + WhereString +
                                                " ORDER BY CTPB.NGAY_BAN");
            cmd.Parameters.Add("date1", OleDbType.Date).Value = fromDate.Date;
            cmd.Parameters.Add("date2", OleDbType.Date).Value = toDate.Date;
            if (IDKH != "0") cmd.Parameters.Add("KH", OleDbType.VarChar, 50).Value = IDKH;
            if (IDKHO != "0") cmd.Parameters.Add("KHO", OleDbType.VarChar, 50).Value = IDKHO;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable LayPhieuBanTuKhachHang(String idKh)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_BAN WHERE ID_KHACH_HANG=@kh");
            cmd.Parameters.Add("kh", OleDbType.VarChar).Value = idKh;

            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable LayDanhSachPhieuBan(String id, String IDKH)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM PHIEU_NHAP WHERE ID > @id AND ID_KHACH_HANG=@KH");
            cmd.Parameters.Add("id", OleDbType.VarChar, 50).Value = id;
            cmd.Parameters.Add("KH", OleDbType.VarChar, 50).Value = IDKH;
            m_Ds.Load(cmd);
            return m_Ds;
        }
    }
}
