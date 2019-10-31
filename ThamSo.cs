using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace QuanLyKho
{
    public enum Controll
    {
        Normal,
        AddNew,
        Edit
    }
    public enum TypeOfReport
    {
        DaNhap = 1,
        DaBan = 2,
        TonKho = 3,
        HetHan = 4,
        TonKhoMoi = 5
    }
    public enum DuNo
    {
        BanSi = 1,
        BanLe = 2
    }
    public class ThamSo
    {
        public static void PreMonth(ref int thangtruoc, ref int namtruoc, int thang, int nam)
        {
            thangtruoc = thang - 1;
            namtruoc = nam;
            if (thangtruoc == 0)
            {
                thangtruoc = 12;
                namtruoc= nam - 1;
            }
        }

        public static bool LaSoNguyen(String so)
        {
            try
            {
                Convert.ToInt64(so);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static long LayMaPhieuBan()
        {
            DataService ds = new DataService();
            object obj = ds.ExecuteScalar(new OleDbCommand("SELECT PHIEU_BAN FROM THAM_SO"));
            return Convert.ToInt64(obj);
        }
        public static void GanMaPhieuBan(long id)
        {
            DataService ds = new DataService();
            ds.ExecuteNoneQuery(new OleDbCommand("UPDATE THAM_SO SET PHIEU_BAN = " + id));

        }

        public static long LayMaPhieuThanhToan()
        {
            DataService ds = new DataService();
            object obj = ds.ExecuteScalar(new OleDbCommand("SELECT PHIEU_THANH_TOAN FROM THAM_SO"));
            return Convert.ToInt64(obj);
        }
        public static void GanMaPhieuThanhToan(long id)
        {
            DataService ds = new DataService();
            ds.ExecuteNoneQuery(new OleDbCommand("UPDATE THAM_SO SET PHIEU_THANH_TOAN = " + id));

        }



        public static long SanPham
        {
            get 
            {
                DataService ds = new DataService();
                object obj = ds.ExecuteScalar(new OleDbCommand("SELECT SAN_PHAM FROM THAM_SO"));
                return Convert.ToInt64(obj);
            }
            set 
            {
                DataService ds = new DataService();
                ds.ExecuteNoneQuery(new OleDbCommand("UPDATE THAM_SO SET SAN_PHAM = " + value));
            }
        }
        public static long MaPhieuNhap
        {
            get
            {
                DataService ds = new DataService();
                object obj = ds.ExecuteScalar(new OleDbCommand("SELECT PHIEU_NHAP FROM THAM_SO"));
                return Convert.ToInt64(obj);
            }
            set
            {
                DataService ds = new DataService();
                ds.ExecuteNoneQuery(new OleDbCommand("UPDATE THAM_SO SET PHIEU_NHAP = " + value));
            }
        }

        public static QuanLyKho.BusinessObject.CuaHang LayCuaHang()
        {
            QuanLyKho.BusinessObject.CuaHang ch = new QuanLyKho.BusinessObject.CuaHang();
            DataService ds = new DataService();
            ds.Load(new OleDbCommand("SELECT NGAY_HET_HAN, NGAY_TRA_NHA_CUNG_CAP FROM THAM_SO"));
            if (ds.Rows.Count > 0)
            {
                ch.NgayBaoHetHan = Convert.ToInt16(ds.Rows[0]["NGAY_HET_HAN"].ToString());
                ch.NgayTraNhaCungCap = Convert.ToInt16(ds.Rows[0]["NGAY_TRA_NHA_CUNG_CAP"].ToString());
            }
            return ch;
        }
        public static void GanCuaHang(long ngayhethan, long tranhacungcap)
        {
            DataService ds = new DataService();
            OleDbCommand cmd = new OleDbCommand("UPDATE THAM_SO SET NGAY_HET_HAN = @NGAY_HET_HAN, NGAY_TRA_NHA_CUNG_CAP = @NGAY_TRA_NHA_CUNG_CAP");
            cmd.Parameters.Add("@NGAY_HET_HAN", OleDbType.Integer).Value = ngayhethan;
            cmd.Parameters.Add("@NGAY_TRA_NHA_CUNG_CAP", OleDbType.Integer).Value = tranhacungcap;

            ds.ExecuteNoneQuery(cmd);
        }

        

        public static long NhaCungCap
        {
            get
            {
                DataService ds = new DataService();
                object obj = ds.ExecuteScalar(new OleDbCommand("SELECT NHA_CUNG_CAP FROM THAM_SO"));
                return Convert.ToInt64(obj);
            }
            set
            {
                DataService ds = new DataService();
                ds.ExecuteNoneQuery(new OleDbCommand("UPDATE THAM_SO SET NHA_CUNG_CAP = " + value));
            }
        }
        public static long NhomSanPham
        {
            get
            {
                DataService ds = new DataService();
                object obj = ds.ExecuteScalar(new OleDbCommand("SELECT NHOM_SAN_PHAM FROM THAM_SO"));
                return Convert.ToInt64(obj);
            }
            set
            {
                DataService ds = new DataService();
                ds.ExecuteNoneQuery(new OleDbCommand("UPDATE THAM_SO SET NHOM_SAN_PHAM = " + value));
            }
        }
        public static long KhachHang
        {
            get
            {
                DataService ds = new DataService();
                object obj = ds.ExecuteScalar(new OleDbCommand("SELECT KHACH_HANG FROM THAM_SO"));
                return Convert.ToInt64(obj);
            }
            set
            {
                DataService ds = new DataService();
                ds.ExecuteNoneQuery(new OleDbCommand("UPDATE THAM_SO SET KHACH_HANG = " + value));
            }
        }
        public static long KhoHang
        {
            get
            {
                DataService ds = new DataService();
                object obj = ds.ExecuteScalar(new OleDbCommand("SELECT KHO_HANG FROM THAM_SO"));
                return Convert.ToInt64(obj);
            }
            set
            {
                DataService ds = new DataService();
                ds.ExecuteNoneQuery(new OleDbCommand("UPDATE THAM_SO SET KHO_HANG = " + value));
            }
        }
        public static long PhieuChi
        {
            get
            {
                DataService ds = new DataService();
                object obj = ds.ExecuteScalar(new OleDbCommand("SELECT PHIEU_CHI FROM THAM_SO"));
                return Convert.ToInt64(obj);
            }
            set
            {
                DataService ds = new DataService();
                ds.ExecuteNoneQuery(new OleDbCommand("UPDATE THAM_SO SET PHIEU_CHI = " + value));
            }
        }
        public static long DonViTinh
        {
            get
            {
                DataService ds = new DataService();
                object obj = ds.ExecuteScalar(new OleDbCommand("SELECT DON_VI_TINH FROM THAM_SO"));
                return Convert.ToInt64(obj);
            }
            set
            {
                DataService ds = new DataService();
                ds.ExecuteNoneQuery(new OleDbCommand("UPDATE THAM_SO SET DON_VI_TINH = " + value));
            }
        }
        public static long QuyCach
        {
            get
            {
                DataService ds = new DataService();
                object obj = ds.ExecuteScalar(new OleDbCommand("SELECT QUY_CACH FROM THAM_SO"));
                return Convert.ToInt64(obj);
            }
            set
            {
                DataService ds = new DataService();
                ds.ExecuteNoneQuery(new OleDbCommand("UPDATE THAM_SO SET QUY_CACH = " + value));
            }
        }
        public static DateTime NgayLapPhieu
        {
            get
            {
                DataService ds = new DataService();
                object obj = ds.ExecuteScalar(new OleDbCommand("SELECT NGAY_LAP_PHIEU FROM THAM_SO"));
                return Convert.ToDateTime(obj);
            }
            set
            {
                DataService ds = new DataService();
                OleDbCommand cmd = new OleDbCommand("UPDATE THAM_SO SET NGAY_LAP_PHIEU= @date");
                cmd.Parameters.Add("date", OleDbType.Date).Value = Convert.ToDateTime(value.ToString());
                ds.ExecuteNoneQuery(cmd);
            }
        }
        public static long PhieuBanTrongNgay
        {
            get
            {
                DataService ds = new DataService();
                object obj = ds.ExecuteScalar(new OleDbCommand("SELECT PHIEU_BAN_TRONG_NGAY FROM THAM_SO"));
                return Convert.ToInt64(obj);
            }
            set
            {
                DataService ds = new DataService();
                ds.ExecuteNoneQuery(new OleDbCommand("UPDATE THAM_SO SET PHIEU_BAN_TRONG_NGAY = " + value));
            }
        }
        public static long PhieuNhapTrongNgay
        {
            get
            {
                DataService ds = new DataService();
                object obj = ds.ExecuteScalar(new OleDbCommand("SELECT PHIEU_NHAP_TRONG_NGAY FROM THAM_SO"));
                return Convert.ToInt64(obj);
            }
            set
            {
                DataService ds = new DataService();
                ds.ExecuteNoneQuery(new OleDbCommand("UPDATE THAM_SO SET PHIEU_NHAP_TRONG_NGAY = " + value));
            }
        }
    }
}
