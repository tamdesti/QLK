using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class frmKhachHang : Form
    {
        QuanLyKho.Controller.KhachHangController ctrl = new QuanLyKho.Controller.KhachHangController();
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {

            ctrl.HienthiKhachHangDataGridview(dataGridView, bindingNavigator);
        }

        private void toolLuu_Click(object sender, EventArgs e)
        {
            if (DataValidate() == 0) return;
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            row["HO_TEN"] = txtHoTen.Text;
            row["DIEN_THOAI"] = txtSDT.Text;
            row["DIA_CHI"] = txtDiaChi.Text;
            row["DAI_LY"] = string.Empty;
            ctrl.CapNhatKhachHang(row);
            dataGridView.Refresh();
            toolLuu.Enabled = false;
        }
        private void ErrorMessage(string ErrorString)
        {
            MessageBox.Show(ErrorString, "Đại lý", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private int DataValidate()
        {
            if (txtHoTen.Text == String.Empty)
            {
                ErrorMessage("Chưa nhập tên chủ đại lý!");
                return 0;
            }
            if (txtDiaChi.Text == "")
            {
                ErrorMessage("Chưa chọn nhóm sản phẩm!");
                return 0;
            }
            return 1;
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (DataValidate() == 0) return;
            long maso = ThamSo.KhachHang;
            ThamSo.KhachHang = maso + 1;
            DataRow row = ctrl.NewRow();
            row["ID"] = maso;
            row["HO_TEN"] = txtHoTen.Text;
            row["DAI_LY"] = string.Empty;
            row["DIEN_THOAI"] = txtSDT.Text;
            row["DIA_CHI"] = txtDiaChi.Text;
            row["LOAI_KH"] = true;
            ctrl.ThemKhachHang(row);
            ctrl.HienthiKhachHangDataGridview(dataGridView, bindingNavigator);
        }

        private void toolThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (bindingNavigator.BindingSource.Count == 0) return;
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Dai Ly", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
                ctrl.XoaKhachHang(row["ID"].ToString());
                bindingNavigator.BindingSource.RemoveCurrent();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            toolLuu.Enabled = false;
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            txtHoTen.Text = row["HO_TEN"].ToString();
            txtDiaChi.Text = row["DIA_CHI"].ToString();
            txtSDT.Text = row["DIEN_THOAI"].ToString();
            toolLuu.Enabled = true;
            btnClear.Enabled = true;
        }
    }
}