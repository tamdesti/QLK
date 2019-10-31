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
    public partial class frmTimPhieuNhap : Form
    {
        NhaCungCapController ctrlNCC = new NhaCungCapController();
        public frmTimPhieuNhap()
        {
            InitializeComponent();
        }

        private void frmTimPhieuNhap_Load(object sender, EventArgs e)
        {
            ctrlNCC.HienthiAutoComboBox(cmbNCC);

        }
    }
}