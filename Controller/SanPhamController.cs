using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using QuanLyKho.BusinessObject;
using QuanLyKho.DataLayer;


namespace QuanLyKho.Controller
{
    public class SanPhamController
    {
        SanPhamFactory factory = new SanPhamFactory();
        public IList<SanPham> LayDanhSachSanPham(string IDNhaCungCap)
        {
            DataTable tbl = factory.DanhsachSanPhamFullByNCC(IDNhaCungCap);
            IList<SanPham> ds = new List<SanPham>();
            DonViTinhController ctrlDVT = new DonViTinhController();
            foreach (DataRow row in tbl.Rows)
            {
                SanPham sp = new SanPham();
                sp.Id = Convert.ToString(row["ID"]);
                sp.TenSanPham = Convert.ToString(row["TEN_SAN_PHAM"]);
                sp.SoLuong = Convert.ToInt32(row["SO_LUONG"]);
                sp.DonViTinh = ctrlDVT.LayDVT(Convert.ToInt32(row["ID_DON_VI_TINH"]));
                sp.FullTenSanPham = row["FULL_TEN_SAN_PHAM"].ToString();
                ds.Add(sp);
            }
            return ds;
        }
        public IList<SanPham> LayDanhSachSanPhamByKho(string IDKHO)
        {
            DataTable tbl = factory.DanhSachSanPhamByKho(IDKHO);
            IList<SanPham> ds = new List<SanPham>();
            DonViTinhController ctrlDVT = new DonViTinhController();
            foreach (DataRow row in tbl.Rows)
            {
                SanPham sp = new SanPham();
                sp.Id = Convert.ToString(row["ID"]);
                sp.TenSanPham = Convert.ToString(row["TEN_SAN_PHAM"]);
                sp.DonViTinh = ctrlDVT.LayDVT(Convert.ToInt32(row["ID_DON_VI_TINH"]));
                sp.FullTenSanPham = row["TEN_SAN_PHAM"].ToString();
                ds.Add(sp);
            }
            return ds;
        }
        public void HienthiAutoComboBox(System.Windows.Forms.ComboBox cmb, String IDNCC, bool isAll = false)
        {
            SanPhamFactory SP = new SanPhamFactory();
            DataTable tbl = SP.DanhsachSanPhamByNCC(IDNCC);
            cmb.DataSource = tbl;
            cmb.DisplayMember = "TEN_SAN_PHAM";
            cmb.ValueMember = "ID";
            if (isAll)
            {
                IList<SanPham> dsSP = this.LayDanhSachSanPham(IDNCC);
                IList<SanPham> ds = new List<SanPham>();
                ds.Add(new SanPham("0", "Tất cả"));
                foreach (SanPham sp in dsSP)
                    ds.Add(sp);
                cmb.DataSource = ds;
                cmb.DisplayMember = "TenSanPham";
                cmb.ValueMember = "Id";
            }
            
            cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        }
        public void HienthiAutoComboBoxByKho(System.Windows.Forms.ComboBox cmb, String IDKHO, bool isAll = false)
        {
            IList<SanPham> tbl = this.LayDanhSachSanPhamByKho(IDKHO);
            cmb.DataSource = tbl;
            cmb.DisplayMember = "FullTenSanPham";
            cmb.ValueMember = "Id";
            if (isAll)
            {
                IList<SanPham> dsSP = this.LayDanhSachSanPhamByKho(IDKHO);
                IList<SanPham> ds = new List<SanPham>();
                ds.Add(new SanPham("0", "Tất cả"));
                foreach (SanPham sp in dsSP)
                    ds.Add(sp);
                cmb.DataSource = ds;
                cmb.DisplayMember = "FullTenSanPham";
                cmb.ValueMember = "Id";
            }

            cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        }
        public void HienthiDataGridViewComboBoxColumn(System.Windows.Forms.DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = factory.DanhsachSanPham();
            cmb.DisplayMember = "TEN_SAN_PHAM";
            cmb.ValueMember = "ID";
            cmb.AutoComplete = true;
        }
        public void TimChiTietPhieuNhap(String ma)
        {
            factory.TimChiTietPhieuNhap(ma);
        }
        public void TimTenSanPham(String ten)
        {
            factory.TimTenSanPham(ten);
        }

