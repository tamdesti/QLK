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
    public partial class frmDanhSachKhoanPhaiThu : Form
    {
        public frmDanhSachKhoanPhaiThu()
        {
            InitializeComponent();
        }
        PhieuBanController PB = new PhieuBanController();
        private void frmDanhSachKhoanPhaiThu_Load(object sender, EventArgs e)
        {
            PB.HienThiDanhSachCacKhoanPhaiThu(dataGridView1);
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }            
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns["ID_KHACH_HANG"].Visible = false;
            dataGridView1.Columns["Tên Khách hàng"].DisplayIndex = 2;
            dataGridView1.Columns["Tên Khách hàng"].Width = 300;
            dataGridView1.Columns["Địa chỉ"].DisplayIndex = 3;
            dataGridView1.Columns["Địa chỉ"].Width = 200;
            dataGridView1.Columns["Nợ đầu kỳ"].DisplayIndex = 4;
            dataGridView1.Columns["Nợ đầu kỳ"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Nợ đầu kỳ"].Width = 120;
            dataGridView1.Columns["Phát sinh tăng"].DisplayIndex = 5;
            dataGridView1.Columns["Phát sinh tăng"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Phát sinh tăng"].Width = 120;
            dataGridView1.Columns["Phát sinh giảm"].DisplayIndex = 6;
            dataGridView1.Columns["Phát sinh giảm"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Phát sinh giảm"].Width = 120;
            dataGridView1.Columns["Nợ hiện tại"].DisplayIndex = 7;
            dataGridView1.Columns["Nợ hiện tại"].Width = 120;
            dataGridView1.Columns["Nợ hiện tại"].DefaultCellStyle.Format = "N0";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                decimal tang = 0;
                Decimal.TryParse(dataGridView1[4, i].Value.ToString(), out tang);
                decimal giam = 0;
                Decimal.TryParse(dataGridView1[5, i].Value.ToString(), out giam);
                decimal nohientai = Convert.ToDecimal(dataGridView1[6, i].Value);
                decimal nodauky = nohientai + giam - tang;
                dataGridView1[3, i].Value = Math.Round(nodauky / 1000, 0) * 1000;
            }
        }
    }
}
