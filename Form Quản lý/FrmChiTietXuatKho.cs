using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKho.Controller;

namespace QuanLyKho
{
    public partial class FrmChiTietXuatKho : Form
    {
        public FrmChiTietXuatKho()
        {
            InitializeComponent();
        }
        PhieuBanController PB = new PhieuBanController();
        SanPhamController ctrlSanPham = new SanPhamController();
        KhoHangController ctrlKho = new KhoHangController();
        private void FrmChiTietXuatKho_Load(object sender, EventArgs e)
        {
            fromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            ctrlKho.HienthiAllComboBox(cmbKho, false);
            ctrlSanPham.HienthiAutoComboBoxByKho(cmbSanPham, cmbKho.SelectedValue.ToString(), true);
            PB.HienThiChiTietXuatKhoTheoSanPham(dataGridView1, cmbSanPham.SelectedValue.ToString(), cmbKho.SelectedValue.ToString(), fromDate.Value, toDate.Value);
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            dataGridView1.Columns["Tên Khách hàng"].Width = 300;
            dataGridView1.Columns["Số lượng"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Số lượng"].Width = 120;
            dataGridView1.Columns["Đơn giá"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Đơn giá"].Width = 120;
            dataGridView1.Columns["Tiền hàng"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Tiền hàng"].Width = 120;
            dataGridView1.Columns["Loại"].Visible = false;
        }
        private void cmbKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            ctrlSanPham.HienthiAutoComboBoxByKho(cmbSanPham, cmbKho.SelectedValue.ToString(), true);
        }

        private void cmbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            SanPhamLoading();
        }
        public void SanPhamLoading()
        {
            PB.HienThiChiTietXuatKhoTheoSanPham(dataGridView1, cmbSanPham.SelectedValue.ToString(), cmbKho.SelectedValue.ToString(), fromDate.Value, toDate.Value);
        }
        private void fromDate_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void toDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (toDate.Value < fromDate.Value)
                {
                    MessageBox.Show("Ngày cuối phải lớn hơn hoặc bằng ngày bắt đầu", "Lỗi ngày lọc");
                    fromDate.Value = toDate.Value;
                }
                SanPhamLoading();
            }
        }
        private void cmbKho_Leave(object sender, EventArgs e)
        {
            KhoHangController KH = new KhoHangController();
            if (!KH.KhoTonTai(cmbKho.Text)) cmbKho.SelectedIndex = 0;
        }
        private void cmbSanPham_Leave(object sender, EventArgs e)
        {
            SanPhamController SP = new SanPhamController();
            if (!SP.SanPhamDaTonTai(cmbSanPham.Text))
            {
                if (cmbSanPham.Items.Count > 0)
                    cmbSanPham.SelectedIndex = 0;
                else
                    cmbSanPham.Text = "";
            }
        }
        private void toDate_ValueChanged(object sender, EventArgs e)
        {
            if (toDate.Value < fromDate.Value)
            {
                MessageBox.Show("Ngày cuối phải lớn hơn hoặc bằng ngày bắt đầu", "Lỗi ngày lọc");
                fromDate.Value = toDate.Value;
                return;
            }
            SanPhamLoading();
        }

        private void fromDate_ValueChanged(object sender, EventArgs e)
        {
            if (toDate.Value < fromDate.Value)
            {
                MessageBox.Show("Ngày cuối phải lớn hơn hoặc bằng ngày bắt đầu", "Lỗi ngày lọc");
                fromDate.Value = new DateTime(toDate.Value.Year, toDate.Value.Month, 1); 
                return;
            }
            SanPhamLoading();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmInChiTietXuatKhoTheoSanPham frm = new frmInChiTietXuatKhoTheoSanPham(dataGridView1, fromDate.Value, toDate.Value, cmbSanPham.Text);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }
    }
}
