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
    public partial class frmBanLe : Form
    {
        SanPhamController ctrlSanPham = new SanPhamController();
        KhachHangController ctrlKhachHang = new KhachHangController();
        ChiTietPhieuNhapController ctrlChiTietPhieuNhap = new ChiTietPhieuNhapController();
        PhieuBanController ctrlPhieuBan = new PhieuBanController();
        ChiTietPhieuBanController ctrlChiTietPhieuBan = new ChiTietPhieuBanController();
        NhaCungCapController ctrlNCC = new NhaCungCapController();
        KhoHangController ctrlKhoHang = new KhoHangController();
        TonKhoController ctrlTonKho = new TonKhoController();
        DataRowView PhieuBanRow = null;

        Controll status = Controll.Normal;
        Decimal SoLuongTon_Cu = 0;
        Decimal SoLuong_Cu = 0;
        Decimal KhuyenMai_Cu = 0;
        String MaPhieuBan = "";
        Decimal Datra_Cu = 0;
        int vitriPB = -1;

        public frmBanLe()
        {
            InitializeComponent();

            status = Controll.AddNew;
        }


        public frmBanLe(PhieuBanController ctrlPB, DataRowView PBRow)
            : this()
        {
            this.ctrlPhieuBan = ctrlPB;
            status = Controll.Normal;
            PhieuBanRow = PBRow;
        }

        private void frmBanLe_Load(object sender, EventArgs e)
        {
            ctrlKhoHang.HienthiAllComboBox(cmbKho);
            ctrlKhachHang.HienthiAutoComboBox(cmbKhachHang);
            if (cmbKho.Items.Count == 0) return;
            if (cmbKhachHang.Items.Count == 0) return;
            if (status == Controll.AddNew)
            {
                MaPhieuBan = "";
                vitriPB = ctrlPhieuBan.VitriPhieuBanMoiNhatTuKhachHang(cmbKhachHang.SelectedValue.ToString());
                if (vitriPB > -1)
                {
                    numNoCu.Value = ctrlPhieuBan.LayNoCuKhachHang(cmbKhachHang.SelectedValue.ToString(), vitriPB);
                    if (vitriPB > 0)
                        numNoCu.Enabled = false;
                    else
                        numNoCu.Enabled = true;
                }
                else
                {
                    numNoCu.Value = 0;
                    numNoCu.Enabled = true;
                }
                this.Allow(true);
                numDaTra.Enabled = true;
            }
            else
            {
                MaPhieuBan = PhieuBanRow["ID"].ToString();
                numTongTien.Value = Convert.ToDecimal(PhieuBanRow["TONG_TIEN"]);
                cmbKhachHang.SelectedValue = PhieuBanRow["ID_KHACH_HANG"];
                vitriPB = ctrlPhieuBan.VitriPhieuBanTuKhachHang(cmbKhachHang.SelectedValue.ToString(), MaPhieuBan);
                if (vitriPB > -1)
                {
                    if (vitriPB > 0)
                    {
                        numNoCu.Value = ctrlPhieuBan.LayNoCuKhachHang(cmbKhachHang.SelectedValue.ToString(), vitriPB -1);
                        numNoCu.Enabled = false;
                    }
                    else
                    {
                        numNoCu.Value = Convert.ToDecimal(PhieuBanRow["NO_CU"]);
                        numNoCu.Enabled = true;
                    }
                    int vitricuoi = ctrlPhieuBan.VitriPhieuBanMoiNhatTuKhachHang(cmbKhachHang.SelectedValue.ToString());
                    numDaTra.Enabled = (vitricuoi == vitriPB);
                }
                else
                {
                    numNoCu.Value = 0;
                    numNoCu.Enabled = true;
                    numDaTra.Enabled = true;
                }
                numDaTra.Value = Convert.ToDecimal(PhieuBanRow["DA_TRA"]);
                Datra_Cu = numDaTra.Value;
                numConNo.Value = Convert.ToDecimal(PhieuBanRow["CON_NO"]);
                dtNgayLapPhieu.Value = Convert.ToDateTime(PhieuBanRow["NGAY_BAN"]);
                dtNgayLapPhieu.Enabled = false;
                cmbKhachHang.Enabled = false;
                toolIn.Enabled = true;
            }
            ReloadForm();
            Util.AdjustColumnOrder(ref dgv);
            ReArrangeColumn();
        }
        private void ReArrangeColumn()
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns["colKho"].DisplayIndex = 1;
            dgv.Columns["colSanPham"].DisplayIndex = 2;
            dgv.Columns["colDVT"].DisplayIndex = 3;
            dgv.Columns["colDonGia"].DisplayIndex = 4;
            dgv.Columns["colSoLuong"].DisplayIndex = 5;
            dgv.Columns["colThanhTien"].DisplayIndex = 6;
        }
        private void ReloadForm()
        {
            SanPhamController SPCtrl = new SanPhamController();
            SPCtrl.HienthiDataGridViewComboBoxColumn(colSanPham);
            KhoHangController KhoCtrl = new KhoHangController();
            KhoCtrl.HienthiDataGridViewComboBoxColumn(colKho);
            DonViTinhController DVTCtrl = new DonViTinhController();
            DVTCtrl.HienthiDataGridViewComboBoxColumn(colDVT);
            ctrlChiTietPhieuBan.HienThiChiTiet(dgv, bindingNavigator, MaPhieuBan);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbKho.Text == "")
            {
                MessageBox.Show("Vui lòng chọn lô sản phẩm!", "Phiếu Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numSoLuong.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập Số lượng!", "Phiếu Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numSoLuong.Value > SoLuongTon_Cu)
            {
                MessageBox.Show("Số lượng vượt quá số lượng tồn kho!", "Phiếu Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numDonGia.Value < 0)
            {
                MessageBox.Show("Vui lòng nhập Đơn giá!", "Phiếu Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MaPhieuBan != "")
                {
                    DataRow row = ctrlChiTietPhieuBan.NewRow();
                    long maso = ThamSo.LayMaPhieuBan();
                    row["ID"] = maso;
                    row["ID_SAN_PHAM"] = cmbSanPham.SelectedValue;
                    row["ID_PHIEU_BAN"] = MaPhieuBan;
                    row["DON_GIA"] = numDonGia.Value;
                    row["SO_LUONG"] = numSoLuong.Value;
                    row["THANH_TIEN"] = numThanhTien.Value;
                    row["ID_KHO"] = cmbKho.SelectedValue;
                    if (ctrlChiTietPhieuBan.ThemChiTietPhieuBan(row) > 0)
                    {
                        ThamSo.GanMaPhieuBan(maso + 1);
                        ReloadForm();
                        decimal TongTien = 0;
                        foreach (DataGridViewRow _row in dgv.Rows)
                        {
                            TongTien += Convert.ToDecimal(_row.Cells["colThanhTien"].Value);
                        }
                        numTongTien.Value = TongTien;
                        numTongPhieuBan.Value = TongTien + numNoCu.Value;
                        CapNhatPhieuBan();
                        ctrlTonKho.CapNhatSoLuongTon(cmbSanPham.SelectedValue.ToString(), cmbKho.SelectedValue.ToString(), numSoLuongTon.Value);
                        ClearData();
                    }
                }
                else
                {
                    long PhieuBanTrongNgay = ThamSo.PhieuBanTrongNgay;
                    DataRow SP_row = ctrlPhieuBan.NewRow();
                    SP_row["ID"] = DateTime.Now.ToString("yyyyMMdd") + PhieuBanTrongNgay.ToString(); ;
                    SP_row["ID_KHACH_HANG"] = cmbKhachHang.SelectedValue;
                    SP_row["NO_CU"] = numNoCu.Value;
                    SP_row["TONG_TIEN"] = numTongTien.Value;
                    SP_row["DA_TRA"] = numDaTra.Value;
                    SP_row["CON_NO"] = numConNo.Value;
                    SP_row["NGAY_BAN"] = dtNgayLapPhieu.Value.Date;
                    if (ctrlPhieuBan.ThemPhieuBan(SP_row) < 1) return;
                    MaPhieuBan = SP_row["ID"].ToString();

                    ThamSo.PhieuBanTrongNgay = PhieuBanTrongNgay + 1;

                    DataRow row = ctrlChiTietPhieuBan.NewRow();
                    long masoPB = ThamSo.LayMaPhieuBan();
                    row["ID"] = masoPB;
                    row["ID_SAN_PHAM"] = cmbSanPham.SelectedValue;
                    row["ID_PHIEU_BAN"] = MaPhieuBan;
                    row["DON_GIA"] = numDonGia.Value;
                    row["SO_LUONG"] = numSoLuong.Value;
                    row["THANH_TIEN"] = numThanhTien.Value;
                    row["ID_KHO"] = cmbKho.SelectedValue;
                    if (ctrlChiTietPhieuBan.ThemChiTietPhieuBan(row) > 0)
                    {
                        ThamSo.GanMaPhieuBan(masoPB + 1);
                        ReloadForm();
                        decimal TongTien = 0;
                        foreach (DataGridViewRow _row in dgv.Rows)
                        {
                            TongTien += Convert.ToDecimal(_row.Cells["colThanhTien"].Value);
                        }
                        numTongTien.Value = TongTien;
                        numTongPhieuBan.Value = TongTien + numNoCu.Value;
                        CapNhatPhieuBan();
                        ctrlTonKho.CapNhatSoLuongTon(cmbSanPham.SelectedValue.ToString(), cmbKho.SelectedValue.ToString(), numSoLuongTon.Value);
                        ClearData();
                    }
                }
                toolLuu.Enabled = false;
                toolIn.Enabled = true;
            }

        }
        private void toolLuu_Click(object sender, EventArgs e)
        {
            if (cmbSanPham.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Phiếu Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmbKho.Text == "")
            {
                MessageBox.Show("Vui lòng chọn lô sản phẩm!", "Phiếu Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numSoLuong.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập Số lượng!", "Phiếu Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numDonGia.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập Đơn giá!", "Phiếu Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
                ChiTietPhieuBanController ChiTietPhieuBanCtrl = new ChiTietPhieuBanController();
                row["ID_PHIEU_BAN"] = MaPhieuBan;
                row["ID_SAN_PHAM"] = cmbSanPham.SelectedValue;
                row["SO_LUONG"] = numSoLuong.Value;
                row["DON_GIA"] = numDonGia.Value;
                row["THANH_TIEN"] = numThanhTien.Value;
                row["ID_KHO"] = cmbKho.SelectedValue;
                ChiTietPhieuBanCtrl.CapNhatChiTietPhieuBan(row);
                dgv.Refresh();
                decimal TongTien = 0;
                foreach (DataGridViewRow _row in dgv.Rows)
                {
                    TongTien += Convert.ToDecimal(_row.Cells["colThanhTien"].Value);
                }
                numTongTien.Value = TongTien;
                numTongPhieuBan.Value = TongTien + numNoCu.Value;
                CapNhatPhieuBan();
                if (numSoLuong.Value != SoLuong_Cu)
                    ctrlTonKho.CapNhatSoLuongTon(cmbSanPham.SelectedValue.ToString(), cmbKho.SelectedValue.ToString(), numSoLuongTon.Value);
                status = Controll.Normal;
            }

        }

        private void dgvDanhsachSP_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }


        void Allow(bool val)
        {
            cmbKho.Enabled = val;
            cmbSanPham.Enabled = val;
            cmbKho.Enabled = val;
        }

        private void toolThoat_Click(object sender, EventArgs e)
        {
            frmDanhsachPhieuBanLe frmPhieuBanLe = new frmDanhsachPhieuBanLe();
            frmPhieuBanLe.WindowState = FormWindowState.Maximized;
            frmPhieuBanLe.MdiParent = this.MdiParent;
            foreach (var f in this.MdiParent.MdiChildren)
            {
                if (f != frmPhieuBanLe)
                    f.Close();
            }
            frmPhieuBanLe.Show();
        }

        private void toolXoa_Click(object sender, EventArgs e)
        {
            if (bindingNavigator.BindingSource.Count == 0) return;
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
                numSoLuongTon.Value = SoLuongTon_Cu;
                ctrlChiTietPhieuBan.XoaChiTietPhieuBan(row["ID"].ToString());
                bindingNavigator.BindingSource.RemoveCurrent();
                decimal TongTien = 0;
                foreach (DataGridViewRow _row in dgv.Rows)
                {
                    TongTien += Convert.ToDecimal(_row.Cells["colThanhTien"].Value);
                }
                numTongTien.Value = TongTien;
                numTongPhieuBan.Value = TongTien + numNoCu.Value;
                CapNhatPhieuBan();
                try
                {
                    ctrlTonKho.CapNhatSoLuongTon(cmbSanPham.SelectedValue.ToString(), cmbKho.SelectedValue.ToString(), numSoLuongTon.Value);
                }
                catch { }
                SoLuong_Cu = 0;
                KhuyenMai_Cu = 0;
                toolLuu.Enabled = false;
                toolXoa.Enabled = false;
                ClearData();
            }
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            cmbKho.SelectedValue = row["ID_KHO"];
            if (cmbKho.Text != "") ctrlSanPham.HienthiAutoComboBoxByKho(cmbSanPham, cmbKho.SelectedValue.ToString());
            cmbSanPham.SelectedValue = row["ID_SAN_PHAM"];
            btnClear.Enabled = true;
            toolLuu.Enabled = true;
            toolXoa.Enabled = true;
            numDonGia.Value = Convert.ToDecimal(row["DON_GIA"]);
            SoLuong_Cu = Convert.ToDecimal(row["SO_LUONG"]);
            numSoLuong.Value = Convert.ToDecimal(row["SO_LUONG"]);
            if (cmbKho.Text != "")
            {
                long SoLuongTon = ctrlTonKho.LaySoLuongTon(cmbSanPham.SelectedValue.ToString(), cmbKho.SelectedValue.ToString());
                numSoLuongTon.Value = SoLuongTon;
            }
            SoLuongTon_Cu = numSoLuongTon.Value + numSoLuong.Value;
            Allow(false);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }
        private void ClearData()
        {
            numDonGia.Value = 0;
            SoLuong_Cu = 0;
            KhuyenMai_Cu = 0;
            SoLuongTon_Cu = 0;
            numSoLuongTon.Value = 0;
            numSoLuong.Value = 0;
            Allow(true);
        }
        private void CapNhatPhieuBan()
        {
            DataRow SP_row = ctrlPhieuBan.NewRow();
            SP_row["ID"] = MaPhieuBan;
            SP_row["NO_CU"] = numNoCu.Value;
            SP_row["TONG_TIEN"] = numTongTien.Value;
            SP_row["DA_TRA"] = numDaTra.Value;
            SP_row["CON_NO"] = numConNo.Value;
            ctrlPhieuBan.CapNhatPhieuBan(SP_row);
            toolLuu.Enabled = false;
        }
        private void CapNhatChuoiNoCu()
        {
            PhieuBan PB = ctrlPhieuBan.LayPhieuBan(MaPhieuBan);
            ctrlPhieuBan.CapNhatChuoiNoCu(PB);
        }
        private void numDonGia_ValueChanged(object sender, EventArgs e)
        {
            SanPhamController sp = new SanPhamController();
            SanPham sanpham = sp.LaySanPham(cmbSanPham.SelectedValue.ToString());
            if (sanpham.Loai == "Khác")
                numThanhTien.Value = numDonGia.Value * numSoLuong.Value;
            else if (sanpham.Loai == "Kính")
                numThanhTien.Value = sanpham.Dai * Convert.ToDecimal(0.001) * sanpham.Rong * Convert.ToDecimal(0.001) * numDonGia.Value * numSoLuong.Value;
            else if (sanpham.Loai == "Mài")
                numThanhTien.Value = numDonGia.Value * numSoLuong.Value;
            numThanhTien.Value = Math.Round(numThanhTien.Value / 1000, 0) * 1000;
        }

       
        private void cmbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiSoLuongTon();
        }
        public void SanPhamLoading()
        {
            if (cmbSanPham.Text == "")
            {
                numDonGia.Value = 0;
                ctrlSanPham.HienthiAutoComboBoxByKho(cmbSanPham, cmbKho.SelectedValue.ToString());
            }
            else
            {
                SanPhamController SPCtrl = new SanPhamController();
                SanPham sp = SPCtrl.LaySanPham(cmbSanPham.SelectedValue.ToString());
                numDonGia.Value = 0;
                ctrlSanPham.HienthiAutoComboBoxByKho(cmbSanPham, cmbKho.SelectedValue.ToString());
            }
            HienThiSoLuongTon();
        }
        public void HienThiSoLuongTon()
        {
            if (cmbSanPham.Text != "")
            {
                long SoLuongTon = ctrlTonKho.LaySoLuongTon(cmbSanPham.SelectedValue.ToString(), cmbKho.SelectedValue.ToString());
                numSoLuongTon.Value = SoLuongTon;
                SoLuongTon_Cu = SoLuongTon + numSoLuong.Value;
            }
            else
            {
                numSoLuongTon.Value = 0;
                SoLuongTon_Cu = 0;
            }
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

        private void toolIn_Click(object sender, EventArgs e)
        {
            CapNhatPhieuBan();
            String ma_phieu = MaPhieuBan;
            PhieuBanController ctrlPB = new PhieuBanController();
            QuanLyKho.BusinessObject.PhieuBan ph = ctrlPB.LayPhieuBan(ma_phieu);
            frmInChiTietPhieuBanLe InPhieuBan = new frmInChiTietPhieuBanLe(ph);
            InPhieuBan.Size = new Size(900, 550);
            InPhieuBan.ShowDialog();
        }
        private void numSoLuong_ValueChanged(object sender, EventArgs e)
        {
            if (SoLuongTon_Cu - numSoLuong.Value >= 0)
                numSoLuongTon.Value = SoLuongTon_Cu - numSoLuong.Value;
            else if (numSoLuong.Value != SoLuong_Cu)
            {
                numSoLuong.Value = SoLuongTon_Cu;
                numSoLuongTon.Value = 0;
            }
            SanPhamController sp = new SanPhamController();
            SanPham sanpham = sp.LaySanPham(cmbSanPham.SelectedValue.ToString());
            if (sanpham.Loai == "Khác")
                numThanhTien.Value = numDonGia.Value * numSoLuong.Value;
            else if (sanpham.Loai == "Kính")
                numThanhTien.Value = sanpham.Dai * Convert.ToDecimal(0.001) * sanpham.Rong * Convert.ToDecimal(0.001) * numDonGia.Value * numSoLuong.Value;
            else if (sanpham.Loai == "Mài")
                numThanhTien.Value = numDonGia.Value * numSoLuong.Value;
            numThanhTien.Value = Math.Round(numThanhTien.Value / 1000, 0) * 1000;
        }
        private void cmbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            vitriPB = ctrlPhieuBan.VitriPhieuBanMoiNhatTuKhachHang(cmbKhachHang.SelectedValue.ToString());
            if (vitriPB > -1)
            {
                numNoCu.Value = ctrlPhieuBan.LayNoCuKhachHang(cmbKhachHang.SelectedValue.ToString(), vitriPB);
                if (vitriPB > 0)
                    numNoCu.Enabled = false;
                else
                    numNoCu.Enabled = true;
            }
            else
            {
                numNoCu.Value = 0;
                numNoCu.Enabled = true;
            }
        }
        private void numNoCu_ValueChanged(object sender, EventArgs e)
        {
            numTongPhieuBan.Value = numNoCu.Value + numTongTien.Value;
        }
        private void numDaTra_ValueChanged(object sender, EventArgs e)
        {
            numConNo.Value = numTongPhieuBan.Value - numDaTra.Value;
        }
        private void numTongPhieuBan_ValueChanged(object sender, EventArgs e)
        {
            numConNo.Value = numTongPhieuBan.Value - numDaTra.Value;
        }

        private void numTongTien_ValueChanged(object sender, EventArgs e)
        {
            numTongPhieuBan.Value = numNoCu.Value + numTongTien.Value;
        }
        private void NumEnter(object sender, EventArgs e)
        {
            NumericUpDown currentNum = (NumericUpDown)sender;
            currentNum.Select(0, currentNum.Text.Length);
        }

        private void frmBanLe_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MaPhieuBan != "")
            {
                decimal TongTien = 0;
                foreach (DataGridViewRow _row in dgv.Rows)
                {
                    TongTien += Convert.ToDecimal(_row.Cells["colThanhTien"].Value);
                }
                numTongTien.Value = TongTien;
                CapNhatPhieuBan();
                CapNhatChuoiNoCu();
                if (numDaTra.Value != Datra_Cu)
                {
                    PhieuThanhToanController PhieuThanhToan = new PhieuThanhToanController();
                    PhieuThanhToan.XoaPhieuThanhToanTheoIDPhieuBan(MaPhieuBan);
                    BusinessObject.PhieuThanhToan PTT = new BusinessObject.PhieuThanhToan();
                    long maso = ThamSo.LayMaPhieuThu();
                    PTT.Id = maso.ToString();
                    PTT.NgayThanhToan = DateTime.Now.Date;
                    PTT.TongTien = (long)numDaTra.Value;
                    PTT.KhachHang = cmbKhachHang.SelectedValue.ToString();
                    PTT.GhiChu = "Thanh toán phiếu bán " + MaPhieuBan;
                    PTT.PhieuBan = MaPhieuBan;
                    PhieuThanhToan.ThemPhieuThanhToan(PTT);
                    ThamSo.GanMaPhieuThanhToan(maso + 1);
                }
            }
        }

        private void cmbKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSanPham.Text = "";
            if (cmbKho.SelectedValue.ToString() == "-1")
                cmbSanPham.DataSource = null;
            else
                ctrlSanPham.HienthiAutoComboBoxByKho(cmbSanPham, cmbKho.SelectedValue.ToString());
            SanPhamLoading();
        }

        private void cmbKho_Leave(object sender, EventArgs e)
        {
            if (cmbKho.Items.Count == 0) return;
            KhoHangController Kho = new KhoHangController();
            if (cmbKho.Text == "Tất cả" || cmbKho.Text == "--- Chọn nhà cung cấp ---") return;
            if (!Kho.KhoTonTai(cmbKho.Text)) cmbKho.SelectedIndex = 0;
        }
    }
}
