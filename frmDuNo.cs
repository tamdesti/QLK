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
    public partial class frmDuNo : Form
    {
        String ID_PhieuNhap = string.Empty;
        String IDNCC = string.Empty;
        public frmDuNo()
        {
            InitializeComponent();
        }
        public frmDuNo(String ID_NCC)
            :this()
        {
            IDNCC = ID_NCC;
            ReloadData();
            AdjustColumnOrder();
        }
        NhaCungCapController NCCCtrl = new NhaCungCapController();
        private void AdjustColumnOrder()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns["colNCC"].DisplayIndex = 1;
            dataGridView1.Columns["colNoCu"].DisplayIndex = 2;
            dataGridView1.Columns["colThanhTien"].DisplayIndex = 3;
            dataGridView1.Columns["colVAT"].DisplayIndex = 4;
            dataGridView1.Columns["colTongTien"].DisplayIndex = 5;
            dataGridView1.Columns["colDaTra"].DisplayIndex = 6;
            dataGridView1.Columns["colConNo"].DisplayIndex = 7;
            dataGridView1.Columns["colNgayNhap"].DisplayIndex = 8;
            dataGridView1.Columns["colID"].Visible = false;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Hạn cuối trả"].DefaultCellStyle = colNgayNhap.DefaultCellStyle;
            dataGridView1.Columns["Còn lại (ngày)"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Còn lại (ngày)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void numThanhToan_ValueChanged(object sender, EventArgs e)
        {
            if (numThanhToan.Value > numConNo.Value) numThanhToan.Value = numConNo.Value;
            btnThanhToan.Enabled = (numThanhToan.Value > 0);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            PhieuChiController PhieuChi = new PhieuChiController();
            BusinessObject.PhieuChi PC = new BusinessObject.PhieuChi();
            long maso = ThamSo.PhieuChi;
            PC.Id = maso.ToString();
            PC.NgayChi = dtNgayTra.Value.Date;
            PC.TongTien = (double)numThanhToan.Value;
            PC.PhieuNhap = ID_PhieuNhap;
            PC.GhiChu = GhiChu.Text.Replace("\n", " ");
            PhieuChi.ThemPhieuChi(PC);
            ThamSo.PhieuChi = maso + 1;
            PhieuNhapController PN = new PhieuNhapController();
            BusinessObject.PhieuNhap pn = PN.LayPhieuNhap(ID_PhieuNhap);
            pn.DaTra = pn.DaTra + (double)numThanhToan.Value;
            pn.ConNo = pn.ConNo - (double)numThanhToan.Value;
            PN.ThanhToanPhieuNhap(pn);
            ReloadData();
        }
        private void ReloadData()
        {
            PhieuNhapController PNCtrl = new PhieuNhapController();
            NCCCtrl.HienthiDataGridviewComboBox(colNCC);
            PNCtrl.HienthiPhieuNhapConNo(bindingNavigator1, dataGridView1, IDNCC);
            QuanLyKho.BusinessObject.PhieuNhap PN = PNCtrl.PhieuNhapMoiNhatTuNhaCungCap(IDNCC);
            if (PN != null)
            {
                numConNo.Value = (decimal)PN.ConNo;
                ID_PhieuNhap = PN.Id;
            }
            else
            {
                numConNo.Value = 0;
            }
            numThanhToan.Value = 0;
            btnThanhToan.Enabled = false;
            GhiChu.Text = "";
        }
        private void NumEnter(object sender, EventArgs e)
        {
            NumericUpDown currentNum = (NumericUpDown)sender;
            currentNum.Select(0, currentNum.Text.Length);
        }
    }
}
