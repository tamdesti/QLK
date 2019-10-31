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
    public partial class frmDonViTinh : Form
    {
        DonViTinhController ctrl = new DonViTinhController();
        public frmDonViTinh()
        {
            InitializeComponent();
        }
        private void frmDonViTinh_Load(object sender, EventArgs e)
        {
            ctrl.HienthiDataGridview(dataGridView, bindingNavigator);
        }

        private void toolThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDVT.Text = "";
            btnClear.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            txtDVT.Text = row["TEN_DON_VI"].ToString();
            btnLuu.Enabled = true;
            btnClear.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDVT.Text == String.Empty)
            {
                MessageBox.Show("Thiếu tên đơn vị tính", "Đơn vị tính", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ctrl.LayTenDVT(txtDVT.Text) != "")
            {
                MessageBox.Show("Đơn vị tính này đã tồn tại", "Đơn vị tính", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            long maso = ThamSo.DonViTinh;
            ThamSo.DonViTinh = maso + 1;
            DataRow row = ctrl.NewRow();
            row["ID"] = maso;
            row["TEN_DON_VI"] = txtDVT.Text;
            ctrl.ThemDonViTinh(row);
            ctrl.HienthiDataGridview(dataGridView, bindingNavigator);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtDVT.Text == String.Empty)
            {
                MessageBox.Show("Thiếu tên đơn vị tính", "Đơn vị tính", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            row["TEN_DON_VI"] = txtDVT.Text;
            ctrl.CapNhatDonViTinh(row);
            dataGridView.Refresh();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (bindingNavigator.BindingSource.Count == 0) return;
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Đơn vị tính", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
                ctrl.XoaDonViTinh(row["ID"].ToString());
                bindingNavigator.BindingSource.RemoveCurrent();
                txtDVT.Text = "";
                btnClear.Enabled = false;
                btnLuu.Enabled = false;
            }
        }
    }
}