using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QuanLyKho.BusinessObject;
using QuanLyKho.DataLayer;

namespace QuanLyKho.Controller
{
    public class KhoHangController
    {
        KhoHangFactory factory = new KhoHangFactory();
        public void HienthiAllComboBox(System.Windows.Forms.ComboBox cmb, bool selectnone = true)
        {
            IList<KhoHang> dsNCC = this.LayDanhSachKho();
            IList<KhoHang> ds = new List<KhoHang>();
            if (selectnone)
                ds.Add(new KhoHang("-1", "--- Chọn Kho ---"));
            ds.Add(new KhoHang("0", "Tất cả"));
            foreach (KhoHang ncc in dsNCC)
                ds.Add(ncc);
            cmb.DataSource = ds;
            cmb.DisplayMember = "TenKho";
            cmb.ValueMember = "Id";
            cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;

        }
        public void HienthiAutoComboBox(System.Windows.Forms.ComboBox cmb)
        {
            DataTable tbl = factory.DanhSachKho();
            cmb.DataSource = tbl;
            cmb.DisplayMember = "TEN_KHO";
            cmb.ValueMember = "ID";
            cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        }
        public System.Windows.Forms.DataGridViewComboBoxColumn HienthiDataGridViewComboBoxColumn()
        {
            System.Windows.Forms.DataGridViewComboBoxColumn cmb = new System.Windows.Forms.DataGridViewComboBoxColumn();
            DataTable tbl = factory.DanhSachKho();
            cmb.DataSource = tbl;
            cmb.DisplayMember = "TEN_KHO";
            cmb.ValueMember = "ID";
            cmb.DataPropertyName = "ID_KHO";
            cmb.HeaderText = "Kho";
            cmb.Name = "ID_KHO";
            return cmb;
        }
        private IList<KhoHang> LayDanhSachKho()
        {
            DataTable tbl = factory.DanhSachKho();
            IList<KhoHang> ds = new List<KhoHang>();

            foreach (DataRow row in tbl.Rows)
            {
                KhoHang kh = new KhoHang();
                kh.Id = Convert.ToString(row["ID"]);
                kh.TenKho = Convert.ToString(row["TEN_KHO"]);
                kh.DiaChiKho = Convert.ToString(row["DIA_CHI_KHO"]);
                ds.Add(kh);
            }
            return ds;
        }
        public void HienthiDataGridview(System.Windows.Forms.DataGridView dg, System.Windows.Forms.BindingNavigator bn)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            DataTable dt = factory.DanhSachKho();
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HienthiDataGridViewComboBoxColumn(System.Windows.Forms.DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = factory.DanhSachKho();
            cmb.DisplayMember = "TEN_KHO";
            cmb.ValueMember = "ID";
            cmb.AutoComplete = true;
        }
        public DonViTinh LayKho(int id)
        {
            DataTable tbl = factory.LayKho(id);
            DonViTinh dvt = null;
            if (tbl.Rows.Count > 0)
            {
                dvt = new DonViTinh(Convert.ToInt32(tbl.Rows[0]["ID"]), Convert.ToString(tbl.Rows[0]["TEN_KHO"]));
            }
            return dvt;
        }
        public Boolean LayKho(string ten)
        {
            DataTable tbl = factory.LayKho(ten);
            if (tbl.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public String LayTenKho(string ten)
        {
            DataTable tbl = factory.LayKho(ten);
            if (tbl.Rows.Count > 0)
            {
                return tbl.Rows[0]["TEN_KHO"].ToString();
            }
            return "";
        }
        public long LaySoLuongTonByKho(string IDSP, string IDKHO)
        {
            return factory.LaySoLuongTonByKho(IDSP, IDKHO);
        }
        public void CapNhatSoLuongTon(string IDSP, String IDKHO, decimal Soluong)
        {
            KhoHangFactory KhoFactory = new KhoHangFactory();
            DataTable tbl = KhoFactory.LayChiTietPhieuNhapConHang(IDSP, IDKHO);
            decimal ton = 0;
            foreach (DataRow row in tbl.Rows)
            {
                ton = Soluong - Convert.ToInt64(row["SO_LUONG_TON"]);
                if (ton > 0)
                {
                    Soluong = Soluong - Convert.ToInt64(row["SO_LUONG_TON"]);
                    row["SO_LUONG_TON"] = 0;
                }
                else
                {
                    row["SO_LUONG_TON"] = Convert.ToInt64(row["SO_LUONG_TON"]) - Soluong;
                    break;
                }
            }
            KhoFactory.Save();
        }
        public bool KhoTonTai(String tenKho)
        {
            DataTable tbl = factory.LayKho(tenKho);
            if (tbl.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool Save()
        {
            return factory.Save();
        }
        public DataRow NewRow()
        {
            return factory.NewRow();
        }
        public void Add(DataRow row)
        {
            factory.Add(row);
        }
        public void ThemKho(DataRow row)
        {
            factory.ThemKho(row);
        }
        public void CapNhatKho(DataRowView row)
        {
            KhoHangFactory Kho = new KhoHangFactory();
            DataTable tbl = Kho.LayKho(Convert.ToInt32(row["ID"]));
            if (tbl.Rows.Count > 0)
            {
                tbl.Rows[0]["TEN_KHO"] = row["TEN_KHO"];
                tbl.Rows[0]["DIA_CHI_KHO"] = row["DIA_CHI_KHO"];
                Kho.Save();
            }
        }
        public void XoaKho(String ID)
        {
            factory.XoaKho(ID);
        }
    }
}
