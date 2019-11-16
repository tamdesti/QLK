using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuanLyKho.BusinessObject;
using QuanLyKho.Controller;

namespace QuanLyKho
{
    public partial class frmDanhSachPhieuThu : Form
    {

        KhachHangController KHCtrl = new KhachHangController();
        public frmDanhSachPhieuThu()
        {
            InitializeComponent();
        }

        private void frmDanhSachPhieuThu_Load(object sender, EventArgs e)
        {
            fromDate.Value = DateTime.Now.AddMonths(-1);
            cbDanhsach.Items.Insert(0, "Đại lý");
            cbDanhsach.Items.Insert(1, "Khách hàng");
            cbDanhsach.SelectedIndex = 1;
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns["colId"].DisplayIndex = 1;
            dataGridView.Columns["colDaiLy"].DisplayIndex = 2;
            dataGridView.Columns["colKhachHang"].DisplayIndex = 3;
            dataGridView.Columns["colNoCu"].DisplayIndex = 4;
            dataGridView.Columns["colTongTien"].DisplayIndex = 5;
            dataGridView.Columns["colTotal"].DisplayIndex = 6;
            dataGridView.Columns["colDaTra"].DisplayIndex = 7;
            dataGridView.Columns["colConNo"].DisplayIndex = 8;
        }

        private void cbDanhsach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDanhsach.SelectedIndex == 0)
            {
                LoadBanSi();
            }
            else
            {
                LoadBanLe();
            }
            Util.AdjustColumnOrder(ref dataGridView);
        }
        private void LoadBanSi()
        {
            PhieuBanController PBCtrl = new PhieuBanController();
            KhachHangController KH = new KhachHangController();
            dataGridView.Columns["colDaiLy"].Visible = true;
            dataGridView.Columns["colKhachHang"].Visible = false;
            lbKhachHang.Text = "Đại lý:";
            KH.HienthiAllDaiLyAutoComboBox(cmbKhachHang);
            PBCtrl.HienthiPhieuBanSi_CoTenDaiLy(bindingNavigator1, dataGridView, cmbKhachHang.SelectedValue.ToString(), fromDate.Value, toDate.Value);
        }
        private void LoadBanLe()
        {
            PhieuBanController PBCtrl = new PhieuBanController();
            KhachHangController KH = new KhachHangController();
            dataGridView.Columns["colDaiLy"].Visible = false;
            dataGridView.Columns["colKhachHang"].Visible = true;
            lbKhachHang.Text = "Khách hàng:";
            KH.HienthiAllKhachHangAutoComboBox(cmbKhachHang);
            PBCtrl.HienthiPhieuBanLe_CoTenKhachHang(bindingNavigator1, dataGridView, cmbKhachHang.SelectedValue.ToString(), fromDate.Value, toDate.Value);
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        frmChiTietPhieuThu ChiTietPhieuThu = null;
        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (ChiTietPhieuThu == null || ChiTietPhieuThu.IsDisposed)
            {
                DataRowView row = (DataRowView)bindingNavigator1.BindingSource.Current;
                ChiTietPhieuThu = new frmChiTietPhieuThu(row["ID"].ToString());
                ChiTietPhieuThu.WindowState = FormWindowState.Maximized;
                ChiTietPhieuThu.MdiParent = this.MdiParent;
                foreach (var f in this.MdiParent.MdiChildren)
                {
                    if (f != ChiTietPhieuThu)
                        f.Close();
                }
                ChiTietPhieuThu.Show();
            }
            else
                ChiTietPhieuThu.Activate();
        }

        private void fromDate_CloseUp(object sender, EventArgs e)
        {
            if (fromDate.Value > toDate.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải lớn hơn ngày kết thúc", "Lỗi ngày nhập");
                fromDate.Value = toDate.Value;
            }
            if (cbDanhsach.SelectedIndex == 0)
            {
                LoadBanSi();
            }
            else
            {
                LoadBanLe();
            }
            Util.AdjustColumnOrder(ref dataGridView);
        }

        private void cmbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDanhsach.SelectedIndex == 0)
            {
                PhieuBanController PBCtrl = new PhieuBanController();
                PBCtrl.HienthiPhieuBanSi_CoTenDaiLy(bindingNavigator1, dataGridView, cmbKhachHang.SelectedValue.ToString(), fromDate.Value, toDate.Value);
            }
            else
            {
                PhieuBanController PBCtrl = new PhieuBanController();
                PBCtrl.HienthiPhieuBanLe_CoTenKhachHang(bindingNavigator1, dataGridView, cmbKhachHang.SelectedValue.ToString(), fromDate.Value, toDate.Value);
            }
        }

        private void toDate_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (fromDate.Value > toDate.Value)
                {
                    MessageBox.Show("Ngày bắt đầu phải lớn hơn ngày kết thúc", "Lỗi ngày nhập");
                    fromDate.Value = toDate.Value;
                }
                if (cbDanhsach.SelectedIndex == 0)
                {
                    LoadBanSi();
                }
                else
                {
                    LoadBanLe();
                }
                Util.AdjustColumnOrder(ref dataGridView);
            }
        }
    }
}
