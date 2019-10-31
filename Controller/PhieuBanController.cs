using System;
using System.Collections.Generic;
using System.Text;
using QuanLyKho.DataLayer;
using QuanLyKho.BusinessObject;
using System.Windows.Forms;
using System.Data;

namespace QuanLyKho.Controller
{
    
    public class PhieuBanController
    {
        PhieuBanFactory factory = new PhieuBanFactory();

        BindingSource bs = new BindingSource();


        public PhieuBanController()
        {
            bs.DataSource = factory.LayPhieuBan("-1");
        }
        public DataRow NewRow()
        {
            return factory.NewRow();
        }
        public void Add(DataRow row)
        {
            factory.Add(row);
        }
        public void Update()
        {
            bs.MoveNext();
            factory.Save();
        }
        public void Save()
        {
            factory.Save();
        }
        public void HienthiPhieuBanLe(BindingNavigator bn, DataGridView dg)
        {
            DataTable dt = new DataTable();
            dt = factory.DanhsachPhieuBanLe();
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HienthiPhieuBanLeConNo(BindingNavigator bn, DataGridView dg)
        {
            DataTable dt = new DataTable();
            dt = factory.DanhsachPhieuBanLeConNo();
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HienthiPhieuBanLeConNo(BindingNavigator bn, DataGridView dg, string IDKH)
        {
            DataTable dt = new DataTable();
            dt = factory.DanhsachPhieuBanLeConNo(IDKH);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HienthiPhieuBanSi(BindingNavigator bn, DataGridView dg)
        {
            DataTable dt = new DataTable();
            dt = factory.DanhsachPhieuBanSi();
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HienthiPhieuBanSiConNo(BindingNavigator bn, DataGridView dg)
        {
            DataTable dt = new DataTable();
            dt = factory.DanhsachPhieuBanSiConNo();
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HienthiPhieuBanSiConNo(BindingNavigator bn, DataGridView dg, string IDKH)
        {
            DataTable dt = new DataTable();
            dt = factory.DanhsachPhieuBanSiConNo(IDKH);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HienthiPhieuBanSi_CoTenDaiLy(BindingNavigator bn, DataGridView dg, string ID_DaiLy, DateTime fromdate, DateTime todate)
        {
            DataTable dt = new DataTable();
            dt = factory.DanhsachPhieuBanSi_CoTenDaiLy_TheoDaiLy(ID_DaiLy,fromdate, todate);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HienthiPhieuBanLe_CoTenKhachHang(BindingNavigator bn, DataGridView dg, string ID_KhachHang, DateTime fromdate, DateTime todate)
        {
            DataTable dt = new DataTable();
            dt = factory.DanhsachPhieuBanLe_CoTenKhachHang_TheoKhachHang(ID_KhachHang, fromdate, todate);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public int ThemPhieuBan(DataRow row)
        {
            return factory.ThemPhieuBan(row);
        }
        public PhieuBan LayPhieuBan(String id)
        {
            DataTable tbl = factory.LayPhieuBan(id);
            PhieuBan ph = null;
            if (tbl.Rows.Count > 0)
            {

                ph = new PhieuBan();
                ph.Id = Convert.ToString(tbl.Rows[0]["ID"]);
                ph.NgayBan = Convert.ToDateTime(tbl.Rows[0]["NGAY_BAN"]);
                ph.NoCu = Convert.ToDouble(tbl.Rows[0]["NO_CU"]);
                ph.TongTien = Convert.ToDouble(tbl.Rows[0]["TONG_TIEN"]);
                ph.DaTra = Convert.ToDouble(tbl.Rows[0]["DA_TRA"]);
                ph.ConNo = Convert.ToDouble(tbl.Rows[0]["CON_NO"]);
                KhachHangController ctrlKH = new KhachHangController();
                ph.KhachHang = ctrlKH.LayKhachHang(Convert.ToString(tbl.Rows[0]["ID_KHACH_HANG"]));
                ChiTietPhieuBanController ctrl = new ChiTietPhieuBanController();
                ph.ChiTiet = ctrl.ChiTietPhieuBan(ph.Id);
            }
            return ph;
        }

        public void TimPhieuBan(String maKH, DateTime dt)
        {
            factory.TimPhieuBan(maKH, dt);
        }
        public void LayDanhSachPhieuBanTuMaKH(BindingNavigator bn, DataGridView dg, String maKH, bool loaiKH)
        {
            DataTable dt = new DataTable();
            dt = factory.TimPhieuBan(maKH, loaiKH);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
            bn.BindingSource = bs;
        }
        public decimal LayTongTien(String IDPhieuNhap)
        {
            PhieuBanFactory PBFactory = new PhieuBanFactory();
            return PBFactory.LayTongTien(IDPhieuNhap);
        }
        public void CapNhatPhieuBan(DataRow row)
        {
            PhieuBanFactory PBFactory = new PhieuBanFactory();
            DataTable tbl = PBFactory.LayPhieuBan(row["ID"].ToString());
            if (tbl.Rows.Count > 0)
            {
                tbl.Rows[0]["NO_CU"] = row["NO_CU"];
                tbl.Rows[0]["TONG_TIEN"] = row["TONG_TIEN"];
                tbl.Rows[0]["DA_TRA"] = row["DA_TRA"];
                tbl.Rows[0]["CON_NO"] = row["CON_NO"];
                PBFactory.Save();
            }
        }
        public void CapNhatNoCu(PhieuBan PB)
        {
            PhieuBanFactory PBFactory = new PhieuBanFactory();
            DataTable tbl = PBFactory.LayPhieuBan(PB.Id);
            if (tbl.Rows.Count > 0)
            {
                tbl.Rows[0]["ID_KHACH_HANG"] = PB.KhachHang.Id;
                tbl.Rows[0]["NO_CU"] = PB.NoCu;
                PBFactory.Save();
            }
        }
        public void ThanhToanPhieuBan(PhieuBan PB)
        {
            PhieuBanFactory PBFactory = new PhieuBanFactory();
            DataTable tbl = PBFactory.LayPhieuBan(PB.Id);
            if (tbl.Rows.Count > 0)
            {
                tbl.Rows[0]["DA_TRA"] = PB.DaTra;
                tbl.Rows[0]["CON_NO"] = PB.ConNo;
                PBFactory.Save();
            }
        }
        public void HienThiTongHopNoDaiLy(BindingNavigator bn, DataGridView dg)
        {
            PhieuBanFactory PBFactory = new PhieuBanFactory();
            DataTable dt = new DataTable();
            dt = PBFactory.HienThiTongHopNoDaiLy();
            if (dt.Rows.Count > 0)
            {
                List<int> removelist = new List<int>();
                for (int i = dt.Rows.Count - 1; i > -1; i--)
                    if (Convert.ToInt64(dt.Rows[i]["TONG_NO"].ToString()) <= 0) removelist.Add(i);
                foreach (int index in removelist)
                {
                    dt.Rows.RemoveAt(index);
                }
            }
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HienThiTongHopNoKhachHang(BindingNavigator bn, DataGridView dg)
        {
            PhieuBanFactory PBFactory = new PhieuBanFactory();
            DataTable dt = new DataTable();
            dt = PBFactory.HienThiTongHopNoKhachHang();
            if (dt.Rows.Count > 0)
            {
                List<int> removelist = new List<int>();
                for (int i = dt.Rows.Count - 1; i > -1; i--)
                    if (Convert.ToInt64(dt.Rows[i]["TONG_NO"].ToString()) <= 0) removelist.Add(i);
                foreach (int index in removelist)
                {
                    dt.Rows.RemoveAt(index);
                }
            }
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HienThiDanhSachCacKhoanPhaiThu(DataGridView dg)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            PhieuBanFactory PBFactory = new PhieuBanFactory();
            DataTable dt = new DataTable();
            System.Windows.Forms.BindingNavigator bn = new BindingNavigator();
            dt = PBFactory.HienThiDanhSachKhoanPhaiThu();
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HienThiChiTietXuatKhoTheoSanPham(DataGridView dg, string IDSP, string IDKHO, DateTime from, DateTime to)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            PhieuBanFactory PBFactory = new PhieuBanFactory();
            DataTable dt = new DataTable();
            System.Windows.Forms.BindingNavigator bn = new BindingNavigator();
            dt = PBFactory.ChiTietXuatKhoTheoSanPham(IDSP, IDKHO, from, to);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HienThiChiTietXuatKhoTheoKhachHang(DataGridView dg, string IDKhach, string IDKHO, DateTime from, DateTime to)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            PhieuBanFactory PBFactory = new PhieuBanFactory();
            DataTable dt = new DataTable();
            System.Windows.Forms.BindingNavigator bn = new BindingNavigator();
            dt = PBFactory.ChiTietXuatKhoTheoKhachHang(IDKhach, IDKHO, from, to);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public int VitriPhieuBanTuKhachHang(String ID_KhachHang, String ID_PhieuBan)
        {
            PhieuBanFactory PBFactory = new PhieuBanFactory();
            DataTable dt = new DataTable();
            dt = PBFactory.LayPhieuBanTuKhachHang(ID_KhachHang);
            foreach (DataRow row in dt.Rows)
            {
                if (row["ID"].ToString() == ID_PhieuBan)
                {
                    return dt.Rows.IndexOf(row);
                }
            }
            return -1;
        }
        public int VitriPhieuBanMoiNhatTuKhachHang(String ID_KhachHang)
        {
            PhieuBanFactory PBFactory = new PhieuBanFactory();
            DataTable dt = new DataTable();
            dt = PBFactory.LayPhieuBanTuKhachHang(ID_KhachHang);
            if (dt.Rows.Count > 0) return dt.Rows.Count - 1;
            return -1;
        }
        public long LayNoCuKhachHang(String ID_KhachHang, int vitri)
        {
            PhieuBanFactory PBFactory = new PhieuBanFactory();
            DataTable dt = new DataTable();
            dt = PBFactory.LayPhieuBanTuKhachHang(ID_KhachHang);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[vitri]["CON_NO"].ToString());
            }
            return 0;
        }
        public PhieuBan PhieuBanMoiNhatTuKhachHang(String ID_KhachHang)
        {
            PhieuBanFactory PBFactory = new PhieuBanFactory();
            DataTable dt = new DataTable();
            dt = PBFactory.LayPhieuBanTuKhachHang(ID_KhachHang);
            if (dt.Rows.Count > 0)
            {
                PhieuBan ph = new PhieuBan();
                ph.Id = Convert.ToString(dt.Rows[dt.Rows.Count - 1]["ID"]);
                ph.NgayBan = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1]["NGAY_BAN"]);
                ph.NoCu = Convert.ToInt64(dt.Rows[dt.Rows.Count - 1]["NO_CU"]);
                ph.TongTien = Convert.ToInt64(dt.Rows[dt.Rows.Count - 1]["TONG_TIEN"]);
                ph.DaTra = Convert.ToInt64(dt.Rows[dt.Rows.Count - 1]["DA_TRA"]);
                ph.ConNo = Convert.ToInt64(dt.Rows[dt.Rows.Count - 1]["CON_NO"]);
                //KhachHangController ctrlKH = new KhachHangController();
                //ph.KhachHang = ctrlKH.LayKhachHang(Convert.ToString(dt.Rows[0]["ID_KHACH_HANG"]));
                //ChiTietPhieuBanController ctrl = new ChiTietPhieuBanController();
                //ph.ChiTiet = ctrl.ChiTietPhieuBan(ph.Id);
                return ph;
            }
            return null;
        }
        public void CapNhatChuoiNoCu(PhieuBan PB)
        {
            PhieuBanFactory PBFactory = new PhieuBanFactory();
            DataTable tbl = PBFactory.LayDanhSachPhieuBan(PB.Id, PB.KhachHang.Id);
            int rowcount = 0;
            foreach (DataRow row in tbl.Rows)
            {
                if (rowcount == 0)
                {
                    row["NO_CU"] = PB.ConNo;
                }
                else
                {
                    row["NO_CU"] = tbl.Rows[rowcount - 1]["CON_NO"];
                }
                long TongTien = Convert.ToInt32(row["NO_CU"]) + Convert.ToInt32(row["TONG_TIEN"]);
                long Datra = Convert.ToInt32(row["DA_TRA"]);
                if (Datra > TongTien) Datra = TongTien;
                long ConNo = TongTien - Datra;
                row["CON_NO"] = ConNo <= 0 ? 0 : ConNo;
                rowcount++;
            }
            PBFactory.Save();
        }
    }
}
