using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QuanLyKho.BusinessObject;
using QuanLyKho.DataLayer;


namespace QuanLyKho.Controller
{
    public class KhachHangController
    {
        KhachHangFactory factory = new KhachHangFactory();

        public void HienthiDaiLyAutoComboBox(System.Windows.Forms.ComboBox cmb, bool loai = true)
        {
            cmb.DataSource = factory.DanhsachKhachHang(loai);
            cmb.DisplayMember = "DAI_LY";
            cmb.ValueMember = "ID";
            cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        }
        public void HienthiDaiLyToolStripComboBox(System.Windows.Forms.ToolStripComboBox cmb, bool loai = true)
        {
            cmb.ComboBox.DataSource = factory.DanhsachKhachHang(loai);
            cmb.ComboBox.DisplayMember = "DAI_LY";
            cmb.ComboBox.ValueMember = "ID";
            cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        }
        public IList<KhachHang> LayDanhsachKhachHang(Boolean loai)
        {
            KhachHangFactory KHfactory = new KhachHangFactory();
            DataTable tbl = KHfactory.DanhsachKhachHang(loai);
            IList<KhachHang> ds = new List<KhachHang>();
            foreach (DataRow row in tbl.Rows)
            {
                KhachHang kh = new KhachHang();
                kh.HoTen = row["HO_TEN"].ToString();
                kh.Id = row["ID"].ToString();
                kh.DiaChi = row["DIA_CHI"].ToString();
                kh.DienThoai = row["DIEN_THOAI"].ToString();
                kh.LoaiKH = Convert.ToBoolean(row["LOAI_KH"].ToString());
                kh.TenDaiLy = row["DAI_LY"].ToString();
                ds.Add(kh);
            }
            return ds;
        }
        public void HienthiAllDaiLyAutoComboBox(System.Windows.Forms.ComboBox cmb, bool loai = true)
        {
            IList<KhachHang> dsKH = this.LayDanhsachKhachHang(loai);
            IList<KhachHang> ds = new List<KhachHang>();
            ds.Add(new KhachHang("0", "Tất cả", "Tất cả"));
            foreach (KhachHang kh in dsKH)
                ds.Add(kh);
            cmb.DataSource = ds;
            cmb.DisplayMember = "TenDaiLy";
            cmb.ValueMember = "Id";
            cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        }
        //Hien thi khach hang
        public void HienthiAutoComboBox(System.Windows.Forms.ComboBox cmb, bool loai = false)
        {
            cmb.DataSource = factory.DanhsachKhachHang(loai);
            cmb.DisplayMember = "HO_TEN";
            cmb.ValueMember = "ID";
            cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        }
        public void HienthiAllKhachHangAutoComboBox(System.Windows.Forms.ComboBox cmb, bool loai = false)
        {
            IList<KhachHang> dsKH = this.LayDanhsachKhachHang(loai);
            IList<KhachHang> ds = new List<KhachHang>();
            ds.Add(new KhachHang("0", "Tất cả"));
            foreach (KhachHang kh in dsKH)
                ds.Add(kh);
            cmb.DataSource = ds;
            cmb.DisplayMember = "HoTen";
            cmb.ValueMember = "Id";
            cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        }
        public void HienthiChungAutoComboBox(System.Windows.Forms.ComboBox cmb)
        {
            cmb.DataSource = factory.DanhsachKhachHang();
            cmb.DisplayMember = "HO_TEN";
            cmb.ValueMember = "ID";
            cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        }

        public void HienthiKhachHangDataGridview(System.Windows.Forms.DataGridView dg, System.Windows.Forms.BindingNavigator bn)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            DataTable tbl = factory.DanhsachKhachHang(false);
            tbl.Columns[4].DefaultValue = false;
            bs.DataSource = tbl;
            bn.BindingSource = bs;
            dg.DataSource = bs;
            
        }

        public void HienthiKhachHangChungDataGridviewComboBox(System.Windows.Forms.DataGridViewComboBoxColumn cmb)
        {

            cmb.DataSource = factory.DanhsachKhachHang();
            cmb.DisplayMember = "HO_TEN";
            cmb.ValueMember = "ID";
            cmb.DataPropertyName = "ID_KHACH_HANG";
            cmb.HeaderText = "Khách hàng";

        }

