using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QuanLyKho.BusinessObject;
using QuanLyKho.DataLayer;


namespace QuanLyKho.Controller
{
    public class NhaCungCapController
    {
        NhaCungCapFactory factory = new  NhaCungCapFactory();

        public void HienthiAutoComboBox(System.Windows.Forms.ComboBox cmb)
        {
            cmb.DataSource = factory.DanhsachNCC();
            cmb.DisplayMember = "HO_TEN";
            cmb.ValueMember = "ID";
            cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;

        }
        public void HienthiAllComboBox(System.Windows.Forms.ComboBox cmb, bool selectnone = true)
        {
            IList<NhaCungCap> dsNCC = this.LayDanhSachNCC();
            IList<NhaCungCap> ds = new List<NhaCungCap>();
            if (selectnone)
                ds.Add(new NhaCungCap("-1", "--- Chọn nhà cung cấp ---"));
            ds.Add(new NhaCungCap("0","Tất cả"));
            foreach (NhaCungCap ncc in dsNCC)
                ds.Add(ncc);            
            cmb.DataSource = ds;
            cmb.DisplayMember = "HoTen";
            cmb.ValueMember = "Id";
            cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;

        }
        public System.Windows.Forms.DataGridViewComboBoxColumn HienthiDataGridViewComboBoxColumn()
        {
            System.Windows.Forms.DataGridViewComboBoxColumn cmb = new System.Windows.Forms.DataGridViewComboBoxColumn();
            DataTable tbl = factory.DanhsachNCC();
            cmb.DataSource = tbl;
            cmb.DisplayMember = "HO_TEN";
            cmb.ValueMember = "ID";
            cmb.DataPropertyName = "ID_NHA_CUNG_CAP";
            cmb.HeaderText = "Nhà cung cấp";
            cmb.Name = "ID_NHA_CUNG_CAP";
            return cmb;
        }
        public void HienthiDataGridview(System.Windows.Forms.DataGridView dg, System.Windows.Forms.BindingNavigator bn)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            DataTable dt = factory.DanhsachNCC();
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);

        }
        public void HienthiDataGridviewComboBox(System.Windows.Forms.DataGridViewComboBoxColumn cmb)
        {
            NhaCungCapFactory ncc = new NhaCungCapFactory();
            cmb.DataSource = ncc.DanhsachNCC();
            cmb.DisplayMember = "HO_TEN";
            cmb.ValueMember = "ID";
            cmb.AutoComplete = true;
        }
        
        public NhaCungCap LayNCC(String id)
        {
            DataTable tbl = factory.LayNCC(id);
            NhaCungCap ncc = new NhaCungCap();
            if (tbl.Rows.Count > 0)
            {
                ncc.Id = Convert.ToString(tbl.Rows[0]["ID"]);
                ncc.HoTen = Convert.ToString(tbl.Rows[0]["HO_TEN"]);
                ncc.DienThoai = Convert.ToString(tbl.Rows[0]["DIEN_THOAI"]);
                ncc.DiaChi = Convert.ToString(tbl.Rows[0]["DIA_CHI"]);
                ncc.ThoiHanNo = Convert.ToInt16(tbl.Rows[0]["THOI_HAN_NO"]);
            }
            return ncc;
        }
        public bool NhaCungCapTonTai(String tenNCC)
        {
            DataTable tbl = factory.LayNCCTuTen(tenNCC);
            if (tbl.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public IList<NhaCungCap> LayDanhSachNCC()
        {
            DataTable tbl = factory.DanhsachNCC();
            IList<NhaCungCap> ds = new List<NhaCungCap>();

            foreach (DataRow row in tbl.Rows)
            {
                NhaCungCap kh = new NhaCungCap();
                kh.Id = Convert.ToString(row["ID"]);
                kh.HoTen = Convert.ToString(row["HO_TEN"]);
                kh.DienThoai = Convert.ToString(row["DIEN_THOAI"]);
                kh.DiaChi = Convert.ToString(row["DIA_CHI"]);
                kh.ThoiHanNo = Convert.ToInt16(row["THOI_HAN_NO"]);
                ds.Add(kh);
            }
            return ds;
        }
        public double LayThoiHanNoTuNCC(String ID)
        {
            DataTable tbl = factory.LayNCC(ID);
            if (tbl.Rows.Count > 0)
            {
                return Convert.ToDouble(tbl.Rows[0]["THOI_HAN_NO"]);
            }
            return 0;
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
        public void ThemNhaCungCap(DataRow row)
        {
            factory.ThemNhaCungCap(row);
        }
        public void CapNhatNhaCungCap(DataRowView row)
        {
            NhaCungCapFactory NCC = new NhaCungCapFactory();
            DataTable tbl = NCC.LayNCC(row["ID"].ToString());
            if (tbl.Rows.Count > 0)
            {
                tbl.Rows[0]["HO_TEN"] = row["HO_TEN"];
                tbl.Rows[0]["DIA_CHI"] = row["DIA_CHI"];
                tbl.Rows[0]["DIEN_THOAI"] = row["DIEN_THOAI"];
                tbl.Rows[0]["THOI_HAN_NO"] = row["THOI_HAN_NO"];
                NCC.Save();
            }
        }
        public void XoaNhaCungCap(String ID)
        {
            factory.XoaNhaCungCap(ID);
        }
    }
}
