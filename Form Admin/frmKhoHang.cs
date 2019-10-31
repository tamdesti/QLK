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
    public partial class frmKhoHang : Form
    {
        KhoHangController ctrl = new KhoHangController();
        public frmKhoHang()
        {
            InitializeComponent();
        }

        private void frmKhoHang_Load(object sender, EventArgs e)
        {
            ctrl.HienthiDataGridview(dataGridView, bindingNavigator);
        }

        private void toolThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenKho.Text = "";
            txtAddress.Text = "";
            btnClear.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            txtTenKho.Text = row["TEN_KHO"].ToString();
            txtAddress.Text = row["DIA_CHI_KHO"].ToString();
            btnLuu.Enabled = true;
            btnClear.Enabled = true;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (txtTenKho.Text == String.Empty)
            {
                MessageBox.Show("Thiếu tên Kho", "Kho hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ctrl.LayKho(txtTenKho.Text))
            {
                MessageBox.Show("Kho này đã tồn tại", "Kho hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            long maso = ThamSo.KhoHang;
            ThamSo.KhoHang = maso + 1;
            DataRow row = ctrl.NewRow();
            row["ID"] = maso;
            row["TEN_KHO"] = txtTenKho.Text;
            row["DIA_CHI_KHO"] = txtAddress.Text;
            ctrl.ThemKho(row);
            ctrl.HienthiDataGridview(dataGridView, bindingNavigator);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenKho.Text == String.Empty)
            {
                MessageBox.Show("Thiếu tên kho", "Kho Hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            row["TEN_KHO"] = txtTenKho.Text;
            row["DIA_CHI_KHO"] = txtAddress.Text;
            ctrl.CapNhatKho(row);
            dataGridView.Refresh();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (bindingNavigator.BindingSource.Count == 0) return;
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Kho hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
                ctrl.XoaKho(row["ID"].ToString());
                bindingNavigator.BindingSource.RemoveCurrent();
                txtTenKho.Text = "";
                txtAddress.Text = "";
                btnClear.Enabled = false;
                btnLuu.Enabled = false;
            }
        }
    }
}