        public void HienthiKhachHangDataGridviewComboBox(System.Windows.Forms.DataGridViewComboBoxColumn cmb)
        {
        
            cmb.DataSource = factory.DanhsachKhachHang(false);
            cmb.DisplayMember = "HO_TEN";
            cmb.ValueMember = "ID";
            cmb.DataPropertyName = "ID_KHACH_HANG";
            cmb.HeaderText = "Khách hàng";

        }
        public void HienthiDaiLyDataGridviewComboBox(System.Windows.Forms.DataGridViewComboBoxColumn cmb)
        {

            cmb.DataSource = factory.DanhsachKhachHang(true);
            cmb.DisplayMember = "DAI_LY";
            cmb.ValueMember = "ID";
            cmb.DataPropertyName = "ID_KHACH_HANG";
            cmb.HeaderText = "Đại lý";

        }
        public void HienthiDaiLyDataGridview(System.Windows.Forms.DataGridView dg, System.Windows.Forms.BindingNavigator bn)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            DataTable dt = new DataTable();
            dt = factory.DanhsachKhachHang(true);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
            bs.DataSource = dt;
            bn.BindingSource = bs;
            dg.DataSource = bs;

        }

        public void TimHoTen(String hoten, bool loai)
        {
            factory.TimHoTen(hoten, loai);
        }
        public void TimDiaChi(String diachi, bool loai)
        {
            factory.TimDiaChi(diachi, loai);
        }
        
        public KhachHang LayKhachHang(String id)
        {
            DataTable tbl = factory.LayKhachHang(id);
            KhachHang kh = new KhachHang();
            kh.Id = "";
            if (tbl.Rows.Count > 0)
            {
                kh.Id = Convert.ToString(tbl.Rows[0]["ID"]);
                kh.HoTen = Convert.ToString(tbl.Rows[0]["HO_TEN"]);
                kh.DienThoai = Convert.ToString(tbl.Rows[0]["DIEN_THOAI"]);
                kh.DiaChi = Convert.ToString(tbl.Rows[0]["DIA_CHI"]);
                kh.LoaiKH = Convert.ToBoolean(tbl.Rows[0]["LOAI_KH"]);
                kh.TenDaiLy = tbl.Rows[0]["DAI_LY"].ToString();
            }
            return kh;
        }
        public void CapNhatKhachHang(DataRowView row)
        {
            KhachHangFactory KHFactory = new KhachHangFactory();
            DataTable tbl = KHFactory.LayKhachHang(row["ID"].ToString());
            if (tbl.Rows.Count > 0)
            {
                tbl.Rows[0]["DAI_LY"] = row["DAI_LY"];
                tbl.Rows[0]["HO_TEN"] = row["HO_TEN"];
                tbl.Rows[0]["DIEN_THOAI"] = row["DIEN_THOAI"];
                tbl.Rows[0]["DIA_CHI"] = row["DIA_CHI"];
                KHFactory.Save();
            }
        }
        public void CapNhatKhachHang(KhachHang KH)
        {
            KhachHangFactory KHFactory = new KhachHangFactory();
            DataTable tbl = KHFactory.LayKhachHang(KH.Id);
            if (tbl.Rows.Count > 0)
            {
                tbl.Rows[0]["DAI_LY"] = KH.TenDaiLy;
                tbl.Rows[0]["HO_TEN"] = KH.HoTen;
                tbl.Rows[0]["DIEN_THOAI"] = KH.DienThoai;
                tbl.Rows[0]["DIA_CHI"] = KH.DiaChi;
                KHFactory.Save();
            }
        }
        public bool DaiLyTonTai(String tenDaiLy)
        {
            DataTable tbl = factory.LayDaiLyTuTenDaiLy(tenDaiLy);
            if (tbl.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool KhachHangTonTai(String tenKH)
        {
            DataTable tbl = factory.LayKhachHangTuTen(tenKH);
            if (tbl.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void ThemDaiLy(DataRow row)
        {
            factory.ThemDaiLy(row);
        }
        public void ThemKhachHang(DataRow row)
        {
            factory.ThemKhachHang(row);
        }
        public void ThemKhachHang(BusinessObject.KhachHang KH)
        {
            factory.ThemKhachHang(KH);
        }
        public void XoaKhachHang(String ID)
        {
            factory.XoaKhachHang(ID);
        }
        public IList<KhachHang> LayDanhSachKhachHang()
        {
            DataTable tbl = factory.DanhsachKhachHang();
            IList<KhachHang> ds = new List<KhachHang>();

            foreach (DataRow row in tbl.Rows)
            {
                KhachHang kh = new KhachHang();
                kh.Id = Convert.ToString(row["ID"]);
                kh.HoTen = Convert.ToString(row["HO_TEN"]);
                kh.DienThoai = Convert.ToString(row["DIEN_THOAI"]);
                kh.DiaChi = Convert.ToString(row["DIA_CHI"]);
                kh.LoaiKH = Convert.ToBoolean(row["LOAI_KH"]);
                ds.Add(kh);
            }
            return ds;
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
