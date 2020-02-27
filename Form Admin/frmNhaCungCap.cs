using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class frmNhaCungCap : Form
    {
        QuanLyKho.Controller.NhaCungCapController ctrl = new QuanLyKho.Controller.NhaCungCapController();
        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            ctrl.HienthiDataGridview(dataGridView, bindingNavigator);
        }

        private void toolThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAddress.Text = "";
            txtCompany.Text = "";
            txtPhone.Text = "";
            numHanNo.Value = 30;
            companySelected = "";
            btnClear.Enabled = false;
            btnLuu.Enabled = false;
        }
        string companySelected = "";
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            txtAddress.Text = row["DIA_CHI"].ToString();
            txtCompany.Text = row["HO_TEN"].ToString();
            txtPhone.Text = row["DIEN_THOAI"].ToString();
            numHanNo.Value = Convert.ToDecimal(row["THOI_HAN_NO"].ToString());
            companySelected = txtCompany.Text;
            btnLuu.Enabled = true;
            btnClear.Enabled = true;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (txtCompany.Text == String.Empty)
            {
                MessageBox.Show("Thiếu tên nhà cung cấp", "Nhà cung cấp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ctrl.NhaCungCapTonTai(txtCompany.Text))
            {
                MessageBox.Show("Nhà cung cấp này đã tồn tại", "Nhà cung cấp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            long maso = ThamSo.NhaCungCap;
            ThamSo.NhaCungCap = maso + 1;
            DataRow row = ctrl.NewRow();
            row["ID"] = maso;
            row["HO_TEN"] = txtCompany.Text;
            row["DIA_CHI"] = txtAddress.Text;
            row["DIEN_THOAI"] = txtPhone.Text;
            row["THOI_HAN_NO"] = numHanNo.Value;
            ctrl.ThemNhaCungCap(row);
            ctrl.HienthiDataGridview(dataGridView, bindingNavigator);
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtCompany.Text == String.Empty)
            {
                MessageBox.Show("Thiếu tên nhà cung cấp", "Nhà cung cấp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (companySelected != txtCompany.Text && ctrl.NhaCungCapTonTai(txtCompany.Text))
            {
                MessageBox.Show("Nhà cung cấp này đã tồn tại", "Nhà cung cấp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            row["HO_TEN"] = txtCompany.Text;
            row["DIA_CHI"] = txtAddress.Text;
            row["DIEN_THOAI"] = txtPhone.Text;
            row["THOI_HAN_NO"] = numHanNo.Value;
            ctrl.CapNhatNhaCungCap(row);
            dataGridView.Refresh();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (bindingNavigator.BindingSource.Count == 0) return;
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Nhà cung cấp", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
                ctrl.XoaNhaCungCap(row["ID"].ToString());
                bindingNavigator.BindingSource.RemoveCurrent();
                txtAddress.Text = "";
                txtCompany.Text = "";
                txtPhone.Text = "";
                numHanNo.Value = 30;
                companySelected = "";
                btnClear.Enabled = false;
                btnLuu.Enabled = false;
            }
        }
    }
}