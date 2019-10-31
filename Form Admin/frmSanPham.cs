using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuanLyKho.Controller;

namespace QuanLyKho
{
    public partial class frmSanPham : Form
    {
        SanPhamController ctrl = new SanPhamController();
        DonViTinhController ctrlDVT = new DonViTinhController();
        NhaCungCapController ctrlNCC = new NhaCungCapController();

        public frmSanPham()
        {
            InitializeComponent();
        }
        private void NumEnter(object sender, EventArgs e)
        {
            NumericUpDown currentNum = (NumericUpDown)sender;
            currentNum.Select(0, currentNum.Text.Length);
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            ctrlNCC.HienthiAutoComboBox(cbNCC);
            ctrlDVT.HienthiAutoComboBox(cmbDVT);          
            ReloadLSP();
            txtChiTietPhieuNhap.Enabled = false;
            QuanLyKho.BusinessObject.Util.AdjustColumnOrder(ref dataGridView);
        }

        private void toolLuu_Click(object sender, EventArgs e)
        {
            if (DataValidate() == 0) return;
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            row["TEN_SAN_PHAM"] = txtTenSanPham.Text;
            row["SO_LUONG"] = 0;
            row["ID_DON_VI_TINH"] = cmbDVT.SelectedValue;
            row["DAI"] = numDai.Value;
            row["RONG"] = numRong.Value;
            row["LI"] = numLi.Value;
            row["LOAI"] = cbLoai.Text;
            ctrl.CapNhatSanPham(row);
            dataGridView.Refresh();
        }
        private void ErrorMessage(string ErrorString)
        {
            MessageBox.Show(ErrorString, "Sản Phẩm", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private int DataValidate()
        {
            if (txtTenSanPham.Text == String.Empty)
            {
                ErrorMessage("Chưa nhập tên sản phẩm!");
                return 0;
            }
            return 1;
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (DataValidate() == 0) return;
            long maso = ThamSo.SanPham;
            ThamSo.SanPham = maso + 1;
            DataRow row = ctrl.NewRow();            
            row["ID"] = maso;
            row["TEN_SAN_PHAM"] = txtTenSanPham.Text;
            row["SO_LUONG"] = 0;
            row["ID_DON_VI_TINH"] = cmbDVT.SelectedValue;
            row["ID_NHA_CUNG_CAP"] = cbNCC.SelectedValue;
            row["DAI"] = numDai.Value;
            row["RONG"] = numRong.Value;
            row["LI"] = numLi.Value;
            row["LOAI"] = cbLoai.Text;
            row["GIA_NHAP"] = 0;
            ctrl.ThemSanPham(row);
            ReloadLSP();
        }

      
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (bindingNavigator.BindingSource.Count == 0) return;
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
                ctrl.XoaSanPham(row["ID"].ToString());
                bindingNavigator.BindingSource.RemoveCurrent();
            }
        }

        private void toolThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            
        }

        private void cbNCC_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ReloadLSP();
            
        }
        private void ReloadLSP()
        {
            if (cbNCC.SelectedValue == null) return;
            try
            {
                dataGridView.Columns.Remove("ID_DON_VI_TINH");
            }
            catch { }
            ctrlNCC.HienthiDataGridviewComboBox(colNCC);
            dataGridView.Columns.Add(ctrlDVT.HienthiDataGridViewComboBoxColumn());
            dataGridView.Columns["ID_DON_VI_TINH"].DisplayIndex = 4;
            ctrl.HienthiDataGridview(dataGridView, bindingNavigator, cbNCC.SelectedValue.ToString());
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenSanPham.Text = "";
            toolLuu.Enabled = false;       
        }

        private void CbNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadLSP();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            txtTenSanPham.Text = row["TEN_SAN_PHAM"].ToString();
            cmbDVT.SelectedValue = row["ID_DON_VI_TINH"];
            txtChiTietPhieuNhap.Text = row["ID"].ToString();
            numDai.Value = Convert.ToDecimal(row["DAI"]);
            numRong.Value = Convert.ToDecimal(row["RONG"]);
            numLi.Value = Convert.ToDecimal(row["LI"]);
            cbLoai.Text = row["LOAI"].ToString();
            toolLuu.Enabled = true;
            btnClear.Enabled = true;
        }

        private void cmbDVT_Leave(object sender, EventArgs e)
        {
            DonViTinhController dvt = new DonViTinhController();
            if (!dvt.LayDVT(cmbDVT.Text))
            {
                if (cmbDVT.Items.Count > 0)
                    cmbDVT.SelectedIndex = 0;
                else cmbDVT.Text = "";
            }
        }

        private void cmbNhaCungCap_Leave(object sender, EventArgs e)
        {
            if (cbNCC.Items.Count == 0) return;
            NhaCungCapController NCC = new NhaCungCapController();
            if (!NCC.NhaCungCapTonTai(cbNCC.Text)) cbNCC.SelectedIndex = 0;
        }
    }
}