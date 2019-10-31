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
    public partial class QuanLySanPhamMoi : Form
    {
        public QuanLySanPhamMoi()
        {
            InitializeComponent();
            ShowData();
        }
        public void ShowData()
        {
            DataService.OpenConnection();
            SanPhamMoiController CtrlSP = new SanPhamMoiController();
            CtrlSP.HienthiDataGridview(dataGridView1);
        }
    }
}