        public void HienthiDataGridview(System.Windows.Forms.DataGridView dg, System.Windows.Forms.BindingNavigator bn, string ID_NCC = "")
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            DataTable dt = new DataTable();
            dt = factory.DanhsachSanPham();
            if (ID_NCC != "") dt = factory.DanhsachSanPhamByNCC(ID_NCC);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void ExpiredProductListByDateAndCompanyID(System.Windows.Forms.DataGridView dg, DateTime dt, String CompanyName)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            SanPhamFactory f = new SanPhamFactory();
            bs.DataSource = f.DanhsachSanPhamHetHan(dt, CompanyName);
            dg.DataSource = bs;
        }
        public void AvaiableProductListByNCC(System.Windows.Forms.DataGridView dg, String NCC)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            SanPhamFactory f = new SanPhamFactory();
            DataTable dt = new DataTable();
            System.Windows.Forms.BindingNavigator bn = new BindingNavigator();
            dt = f.LaySoLuongTonByNCC(NCC);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void AvaiableProductListByKho(System.Windows.Forms.DataGridView dg, String IDKHO)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            SanPhamFactory f = new SanPhamFactory();
            DataTable dt = new DataTable();
            System.Windows.Forms.BindingNavigator bn = new BindingNavigator();
            dt = f.LaySoLuongTonByKho(IDKHO);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void AvaiableProductListBySP(System.Windows.Forms.DataGridView dg, string IDSP)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            SanPhamFactory f = new SanPhamFactory();
            DataTable dt = new DataTable();
            System.Windows.Forms.BindingNavigator bn = new BindingNavigator();
            dt = f.LaySoLuongTonBySP(IDSP);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
            
        }
        public void HangDaNhapByNCC(System.Windows.Forms.DataGridView dg, String NCC, DateTime fromdate, DateTime toDate)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            SanPhamFactory f = new SanPhamFactory();
            DataTable dt = new DataTable();
            System.Windows.Forms.BindingNavigator bn = new BindingNavigator();
            dt = f.LayHangDaNhapByNCC(NCC, fromdate, toDate);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HangDaNhapBySP(System.Windows.Forms.DataGridView dg, string IDSP, DateTime fromdate, DateTime toDate)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            SanPhamFactory f = new SanPhamFactory();
            DataTable dt = new DataTable();
            System.Windows.Forms.BindingNavigator bn = new BindingNavigator();
            dt = f.LayHangDaNhapBySP(IDSP, fromdate, toDate);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HangDaBanByNCC(System.Windows.Forms.DataGridView dg, String NCC, DateTime fromdate, DateTime toDate)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            SanPhamFactory f = new SanPhamFactory();
            DataTable dt = new DataTable();
            System.Windows.Forms.BindingNavigator bn = new BindingNavigator();
            dt = f.LayHangDaBanByNCC(NCC, fromdate, toDate);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HangDaBanBySP(System.Windows.Forms.DataGridView dg, string IDSP, DateTime fromdate, DateTime toDate)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            SanPhamFactory f = new SanPhamFactory();
            DataTable dt = new DataTable();
            System.Windows.Forms.BindingNavigator bn = new BindingNavigator();
            dt = f.LayHangDaBanBySP(IDSP, fromdate, toDate);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public bool CohangSapHetHan()
        {
            BusinessObject.CuaHang ch = ThamSo.LayCuaHang();
            SanPhamFactory f = new SanPhamFactory();
            DataTable dt = new DataTable();
            dt = f.LayHangGanHetHan(ch.NgayBaoHetHan);
            return (dt.Rows.Count > 0);
        }
        public void HangGanHetHan(System.Windows.Forms.DataGridView dg)
        {
            BusinessObject.CuaHang ch = ThamSo.LayCuaHang();
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            SanPhamFactory f = new SanPhamFactory();
            DataTable dt = new DataTable();
            System.Windows.Forms.BindingNavigator bn = new BindingNavigator();
            dt = f.LayHangGanHetHan(ch.NgayBaoHetHan);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HangHetHanByNCC(System.Windows.Forms.DataGridView dg, String NCC)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            SanPhamFactory f = new SanPhamFactory();
            DataTable dt = new DataTable();
            System.Windows.Forms.BindingNavigator bn = new BindingNavigator();
            dt = f.LayHangHetHanByNCC(NCC);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HangHetHanBySP(System.Windows.Forms.DataGridView dg, string IDSP)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            SanPhamFactory f = new SanPhamFactory();
            DataTable dt = new DataTable();
            System.Windows.Forms.BindingNavigator bn = new BindingNavigator();
            dt = f.LayHangHetHanBySP(IDSP);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public decimal LaySoLuongSanPham(String id)
        {
            return Convert.ToDecimal(factory.SoLuongSanPham(id));
        }
        public void CapNhatSanPham(DataRowView row)
        {
            SanPhamFactory SPFactory = new SanPhamFactory();
            DataTable tbl = SPFactory.LaySanPham(row["ID"].ToString());
            if (tbl.Rows.Count > 0)
            {
                tbl.Rows[0]["TEN_SAN_PHAM"] = row["TEN_SAN_PHAM"];
                tbl.Rows[0]["ID_DON_VI_TINH"] = row["ID_DON_VI_TINH"];
                tbl.Rows[0]["DAI"] = row["DAI"];
                tbl.Rows[0]["RONG"] = row["RONG"];
                tbl.Rows[0]["LI"] = row["LI"];
                tbl.Rows[0]["LOAI"] = row["LOAI"];
                SPFactory.Save();
            }
        }
        public void CapNhatDonGiaNhap(SanPham sp)
        {
            SanPhamFactory SPFactory = new SanPhamFactory();
            DataTable tbl = SPFactory.LaySanPham(sp.Id);
            if (tbl.Rows.Count > 0)
            {
                tbl.Rows[0]["GIA_NHAP"] = sp.DonGiaNhap;
                SPFactory.Save();
            }
        }
        public void CapNhatSoLuongSanPham(String ID, Decimal Soluong)
        {
            SanPhamFactory SPFactory = new SanPhamFactory();
            DataTable tbl = SPFactory.LaySanPham(ID);
            if (tbl.Rows.Count > 0)
            {
                tbl.Rows[0]["SO_LUONG"] = Soluong;
                SPFactory.Save();
            }
        }
        public void ThemSanPham(DataRow row)
        {
            factory.ThemSanPham(row);
        }
        public void XoaSanPham(String ID)
        {
            factory.XoaSanPham(ID);
        }
        public SanPham LaySanPham(String id)
        {
            DataTable tbl = factory.LaySanPham(id);
            SanPham sp = null;
            DonViTinhController ctrlDVT = new DonViTinhController();
            NhaCungCapController NCC = new NhaCungCapController();
            if (tbl.Rows.Count > 0)
            {
                sp = new SanPham();
                sp.Id = Convert.ToString(tbl.Rows[0]["ID"]);
                sp.TenSanPham =  Convert.ToString(tbl.Rows[0]["TEN_SAN_PHAM"]);
                sp.SoLuong = Convert.ToInt32(tbl.Rows[0]["SO_LUONG"]);
                sp.DonViTinh = ctrlDVT.LayDVT(Convert.ToInt32(tbl.Rows[0]["ID_DON_VI_TINH"]));
                sp.NhaCungCap = NCC.LayNCC(tbl.Rows[0]["ID_NHA_CUNG_CAP"].ToString());
                sp.Dai = Convert.ToInt64(tbl.Rows[0]["DAI"]);
                sp.Rong = Convert.ToInt64(tbl.Rows[0]["RONG"]);
                sp.Li = Convert.ToInt32(tbl.Rows[0]["LI"]);
                sp.Loai = Convert.ToString(tbl.Rows[0]["LOAI"]);
            }
            return sp;
        }
        public Boolean SanPhamDaTonTai_coDVT(String ten)
        {
            DataTable tbl = factory.LaySanPhamTuTenVaDVT(ten);
            if (tbl.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public Boolean SanPhamDaTonTai(String ten)
        {
            DataTable tbl = factory.LaySanPhamTuTen(ten);
            if (tbl.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public DataRow NewRow()
        {
            return factory.NewRow();
        }
        public void Add(DataRow row)
        {
            factory.Add(row);
        }
        public bool Save()
        {
            return factory.Save();
        }
    }
}
