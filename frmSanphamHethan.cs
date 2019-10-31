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
    public partial class frmSanphamHethan : Form
    {
        SanPhamController ctrlSP = new SanPhamController();
        DonViTinhController ctrlDVT = new DonViTinhController();
        NhaCungCapController ctrlNCC = new NhaCungCapController();
        public frmSanphamHethan()
        {            
            InitializeComponent();            
            ctrlNCC.HienthiAutoComboBox(CbNCC);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            //ctrlSP.HangHetHanByNCC(dataGridView, CbNCC.SelectedValue.ToString());
            ctrlSP.ExpiredProductListByDateAndCompanyID(dataGridView, dt.Value, CbNCC.SelectedValue.ToString()); 
        }

        private void frmSanphamHethan_Load(object sender, EventArgs e)
        {

        }

        private void CbNCC_SelectedValueChanged(object sender, EventArgs e)
        {
            //ctrlSP.ExpiredProductListByDateAndCompanyID(dataGridView, bindingNavigator, dt.Value, CbNCC.SelectedValue.ToString());
        }

        private void dt_ValueChanged(object sender, EventArgs e)
        {
            //ctrlSP.ExpiredProductListByDateAndCompanyID(dataGridView, bindingNavigator, dt.Value, CbNCC.SelectedValue.ToString());
        }
    }
}