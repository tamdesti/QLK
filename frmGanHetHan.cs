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
    public partial class frmGanHetHan : Form
    {
        public frmGanHetHan()
        {
            InitializeComponent();
        }
        SanPhamController ctrlSanPham = new SanPhamController();
        private void frmGanHetHan_Load(object sender, EventArgs e)
        {
            DonViTinhController DVTCtrl = new DonViTinhController();
            DVTCtrl.HienthiDataGridViewComboBoxColumn(colDVT);
            ctrlSanPham.HangGanHetHan(dataGridView1);
            dataGridView1.Columns["colDonGiaNhap"].Visible = false;
            dataGridView1.Columns["colNgaySanXuat"].Visible = false;
            dataGridView1.Columns["colNgayNhap"].Visible = false;
            dataGridView1.Columns["Số lượng tồn"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Số lượng tồn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Số lượng bán"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Số lượng bán"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Khuyến mãi"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Khuyến mãi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Số lượng nhập"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Số lượng nhập"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Tổng tiền bán"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Tổng tiền bán"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Tổng tiền nhập"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Tổng tiền nhập"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Còn hạn (ngày)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.Text = "SẢN PHẨM TỒN KHO";
            BusinessObject.Util.AdjustColumnOrder(ref dataGridView1);
            ReArrangeColumn();
        }
        private void ReArrangeColumn()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns["colLoID"].DisplayIndex = 1;
            dataGridView1.Columns["colTenSanPham"].DisplayIndex = 2;
            dataGridView1.Columns["colDVT"].DisplayIndex = 3;
            dataGridView1.Columns["Số lượng nhập"].DisplayIndex = 4;
            dataGridView1.Columns["Tổng tiền nhập"].DisplayIndex = 5;
            dataGridView1.Columns["Số lượng bán"].DisplayIndex = 6;
            dataGridView1.Columns["Khuyến mãi"].DisplayIndex = 7;
            dataGridView1.Columns["Tổng tiền bán"].DisplayIndex = 8;
            dataGridView1.Columns["Số lượng tồn"].DisplayIndex = 9;
            dataGridView1.Columns["colNgayHetHan"].DisplayIndex = 10;
            dataGridView1.Columns["Còn hạn (ngày)"].DisplayIndex = 11;
        }
    }
}
