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
    public partial class FrmChiTietXuatKhoTheoKhachHang : Form
    {
        public FrmChiTietXuatKhoTheoKhachHang()
        {
            InitializeComponent();
        }
        PhieuBanController PB = new PhieuBanController();
        KhoHangController ctrlKho = new KhoHangController();
        KhachHangController ctrlKhach = new KhachHangController();
        private void FrmChiTietXuatKhoTheoKhachHang_Load(object sender, EventArgs e)
        {
            fromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            ctrlKho.HienthiAllComboBox(cmbKho, false);
            ctrlKhach.HienthiAllKhachHangAutoComboBox(cmbKhachHang);
            PB.HienThiChiTietXuatKhoTheoKhachHang(dataGridView1, cmbKhachHang.SelectedValue.ToString(), cmbKho.SelectedValue.ToString(), fromDate.Value, toDate.Value);
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            try
            {
                dataGridView1.Columns["Mặt hàng"].Width = 300;
                dataGridView1.Columns["Số lượng"].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns["Số lượng"].Width = 120;
                dataGridView1.Columns["Đơn giá"].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns["Đơn giá"].Width = 120;
                dataGridView1.Columns["Tiền hàng"].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns["Tiền hàng"].Width = 120;
                dataGridView1.Columns["Loại"].Visible = false;
            }
            catch { }
        }
        private void cmbKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLoading();
        }
        public void DataLoading()
        {
            if (cmbKhachHang.SelectedValue != null)
                PB.HienThiChiTietXuatKhoTheoKhachHang(dataGridView1, cmbKhachHang.SelectedValue.ToString(), cmbKho.SelectedValue.ToString(), fromDate.Value, toDate.Value);
        }
        private void fromDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (toDate.Value < fromDate.Value)
                {
                    MessageBox.Show("Ngày cuối phải lớn hơn hoặc bằng ngày bắt đầu", "Lỗi ngày lọc");
                    fromDate.Value = toDate.Value;
                }
                DataLoading();
            }
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
                DataLoading();
            }
        }
        private void cmbKho_Leave(object sender, EventArgs e)
        {
            KhoHangController KH = new KhoHangController();
            if (!KH.KhoTonTai(cmbKho.Text)) cmbKho.SelectedIndex = 0;
        }
        private void toDate_ValueChanged(object sender, EventArgs e)
        {
            if (toDate.Value < fromDate.Value)
            {
                MessageBox.Show("Ngày cuối phải lớn hơn hoặc bằng ngày bắt đầu", "Lỗi ngày lọc");
                fromDate.Value = toDate.Value;
                return;
            }
            DataLoading();
        }

        private void fromDate_ValueChanged(object sender, EventArgs e)
        {
            if (toDate.Value < fromDate.Value)
            {
                MessageBox.Show("Ngày cuối phải lớn hơn hoặc bằng ngày bắt đầu", "Lỗi ngày lọc");
                fromDate.Value = new DateTime(toDate.Value.Year, toDate.Value.Month, 1);
                return;
            }
            DataLoading();
        }

        private void cmbKhachHang_Leave(object sender, EventArgs e)
        {
            KhachHangController Khach = new KhachHangController();
            if (!Khach.KhachHangTonTai(cmbKhachHang.Text))
            {
                if (cmbKhachHang.Items.Count > 0)
                    cmbKhachHang.SelectedIndex = 0;
                else
                    cmbKhachHang.Text = "";
            }
        }

        private void cmbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLoading();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmInChiTietXuatKhoTheoKhachHang frm = new frmInChiTietXuatKhoTheoKhachHang(dataGridView1, fromDate.Value, toDate.Value, cmbKhachHang.Text);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }
    }
}
