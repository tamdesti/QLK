using System;
using System.Collections.Generic;
using System.Text;
using QuanLyKho.DataLayer;
using QuanLyKho.BusinessObject;
using System.Windows.Forms;
using System.Data;

namespace QuanLyKho.Controller
{
    
    public class PhieuNhapController
    {
        PhieuNhapFactory factory = new PhieuNhapFactory();
        BindingSource bs = new BindingSource();

        public PhieuNhapController()
        {
            bs.DataSource = factory.LayPhieuNhap("-1");
        }

        public DataRow NewRow()
        {
            return factory.NewRow();
        }
        public void Add(DataRow row)
        {
            factory.Add(row);
        }

        public void Update(PhieuNhap ph)
        {
            bs.MoveNext();
            factory.ChangePhieuNhap(ph.Id, ph.TongTien);
        }
        public void Save()
        {
            factory.Save();
        }
        public PhieuNhap LayPhieuNhap(String id)
        {
            DataTable tbl = factory.LayPhieuNhap(id);
            PhieuNhap ph = null;
            NhaCungCapController ctrlNCC = new NhaCungCapController();
            if (tbl.Rows.Count > 0)
            {

                ph = new PhieuNhap();
                ph.Id =Convert.ToString( tbl.Rows[0]["ID"]);
                ph.NoCu = Convert.ToDouble(tbl.Rows[0]["NO_CU"]);
                ph.NgayNhap = Convert.ToDateTime(tbl.Rows[0]["NGAY_NHAP"]);
                ph.TongTien = Convert.ToDouble(tbl.Rows[0]["TONG_TIEN"]);
                ph.DaTra = Convert.ToDouble(tbl.Rows[0]["DA_TRA"]);
                ph.ConNo = Convert.ToDouble(tbl.Rows[0]["CON_NO"]);
                ph.NhaCungCap = ctrlNCC.LayNCC(Convert.ToString(tbl.Rows[0]["ID_NHA_CUNG_CAP"]));
                ChiTietPhieuNhapController ctrl = new ChiTietPhieuNhapController();
                ph.ChiTiet = ctrl.ChiTietPhieuNhap(ph.Id);
            }
            return ph;
        }
        public void HienthiPhieuNhap(BindingNavigator bn, DataGridView dg)
        {
            DataTable dt = new DataTable();
            dt = factory.DanhsachPhieuNhap();
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HienthiPhieuChiTuMaNCC(BindingNavigator bn, DataGridView dg, string NCC, DateTime fromdate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            dt = factory.DanhsachPhieuChiTuMaNCC(NCC, fromdate, toDate);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HienthiPhieuNhapTuMaNCC(BindingNavigator bn, DataGridView dg, string NCC)
        {
            DataTable dt = new DataTable();
            dt = factory.DanhsachPhieuNhapTuMaNCC(NCC);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HienthiPhieuNhapConNo(BindingNavigator bn, DataGridView dg)
        {
            DataTable dt = new DataTable();
            dt = factory.DanhsachPhieuNhapConNo();
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HienthiPhieuNhapConNo(BindingNavigator bn, DataGridView dg, string NCC)
        {
            DataTable dt = new DataTable();
            dt = factory.DanhsachPhieuNhapConNo(NCC);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public int ThemPhieuNhap(DataRow row)
        {
            return factory.ThemPhieuNhap(row);
        }
        public int ThemPhieuNhap(PhieuNhap PN)
        {
            return factory.ThemPhieuNhap(PN);
        }
        public void XoaPhieuNhap(String ID)
        {
            factory.XoaPhieuNhap(ID);
        }
        public decimal LayTongTien(String IDPhieuNhap)
        {
            return factory.LayTongTien(IDPhieuNhap);
        }
        public void CapNhatPhieuNhap(DataRow row)
        {
            PhieuNhapFactory PNFactory = new PhieuNhapFactory();
            DataTable tbl = PNFactory.LayPhieuNhap(row["ID"].ToString());
            if (tbl.Rows.Count > 0)
            {
                tbl.Rows[0]["NO_CU"] = row["NO_CU"];
                tbl.Rows[0]["TONG_TIEN"] = row["TONG_TIEN"];
                tbl.Rows[0]["DA_TRA"] = row["DA_TRA"];
                tbl.Rows[0]["CON_NO"] = row["CON_NO"];
                PNFactory.Save();
            }
        }
        public void CapNhatPhieuNhap(PhieuNhap PN)
        {
            PhieuNhapFactory PNFactory = new PhieuNhapFactory();
            DataTable tbl = PNFactory.LayPhieuNhap(PN.Id);
            if (tbl.Rows.Count > 0)
            {
                tbl.Rows[0]["NO_CU"] = PN.NoCu;
                tbl.Rows[0]["TONG_TIEN"] = PN.TongTien;
                tbl.Rows[0]["DA_TRA"] = PN.DaTra;
                tbl.Rows[0]["CON_NO"] = PN.ConNo;
                PNFactory.Save();
            }
        }
        public void ThanhToanPhieuNhap(BusinessObject.PhieuNhap PN)
        {
            PhieuNhapFactory PNFactory = new PhieuNhapFactory();
            DataTable tbl = PNFactory.LayPhieuNhap(PN.Id);
            if (tbl.Rows.Count > 0)
            {
                tbl.Rows[0]["DA_TRA"] = PN.DaTra;
                tbl.Rows[0]["CON_NO"] = PN.ConNo;
                PNFactory.Save();
            }
        }
        public void HienThiTongHopNoCongTy(BindingNavigator bn, DataGridView dg)
        {
            PhieuNhapFactory PNFactory = new PhieuNhapFactory();
            DataTable dt = PNFactory.TongHopNoCongTy();
            if (dt.Rows.Count > 0)
            {
                List<int> removelist = new List<int>();
                for (int i = dt.Rows.Count - 1; i > -1; i--)
                    if (Convert.ToDouble(dt.Rows[i]["TONG_NO"].ToString()) == 0) removelist.Add(i);
                foreach (int index in removelist)
                {
                    dt.Rows.RemoveAt(index);
                }
            }
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public int VitriPhieuNhapTuNhaCungCap(String ID_NhaCungCap, String ID_PhieuNhap)
        {
            PhieuNhapFactory PNFactory = new PhieuNhapFactory();
            DataTable dt = new DataTable();
            dt = PNFactory.DanhsachPhieuNhapTuNCC(ID_NhaCungCap);
            foreach (DataRow row in dt.Rows)
            {
                if (row["ID"].ToString() == ID_PhieuNhap)
                {
                    return dt.Rows.IndexOf(row);
                }
            }
            return -1;
        }
        public int VitriPhieuNhapMoiNhatTuNhaCungCap(String ID_NhaCungCap)
        {
            PhieuNhapFactory PNFactory = new PhieuNhapFactory();
            DataTable dt = new DataTable();
            dt = PNFactory.DanhsachPhieuNhapTuNCC(ID_NhaCungCap);
            if (dt.Rows.Count > 0) return dt.Rows.Count - 1;
            return -1;
        }
        public double LayNoCuNhaCungCap(String ID_NhaCungCap, int vitri)
        {
            PhieuNhapFactory PNFactory = new PhieuNhapFactory();
            DataTable dt = new DataTable();
            dt = PNFactory.DanhsachPhieuNhapTuNCC(ID_NhaCungCap);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToDouble(dt.Rows[vitri]["CON_NO"].ToString());
            }
            return 0;
        }
        public void CapNhatNoCu(PhieuNhap PN)
        {
            PhieuNhapFactory PNFactory = new PhieuNhapFactory();
            DataTable tbl = PNFactory.LayPhieuNhap(PN.Id);
            if (tbl.Rows.Count > 0)
            {
                tbl.Rows[0]["ID_NHA_CUNG_CAP"] = PN.NhaCungCap.Id;
                tbl.Rows[0]["NO_CU"] = PN.NoCu;
                PNFactory.Save();
            }
        }
        public void CapNhatChuoiNoCu(PhieuNhap PN)
        {
            PhieuNhapFactory PNFactory = new PhieuNhapFactory();
            DataTable tbl = PNFactory.LayDanhSachPhieuNhap(PN.Id, PN.NhaCungCap.Id);
            int rowcount = 0;
            foreach (DataRow row in tbl.Rows)
            {
                if (rowcount == 0)
                {
                    row["NO_CU"] = PN.ConNo;
                }
                else
                {
                    row["NO_CU"] = tbl.Rows[rowcount-1]["CON_NO"];
                }
                double TongTien = Convert.ToInt32(row["NO_CU"]) + (Convert.ToInt32(row["TONG_TIEN"]));
                double Datra = Convert.ToInt32(row["DA_TRA"]);
                if (Datra > TongTien) Datra = TongTien;
                double ConNo = TongTien - Datra;
                row["CON_NO"] = ConNo;
                rowcount++;
            }
            PNFactory.Save();
        }
        public PhieuNhap PhieuNhapMoiNhatTuNhaCungCap(String ID_NhaCungCap)
        {
            PhieuNhapFactory PNFactory = new PhieuNhapFactory();
            DataTable dt = new DataTable();
            dt = PNFactory.DanhsachPhieuNhapTuNCC(ID_NhaCungCap);
            if (dt.Rows.Count > 0)
            {
                PhieuNhap ph = new PhieuNhap();
                ph.Id = Convert.ToString(dt.Rows[0]["ID"]);
                ph.NgayNhap = Convert.ToDateTime(dt.Rows[0]["NGAY_NHAP"]);
                ph.NoCu = Convert.ToInt64(dt.Rows[0]["NO_CU"]);
                ph.TongTien = Convert.ToInt64(dt.Rows[0]["TONG_TIEN"]);
                ph.DaTra = Convert.ToInt64(dt.Rows[0]["DA_TRA"]);
                ph.ConNo = Convert.ToInt64(dt.Rows[0]["CON_NO"]);
                //NhaCungCapController ctrlNCC = new NhaCungCapController();
                //ph.NhaCungCap = ctrlNCC.LayNCC(Convert.ToString(dt.Rows[dt.Rows.Count - 1]["ID_NHA_CUNG_CAP"]));
                //ChiTietPhieuNhapController ctrl = new ChiTietPhieuNhapController();
                //ph.ChiTiet = ctrl.ChiTietPhieuNhap(ph.Id);
                return ph;
            }
            return null;
        }
    }
}
