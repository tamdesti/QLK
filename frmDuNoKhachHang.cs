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
using QuanLyKho.Properties;

namespace QuanLyKho
{
    public partial class frmDuNoKhachHang : Form
    {
        DuNo type = DuNo.BanSi;
        String ID_KhachHang = string.Empty;
        String ID_PhieuBan = string.Empty;
        public frmDuNoKhachHang()
        {
            InitializeComponent();
        }
        public frmDuNoKhachHang(string IDKH, DuNo _type)
            :this()
        {
            ID_KhachHang = IDKH;
            type = _type;
            ReloadData();
            ReArrangeColumn();
        }
        PhieuBanController ctrl = new PhieuBanController();
        KhachHangController ctrlKH = new KhachHangController();
        private void ReArrangeColumn()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns["colKH"].DisplayIndex = 1;
            dataGridView1.Columns["colNgayBan"].DisplayIndex = 2;
            dataGridView1.Columns["colNoCu"].DisplayIndex = 3;
            dataGridView1.Columns["colThanhTien"].DisplayIndex = 4;
            dataGridView1.Columns["colTongTien"].DisplayIndex = 5;
            dataGridView1.Columns["colDaTra"].DisplayIndex = 6;
            dataGridView1.Columns["colConNo"].DisplayIndex = 7;
            dataGridView1.Columns["colID"].Visible = false;
        }
        private void ReloadData()
        {
            PhieuBanController PBCtrl = new PhieuBanController();
            if (type == DuNo.BanSi)
            {
                //ctrlKH.HienthiDaiLyDataGridviewComboBox(colKH);
                ctrl.HienthiPhieuBanSiConNo(bn, dataGridView1, ID_KhachHang);
            }
            else
            {
                ctrlKH.HienthiKhachHangDataGridviewComboBox(colKH);
                ctrl.HienthiPhieuBanLeConNo(bn, dataGridView1, ID_KhachHang);
            }
            QuanLyKho.BusinessObject.PhieuBan PB = PBCtrl.PhieuBanMoiNhatTuKhachHang(ID_KhachHang);
            if (PB != null)
            {
                numConNo.Value = (decimal)PB.ConNo;
                ID_PhieuBan = PB.Id;
            }
            else
            {
                numConNo.Value = 0;
            }
            numThanhToan.Value = 0;
            btnThanhToan.Enabled = false;
            GhiChu.Text = "";
        }
        private void numThanhToan_ValueChanged(object sender, EventArgs e)
        {
            //if (numThanhToan.Value > numConNo.Value) numThanhToan.Value = numConNo.Value;
            if (numThanhToan.Value > 0) btnThanhToan.Enabled = true;
            else btnThanhToan.Enabled = false;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            PhieuThanhToanController PhieuThanhToan = new PhieuThanhToanController();
            KhachHangController KH = new KhachHangController();
            PhieuBanController PB = new PhieuBanController();
            BusinessObject.PhieuThanhToan PTT = new BusinessObject.PhieuThanhToan();
            long maso = ThamSo.LayMaPhieuThanhToan();
            PTT.Id = maso.ToString();
            PTT.NgayThanhToan = dtNgayTra.Value.Date;
            PTT.TongTien = (long)numThanhToan.Value;
            PTT.KhachHang = ID_KhachHang;
            PTT.GhiChu = GhiChu.Text.Replace("\n", " ");
            PTT.PhieuBan = ID_PhieuBan;
            PhieuThanhToan.ThemPhieuThanhToan(PTT);
            ThamSo.GanMaPhieuThanhToan(maso + 1);
            BusinessObject.PhieuBan pb = PB.LayPhieuBan(ID_PhieuBan);
            pb.DaTra = pb.DaTra + (long)numThanhToan.Value;
            pb.ConNo = pb.ConNo - (long)numThanhToan.Value;
            PB.ThanhToanPhieuBan(pb);
            ReloadData();
        }
        private void NumEnter(object sender, EventArgs e)
        {
            NumericUpDown currentNum = (NumericUpDown)sender;
            currentNum.Select(0, currentNum.Text.Length);
        }
    }
}
