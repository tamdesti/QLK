using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class frmThongtinCuahang : Form
    {
        public frmThongtinCuahang()
        {
            InitializeComponent();
        }

        private void frmThongtinCuahang_Load(object sender, EventArgs e)
        {
            QuanLyKho.BusinessObject.CuaHang ch = new BusinessObject.CuaHang();
            ch = ThamSo.LayCuaHang();
            if (ch.NgayBaoHetHan == -1) ckHethan.Checked = false;
            else
            {
                ckHethan.Checked = true;
                numSPHethan.Value = ch.NgayBaoHetHan;
            }
            if (ch.NgayTraNhaCungCap == -1) ckHetHanTra.Checked = false;
            else
            {
                ckHetHanTra.Checked = true;
                numHetHanTra.Value = ch.NgayTraNhaCungCap;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            long SPhethan = -1;
            long HethanTra = -1;
            if (ckHethan.Checked)
                SPhethan = (long)numSPHethan.Value;
            if (ckHetHanTra.Checked)
                HethanTra = (long)numHetHanTra.Value;
            ThamSo.GanCuaHang(SPhethan, HethanTra);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}