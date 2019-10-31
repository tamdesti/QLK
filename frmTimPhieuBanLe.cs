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
    public partial class frmTimPhieuBanLe : Form
    {
        public frmTimPhieuBanLe()
        {
            InitializeComponent();
        }
        public frmTimPhieuBanLe(bool loai):this()
        {
            KhachHangController ctrlKH = new KhachHangController();
            if (loai)
                ctrlKH.HienthiDaiLyAutoComboBox(cmbNCC, loai);
            else
                ctrlKH.HienthiAutoComboBox(cmbNCC, loai);
        }

    }
}