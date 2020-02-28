using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuanLyKho.Controller;
using QuanLyKho.BusinessObject;

namespace QuanLyKho
{
    public partial class frmQuanLy : Form
    {        
        SanPhamController ctrlSanPham = new SanPhamController();
        PhieuNhapController ctrl = new PhieuNhapController();
        KhoHangController ctrlKho = new KhoHangController();
        NhaCungCapController ctrlNCC = new NhaCungCapController();
        KhachHangController ctrlKH = new KhachHangController();
        TypeOfReport type = TypeOfReport.TonKho;

        public frmQuanLy(TypeOfReport reporttype)
        {
            InitializeComponent();
            type = reporttype;
        }

        private void frmSoLuongTon_Load(object sender, EventArgs e)
        {
            fromDate.Value = new DateTime(toDate.Value.Year, toDate.Value.Month, 1);
            ctrlKho.HienthiAllComboBox(cmbKho, false);
            ctrlSanPham.HienthiAutoComboBoxByKho(cmbSanPham, cmbKho.SelectedValue.ToString(), true);

            if (type == TypeOfReport.TonKho)
            {
                LoadHangTon();
                SetBackColor();
            }
            else if (type == TypeOfReport.DaBan)
                LoadDaBan();
            else if (type == TypeOfReport.DaNhap)
                LoadDaNhap();
            else if (type == TypeOfReport.HetHan)
                LoadHetHan();
            else if (type == TypeOfReport.TonKhoMoi)
                LoadHangTonMoi();
        }
        private void LoadHangTonMoi()
        {
            ctrlSanPham.NewAvaiableProductListByKho(dataGridView1, "0");
            this.Text = "QUẢN LÝ NHẬP - XUẤT";
            BusinessObject.Util.AdjustColumnOrder(ref dataGridView1);
            ReArrangeColumnHangTonMoi();
        }
        private void ReArrangeColumnHangTonMoi()
        {
            //ColID, colGhiChu, Kho hàng, Tồn cuối, Tồn đầu, Tên sản phẩm, Dài, Rộng, Nhập, Xuất, Đơn giá, Loại, Thành Tiền, STT
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns["colNCC"].Visible = false;
            dataGridView1.Columns["colKhachHang"].Visible = false;
            dataGridView1.Columns["Kho hàng"].Visible = false;
            dataGridView1.Columns["Tên sản phẩm"].DisplayIndex = 2;
            dataGridView1.Columns["Tên sản phẩm"].Width = 200;
            dataGridView1.Columns["Dài"].DisplayIndex = 3;
            dataGridView1.Columns["Dài"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Rộng"].DisplayIndex = 4;
            dataGridView1.Columns["Rộng"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Nhập"].DisplayIndex = 6;
            dataGridView1.Columns["Nhập"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Xuất"].DisplayIndex = 7;
            dataGridView1.Columns["Xuất"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Đơn giá"].DisplayIndex = 8;
            dataGridView1.Columns["Đơn giá"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Thành tiền"].DisplayIndex = 9;
            dataGridView1.Columns["Thành tiền"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["colGhiChu"].DisplayIndex = 10;
            dataGridView1.Columns["Loại"].Visible = false; 
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                decimal gia = Convert.ToDecimal(dataGridView1[10, i].Value);
                decimal soluong = Convert.ToDecimal(dataGridView1[3, i].Value);
                string loai = dataGridView1[11, i].Value.ToString(); ;
                decimal dai = Convert.ToDecimal(dataGridView1[8, i].Value);
                decimal rong = Convert.ToDecimal(dataGridView1[9, i].Value);
                if (loai == "Khác")
                    dataGridView1[12, i].Value = gia * soluong;
                else if (loai == "Kính")
                    dataGridView1[12, i].Value = dai * Convert.ToDecimal(0.001) * rong * Convert.ToDecimal(0.001) * gia * soluong;
                else if (loai == "Mài")
                    dataGridView1[12, i].Value = gia * soluong;
                dataGridView1[12, i].Value = Math.Round(Convert.ToDecimal(dataGridView1[12, i].Value) / 1000, 0) * 1000;
            }
        }
        private void LoadHangTon()
        {
            DateGroup.Visible = false;
            ctrlSanPham.AvaiableProductListByKho(dataGridView1, "0"); 
            this.Text = "SẢN PHẨM TỒN KHO";
            BusinessObject.Util.AdjustColumnOrder(ref dataGridView1);
            ReArrangeColumnHangTon();
        }
        private void ReArrangeColumnHangTon()
        {
            //ColID, colGhiChu, Kho hàng, Tồn cuối, Tồn đầu, Tên sản phẩm, Dài, Rộng, Nhập, Xuất, Đơn giá, Loại, Thành Tiền, STT
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns["colNCC"].Visible = false;
            dataGridView1.Columns["colKhachHang"].Visible = false;
            dataGridView1.Columns["Kho hàng"].Visible = false;
            dataGridView1.Columns["Tên sản phẩm"].DisplayIndex = 2;
            dataGridView1.Columns["Tên sản phẩm"].Width = 200;
            dataGridView1.Columns["Dài"].DisplayIndex = 3;
            dataGridView1.Columns["Dài"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Rộng"].DisplayIndex = 4;
            dataGridView1.Columns["Rộng"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Tồn đầu"].DisplayIndex = 5;
            dataGridView1.Columns["Tồn đầu"].Width = 120;
            dataGridView1.Columns["Tồn đầu"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Nhập"].DisplayIndex = 6;
            dataGridView1.Columns["Nhập"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Xuất"].DisplayIndex = 7;
            dataGridView1.Columns["Xuất"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Tồn cuối"].DisplayIndex = 8;
            dataGridView1.Columns["Tồn cuối"].Width = 120;
            dataGridView1.Columns["Tồn cuối"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Đơn giá"].DisplayIndex = 9;
            dataGridView1.Columns["Đơn giá"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Thành tiền"].DisplayIndex = 10;
            dataGridView1.Columns["Thành tiền"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["colGhiChu"].DisplayIndex = 11;
            dataGridView1.Columns["Loại"].Visible = false;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                decimal gia = Convert.ToDecimal(dataGridView1[12, i].Value);
                decimal soluong = Convert.ToDecimal(dataGridView1[5, i].Value);
                string loai = dataGridView1[13, i].Value.ToString(); ;
                decimal dai = Convert.ToDecimal(dataGridView1[8, i].Value);
                decimal rong = Convert.ToDecimal(dataGridView1[9, i].Value);
                if (loai == "Khác")
                    dataGridView1[14, i].Value = gia * soluong;
                else if (loai == "Kính")
                    dataGridView1[14, i].Value = dai * Convert.ToDecimal(0.001) * rong * Convert.ToDecimal(0.001) * gia * soluong;
                else if (loai == "Mài")
                    dataGridView1[14, i].Value = gia * soluong;
                dataGridView1[14, i].Value = Math.Round(Convert.ToDecimal(dataGridView1[14, i].Value) / 1000, 0) * 1000;
                long nhap = 0;
                long xuat = 0;
                Int64.TryParse(dataGridView1[10, i].Value.ToString(), out nhap);
                Int64.TryParse(dataGridView1[11, i].Value.ToString(), out xuat);
                dataGridView1[6, i].Value = Convert.ToInt64(dataGridView1[5, i].Value) - nhap + xuat;
            }
        }
        private void LoadDaNhap()
        {
            this.Text = "SẢN PHẨM ĐÃ NHẬP";
            BusinessObject.Util.AdjustColumnOrder(ref dataGridView1);
            ReArrangeColumnHangNhap();
        }
        private void ReArrangeColumnHangNhap()
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            dataGridView1.AutoGenerateColumns = false; 
            dataGridView1.Columns["colKhachHang"].Visible = false;
            dataGridView1.Columns["colGhiChu"].Visible = false;
            dataGridView1.Columns["Tên sản phẩm"].DisplayIndex = 2;
            dataGridView1.Columns["Tên sản phẩm"].Width = 200;
            dataGridView1.Columns["colNCC"].DisplayIndex = 3;
            dataGridView1.Columns["colNCC"].Width = 200;
            dataGridView1.Columns["Ngày nhập"].DisplayIndex = 4;
            dataGridView1.Columns["Số lượng"].DisplayIndex = 5;
            dataGridView1.Columns["Số lượng"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Đơn giá"].DisplayIndex = 6;
            dataGridView1.Columns["Đơn giá"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Thành tiền"].DisplayIndex = 7;
            dataGridView1.Columns["Thành tiền"].DefaultCellStyle.Format = "N0";
        }
        private void LoadDaBan()
        {
            this.Text = "SẢN PHẨM ĐÃ BÁN";
            BusinessObject.Util.AdjustColumnOrder(ref dataGridView1);
            ReArrangeColumnDaBan();
        }
        private void ReArrangeColumnDaBan()
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns["colNCC"].Visible = false;
            dataGridView1.Columns["colGhiChu"].Visible = false;
            dataGridView1.Columns["Tên sản phẩm"].DisplayIndex = 2;
            dataGridView1.Columns["Tên sản phẩm"].Width = 200;
            dataGridView1.Columns["colKhachHang"].DisplayIndex = 3;
            dataGridView1.Columns["colKhachHang"].Width = 200;
            dataGridView1.Columns["Ngày bán"].DisplayIndex = 4;
            dataGridView1.Columns["Số lượng"].DisplayIndex = 5;
            dataGridView1.Columns["Số lượng"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Đơn giá"].DisplayIndex = 6;
            dataGridView1.Columns["Đơn giá"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Thành tiền"].DisplayIndex = 7;
            dataGridView1.Columns["Thành tiền"].DefaultCellStyle.Format = "N0";
        }
        private void LoadHetHan()
        {
            DateGroup.Visible = false;
            dataGridView1.Columns["colNgaySanXuat"].Visible = false;
            dataGridView1.Columns["colNgayNhap"].Visible = false;
            dataGridView1.Columns["Số lượng nhập"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Số lượng nhập"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Số lượng tồn"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Số lượng tồn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.Text = "SẢN PHẨM HẾT HẠN";
            BusinessObject.Util.AdjustColumnOrder(ref dataGridView1);
        }
        
        private void cmbKho_Leave(object sender, EventArgs e)
        {
            KhoHangController KH = new KhoHangController();
            if (!KH.KhoTonTai(cmbKho.Text)) cmbKho.SelectedIndex = 0;
        }

        private void cmbSanPham_Leave(object sender, EventArgs e)
        {
            SanPhamController SP = new SanPhamController();
            if (!SP.SanPhamDaTonTai(cmbSanPham.Text))
            {
                if (cmbSanPham.Items.Count > 0)
                    cmbSanPham.SelectedIndex = 0;
                else
                    cmbSanPham.Text = "";
            }
        }
        public void SanPhamLoading()
        {
            
            switch (type)
            {
                case TypeOfReport.TonKho:
                    HangTon();
                    break;
                case TypeOfReport.DaNhap:
                    DaNhap();
                    break;
                case TypeOfReport.DaBan:
                    DaBan();
                    break;
                case TypeOfReport.HetHan:
                    HetHan();
                    break;
            }
        }
        public void HangTon()
        {
            if (cmbSanPham.Text == "")
            {
                if (cmbKho.SelectedValue != null)
                    ctrlSanPham.AvaiableProductListByKho(dataGridView1, cmbKho.SelectedValue.ToString());
            }
            else
            {
                if (cmbSanPham.SelectedValue.ToString() == "0")
                    ctrlSanPham.AvaiableProductListByKho(dataGridView1, cmbKho.SelectedValue.ToString());
                else
                    ctrlSanPham.AvaiableProductListBySP(dataGridView1, cmbSanPham.SelectedValue.ToString());
            }
            SetBackColor();
        }
       
        public void DaNhap()
        {
            ctrlNCC.HienthiDataGridviewComboBox(colNCC);
            if (cmbSanPham.Text == "")
            {
                if (cmbKho.SelectedValue != null)
                    ctrlSanPham.HangDaNhapByKho(dataGridView1, cmbKho.SelectedValue.ToString(), fromDate.Value, toDate.Value);
            }
            else
            {
                if (cmbSanPham.SelectedValue.ToString() == "0")
                    ctrlSanPham.HangDaNhapByKho(dataGridView1, cmbKho.SelectedValue.ToString(), fromDate.Value, toDate.Value);
                else
                    ctrlSanPham.HangDaNhapBySP(dataGridView1, cmbSanPham.SelectedValue.ToString(), fromDate.Value, toDate.Value);
            }
        }
        public void DaBan()
        {
            ctrlKH.HienthiKhachHangDataGridviewComboBox(colKhachHang);
            if (cmbSanPham.Text == "")
            {
                if (cmbKho.SelectedValue != null)
                    ctrlSanPham.HangDaBanByKho(dataGridView1, cmbKho.SelectedValue.ToString(), fromDate.Value, toDate.Value);
            }
            else
            {
                if (cmbSanPham.SelectedValue.ToString() == "0")
                    ctrlSanPham.HangDaBanByKho(dataGridView1, cmbKho.SelectedValue.ToString(), fromDate.Value, toDate.Value);
                else
                    ctrlSanPham.HangDaBanBySP(dataGridView1, cmbSanPham.SelectedValue.ToString(), fromDate.Value, toDate.Value);
            }
        }
        public void HetHan()
        {
            if (cmbSanPham.Text == "")
            {
                if (cmbKho.SelectedValue != null)
                    ctrlSanPham.HangHetHanByNCC(dataGridView1, cmbKho.SelectedValue.ToString());
            }
            else
            {
                if (cmbSanPham.SelectedValue.ToString() == "0")
                    ctrlSanPham.HangHetHanByNCC(dataGridView1, cmbKho.SelectedValue.ToString());
                else
                    ctrlSanPham.HangHetHanBySP(dataGridView1, cmbSanPham.SelectedValue.ToString());
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) { MessageBox.Show("Không có dữ liệu để in!"); return; }
            switch (type)
            {
                case TypeOfReport.TonKho:
                    frmInTonKho frm = new frmInTonKho(dataGridView1, cmbKho.Text);
                    frm.WindowState = FormWindowState.Maximized;
                    frm.ShowDialog();
                    break;
                case TypeOfReport.DaNhap:
                    frmInDaNhap frmNhap = new frmInDaNhap(dataGridView1, cmbKho.Text, cmbSanPham.Text, fromDate.Value, toDate.Value);
                    frmNhap.WindowState = FormWindowState.Maximized;
                    frmNhap.ShowDialog();
                    break;
                case TypeOfReport.DaBan:
                    frmInDaBan frm1 = new frmInDaBan(dataGridView1, cmbKho.Text, fromDate.Value, toDate.Value);
                    frm1.WindowState = FormWindowState.Maximized;
                    frm1.ShowDialog();
                    break;
                case TypeOfReport.HetHan:
                    frmInHetHan frmHetHan = new frmInHetHan(dataGridView1, cmbKho.Text);
                    frmHetHan.WindowState = FormWindowState.Maximized;
                    frmHetHan.ShowDialog();
                    break;
            }
            
        }

        private void toDate_ValueChanged(object sender, EventArgs e)
        {
            if (toDate.Value < fromDate.Value)
            {
                MessageBox.Show("Ngày cuối phải lớn hơn hoặc bằng ngày bắt đầu", "Lỗi ngày lọc");
                fromDate.Value = new DateTime(toDate.Value.Year, toDate.Value.Month, 1);
                return;
            }
            switch (type)
            {
                case TypeOfReport.DaNhap:
                    DaNhap();
                    break;
                case TypeOfReport.DaBan:
                    DaBan();
                    break;
            }
        }

        private void fromDate_ValueChanged(object sender, EventArgs e)
        {
            if (toDate.Value < fromDate.Value)
            {
                MessageBox.Show("Ngày cuối phải lớn hơn hoặc bằng ngày bắt đầu", "Lỗi ngày lọc");
                fromDate.Value = new DateTime(toDate.Value.Year, toDate.Value.Month, 1);
                return;
            }
            switch (type)
            {
                case TypeOfReport.DaNhap:
                    DaNhap();
                    break;
                case TypeOfReport.DaBan:
                    DaBan();
                    break;
            }
        }
        private void cmbKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            ctrlSanPham.HienthiAutoComboBoxByKho(cmbSanPham, cmbKho.SelectedValue.ToString(), true);
        }

        private void cmbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            SanPhamLoading();
        }
        private void cmbKho_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
        }

        private void cmbSanPham_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }
        private void SetBackColor()
        {
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    //if (Convert.ToDateTime(row.Cells["colNgayHetHan"].Value.ToString()) < DateTime.Now.Date)
            //    //    row.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
            //}
        }

        private void frmQuanLy_Activated(object sender, EventArgs e)
        {
            SetBackColor();
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            SetBackColor();
        }

        private void fromDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (toDate.Value < fromDate.Value)
                {
                    MessageBox.Show("Ngày cuối phải lớn hơn hoặc bằng ngày bắt đầu", "Lỗi ngày lọc");
                    fromDate.Value = new DateTime(toDate.Value.Year, toDate.Value.Month, 1);
                }
                switch (type)
                {
                    case TypeOfReport.DaNhap:
                        DaNhap();
                        break;
                    case TypeOfReport.DaBan:
                        DaBan();
                        break;
                }
            }
        }

        private void toDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (toDate.Value < fromDate.Value)
                {
                    MessageBox.Show("Ngày cuối phải lớn hơn hoặc bằng ngày bắt đầu", "Lỗi ngày lọc");
                    fromDate.Value = new DateTime(toDate.Value.Year, toDate.Value.Month, 1);
                }
                switch (type)
                {
                    case TypeOfReport.DaNhap:
                        DaNhap();
                        break;
                    case TypeOfReport.DaBan:
                        DaBan();
                        break;
                }
            }
        }
    }
}