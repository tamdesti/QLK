using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QuanLyKho.BusinessObject;
using QuanLyKho.DataLayer;


namespace QuanLyKho.Controller
{
    public class DonViTinhController
    {
        DonViTinhFactory factory = new DonViTinhFactory();

        public void HienthiAutoComboBox(System.Windows.Forms.ComboBox cmb)
        {
            DataTable tbl = factory.DanhsachDVT();
            cmb.DataSource = tbl;
            cmb.DisplayMember = "TEN_DON_VI";
            cmb.ValueMember = "ID";
            cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        }
        public System.Windows.Forms.DataGridViewComboBoxColumn HienthiDataGridViewComboBoxColumn()
        {
            System.Windows.Forms.DataGridViewComboBoxColumn cmb = new System.Windows.Forms.DataGridViewComboBoxColumn();
            DataTable tbl = factory.DanhsachDVT();
            cmb.DataSource = tbl;
            cmb.DisplayMember = "TEN_DON_VI";
            cmb.ValueMember = "ID";
            cmb.DataPropertyName = "ID_DON_VI_TINH";
            cmb.HeaderText = "Đơn vị tính";
            cmb.Name = "ID_DON_VI_TINH";
            return cmb;
        }
        public void HienthiDataGridview(System.Windows.Forms.DataGridView dg, System.Windows.Forms.BindingNavigator bn)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            DataTable dt = factory.DanhsachDVT();
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HienthiDataGridViewComboBoxColumn(System.Windows.Forms.DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = factory.DanhsachDVT();
            cmb.DisplayMember = "TEN_DON_VI";
            cmb.ValueMember = "ID";
            cmb.AutoComplete = true;
        }
        public DonViTinh LayDVT(int id)
        {
            DataTable tbl = factory.LayDVT(id);
            DonViTinh dvt = null;
            if (tbl.Rows.Count > 0)
            {
                dvt = new DonViTinh(Convert.ToInt32(tbl.Rows[0]["ID"]), Convert.ToString(tbl.Rows[0]["TEN_DON_VI"]));
            }
            return dvt;
        }
        public Boolean LayDVT(string ten)
        {
            DataTable tbl = factory.LayDVT(ten);
            if (tbl.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public String LayTenDVT(string ten)
        {
            DataTable tbl = factory.LayDVT(ten);
            if (tbl.Rows.Count > 0)
            {
                return tbl.Rows[0]["TEN_DON_VI_TINH"].ToString();
            }
            return "";
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
        public void ThemDonViTinh(DataRow row)
        {
            factory.ThemDonViTinh(row);
        }
        public void CapNhatDonViTinh(DataRowView row)
        {
            DonViTinhFactory DVT = new DonViTinhFactory();
            DataTable tbl = DVT.LayDVT(Convert.ToInt32(row["ID"]));
            if (tbl.Rows.Count > 0)
            {
                tbl.Rows[0]["TEN_DON_VI"] = row["TEN_DON_VI"];
                DVT.Save();
            }
        }
        public void XoaDonViTinh(String ID)
        {
            factory.XoaDonViTinh(ID);
        }
    }
}
