using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuanLyKho.Controller;
using QuanLyKho.BusinessObject;
using QuanLyKho.DataLayer;

namespace QuanLyKho
{
    public partial class frmNhapHang : Form
    {
        SanPhamController ctrlSanPham = new SanPhamController();
        PhieuNhapController ctrl = new PhieuNhapController();
        ChiTietPhieuNhapController ctrlChiTietPhieuNhap = new ChiTietPhieuNhapController();
        NhaCungCapController ctrlNCC = new NhaCungCapController();
        KhoHangController ctrlKho = new KhoHangController();
        decimal soluongbandau = 0;
        DataRowView PhieuNhapRow = null;

        Controll status = Controll.Normal;
        int vitriPN = -1;
        decimal Datra_Cu = 0; 

        public frmNhapHang()
        {
            InitializeComponent();
            status = Controll.AddNew;
        }
        public frmNhapHang(PhieuNhapController ctrlPN, DataRowView PNRow)
            :this()
        {
            this.ctrl = ctrlPN;
            status = Controll.Normal;
            PhieuNhapRow = PNRow;
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {            
            ctrlNCC.HienthiAutoComboBox(cmbNhaCungCap);
            ctrlKho.HienthiAutoComboBox(cbKhohang);
            if (cmbNhaCungCap.Items.Count == 0) return;
            if (status == Controll.AddNew)
            {
                txtMaPhieuNhap.Text = "";
                vitriPN = ctrl.VitriPhieuNhapMoiNhatTuNhaCungCap(cmbNhaCungCap.SelectedValue.ToString());
                if (vitriPN > -1)
                {
                    numNoCu.Value = (decimal)ctrl.LayNoCuNhaCungCap(cmbNhaCungCap.SelectedValue.ToString(), vitriPN);
                    if (vitriPN > 0)
                        numNoCu.Enabled = false;
                    else
                        numNoCu.Enabled = true;
                }
                else
                {
                    numNoCu.Value = 0;
                    numNoCu.Enabled = true;
                }
                Allow(true);
                numDaTra.Enabled = true;
            }
            else
            {
                txtMaPhieuNhap.Text = PhieuNhapRow["ID"].ToString();
                cmbNhaCungCap.SelectedValue = PhieuNhapRow["ID_NHA_CUNG_CAP"];
                vitriPN = ctrl.VitriPhieuNhapTuNhaCungCap(cmbNhaCungCap.SelectedValue.ToString(), txtMaPhieuNhap.Text);
                if (vitriPN > -1)
                {
                    if (vitriPN > 0)
                    {
                        numNoCu.Value = (decimal)ctrl.LayNoCuNhaCungCap(cmbNhaCungCap.SelectedValue.ToString(), vitriPN - 1);
                        numNoCu.Enabled = false;
                    }
                    else
                    {
                        numNoCu.Value = Convert.ToDecimal(PhieuNhapRow["NO_CU"]);
                        numNoCu.Enabled = true;
                    }
                    int vitricuoi = ctrl.VitriPhieuNhapMoiNhatTuNhaCungCap(cmbNhaCungCap.SelectedValue.ToString());
                    numDaTra.Enabled = (vitricuoi == vitriPN);
                }
                else
                {
                    numNoCu.Value = 0;
                    numNoCu.Enabled = true;
                    numDaTra.Enabled = true;
                }
                numThanhTongTien.Value = Convert.ToDecimal(PhieuNhapRow["TONG_TIEN"]);
                numDaTra.Value = Convert.ToDecimal(PhieuNhapRow["DA_TRA"]);
                Datra_Cu = numDaTra.Value;
                numConNo.Value = Convert.ToDecimal(PhieuNhapRow["CON_NO"]);
                dtNgayNhap.Value = Convert.ToDateTime(PhieuNhapRow["NGAY_NHAP"]);
                Allow(false);
            }
            try
            {
                ctrlSanPham.HienthiAutoComboBox(cmbSanPham, cmbNhaCungCap.SelectedValue.ToString());
            }
            catch
            {

            }
            ReloadForm();
            dataGridView.Columns["colNgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
            Util.AdjustColumnOrder(ref dataGridView);
        }
        private void ReloadForm()
        {
            SanPhamController SPCtrl = new SanPhamController();
            SPCtrl.HienthiDataGridViewComboBoxColumn(colSanPham);
            DonViTinhController DVTCtrl = new DonViTinhController();
            DVTCtrl.HienthiDataGridViewComboBoxColumn(colDVT);
            KhoHangController KhoCtrl = new KhoHangController();
            KhoCtrl.HienthiDataGridViewComboBoxColumn(colKho);
            ctrlChiTietPhieuNhap.HienthiPhieuNhap(dataGridView, bindingNavigator, txtMaPhieuNhap.Text);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ChiTietPhieuNhapController CTPNCtrl = new ChiTietPhieuNhapController();
            TonKhoController TKCtrl = new TonKhoController();
            if (cmbNhaCungCap.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Phiếu Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmbSanPham.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Phiếu Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numGiaNhap.Value < 0)
            {
                MessageBox.Show("Vui lòng nhập Đơn giá !", "Phiếu Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numSoLuong.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập Số lượng !", "Phiếu Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Thêm dòng cho đơn có sẵn
                if (!txtMaPhieuNhap.Enabled)
                {
                    long maso = ThamSo.MaPhieuNhap;
                    DataRow row = ctrlChiTietPhieuNhap.NewRow();
                    row["ID"] = DateTime.Now.ToString("yyyyMMdd") + maso.ToString();
                    row["ID_SAN_PHAM"] = cmbSanPham.SelectedValue;
                    row["ID_PHIEU_NHAP"] = txtMaPhieuNhap.Text;
                    row["DON_GIA_NHAP"] = (double)numGiaNhap.Value;
                    row["SO_LUONG"] = numSoLuong.Value;
                    row["NGAY_NHAP"] = dtNgayNhap.Value.Date;
                    row["ID_KHO"] = cbKhohang.SelectedValue;
                    row["THANH_TIEN"] = numThanhTien.Value;
                    if (ctrlChiTietPhieuNhap.ThemChiTietPhieuNhap(row) > 0)
                    {
                        if (TKCtrl.TonKhoDaTonTai(cmbSanPham.SelectedValue.ToString(), cbKhohang.SelectedValue.ToString()))
                            TKCtrl.CapNhatSoLuongTon_Them(cmbSanPham.SelectedValue.ToString(), cbKhohang.SelectedValue.ToString(), numSoLuong.Value);
                        else
                        {
                            TonKho tk = new TonKho();
                            tk.SanPham = ctrlSanPham.LaySanPham(cmbSanPham.SelectedValue.ToString());
                            tk.KhoHang = cbKhohang.SelectedValue.ToString();
                            tk.SoLuongTon = Convert.ToInt64(numSoLuong.Value);
                            TKCtrl.ThemTonKho(tk);
                        }
                        cmbNhaCungCap.Enabled = false;
                        ReloadForm();
                        numThanhTongTien.Value = ctrl.LayTongTien(txtMaPhieuNhap.Text);
                        CapNhatPhieuNhap();
                        ThamSo.MaPhieuNhap = maso + 1;
                    }
                }
                //Thêm mới hoàn toàn
                else
                {
                    DataRow SP_row = ctrl.NewRow();
                    long maso = ThamSo.PhieuNhapTrongNgay;
                    SP_row["ID"] = DateTime.Now.ToString("yyyyMMdd") + maso.ToString();
                    SP_row["NGAY_NHAP"] = dtNgayNhap.Value.Date;
                    SP_row["NO_CU"] = numNoCu.Value;
                    SP_row["TONG_TIEN"] = numThanhTongTien.Value;
                    SP_row["DA_TRA"] = numDaTra.Value;
                    SP_row["CON_NO"] = numConNo.Value;
                    SP_row["ID_NHA_CUNG_CAP"] = cmbNhaCungCap.SelectedValue;
                    if (ctrl.ThemPhieuNhap(SP_row) < 1) return;

                    txtMaPhieuNhap.Text = SP_row["ID"].ToString();
                    ThamSo.PhieuNhapTrongNgay = maso + 1;
                    txtMaPhieuNhap.Enabled = false;


                    maso = ThamSo.MaPhieuNhap;
                    DataRow row = ctrlChiTietPhieuNhap.NewRow();
                    row["ID"] = DateTime.Now.ToString("yyyyMMdd") + maso.ToString();
                    row["ID_SAN_PHAM"] = cmbSanPham.SelectedValue;
                    row["ID_PHIEU_NHAP"] = txtMaPhieuNhap.Text;
                    row["DON_GIA_NHAP"] = numGiaNhap.Value;
                    row["SO_LUONG"] = numSoLuong.Value;
                    row["NGAY_NHAP"] = dtNgayNhap.Value.Date;
                    row["ID_KHO"] = cbKhohang.SelectedValue;
                    row["THANH_TIEN"] = numThanhTien.Value;
                    if (ctrlChiTietPhieuNhap.ThemChiTietPhieuNhap(row) > 0)
                    {
                        if (TKCtrl.TonKhoDaTonTai(cmbSanPham.SelectedValue.ToString(), cbKhohang.SelectedValue.ToString()))
                            TKCtrl.CapNhatSoLuongTon_Them(cmbSanPham.SelectedValue.ToString(), cbKhohang.SelectedValue.ToString(), numSoLuong.Value);
                        else
                        {
                            TonKho tk = new TonKho();
                            tk.SanPham = ctrlSanPham.LaySanPham(cmbSanPham.SelectedValue.ToString());
                            tk.KhoHang = cbKhohang.SelectedValue.ToString();
                            tk.SoLuongTon = Convert.ToInt64(numSoLuong.Value);
                            TKCtrl.ThemTonKho(tk);
                        }
                        cmbNhaCungCap.Enabled = false;
                        ReloadForm();
                        numThanhTongTien.Value = ctrl.LayTongTien(txtMaPhieuNhap.Text);
                        CapNhatPhieuNhap();
                        ThamSo.MaPhieuNhap = maso + 1;
                    }
                }
                toolLuu.Enabled = false;
                ClearForm();
            }
        }

        private void toolXoa_Click(object sender, EventArgs e)
        {
            if (bindingNavigator.BindingSource.Count == 0) return;
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            TonKhoController TK = new TonKhoController();
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Chi tiết phiếu nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SanPham sp = new SanPham();
                sp = ctrlSanPham.LaySanPham(row["ID_SAN_PHAM"].ToString());
                if (sp != null)
                    ctrlSanPham.CapNhatSoLuongSanPham(sp.Id, sp.SoLuong - (Convert.ToDecimal(row["SO_LUONG"].ToString())));
                TonKho tk = TK.LayTonKho(cmbSanPham.SelectedValue.ToString(), cbKhohang.SelectedValue.ToString());
                TK.CapNhatSoLuongTon(tk.SanPham.Id, tk.KhoHang, tk.SoLuongTon - (Convert.ToDecimal(row["SO_LUONG"].ToString())));
                ctrlChiTietPhieuNhap.XoaChiTietPhieuNhap(row["ID"].ToString());
                bindingNavigator.BindingSource.RemoveCurrent();
                numThanhTongTien.Value = ctrl.LayTongTien(txtMaPhieuNhap.Text);
                CapNhatPhieuNhap();
                ClearForm();
            }
        }

        private void toolLuu_Click(object sender, EventArgs e)
        {
            TonKhoController TK = new TonKhoController();
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            ChiTietPhieuNhapController CTPNCtrl = new ChiTietPhieuNhapController();
            row["ID_SAN_PHAM"] = cmbSanPham.SelectedValue;
            row["SO_LUONG"] = numSoLuong.Value;
            row["DON_GIA_NHAP"] = numGiaNhap.Value;
            row["NGAY_NHAP"] = dtNgayNhap.Value.Date;
            row["THANH_TIEN"] = numThanhTien.Value;
            CTPNCtrl.CapNhatChiTietPhieuNhap(row, row["ID"].ToString());
            TonKho tk = TK.LayTonKho(cmbSanPham.SelectedValue.ToString(), cbKhohang.SelectedValue.ToString());
            TK.CapNhatSoLuongTon(tk.SanPham.Id, tk.KhoHang, tk.SoLuongTon - (soluongbandau - numSoLuong.Value));
            dataGridView.Refresh();
            numThanhTongTien.Value = ctrl.LayTongTien(txtMaPhieuNhap.Text);
            CapNhatPhieuNhap();
        }

        
        private void toolThoat_Click(object sender, EventArgs e)
        {
            frmDanhsachPhieuNhap frmPhieuNhap = new frmDanhsachPhieuNhap();
            frmPhieuNhap.WindowState = FormWindowState.Maximized;
            frmPhieuNhap.MdiParent = this.MdiParent;
            foreach (var f in this.MdiParent.MdiChildren)
            {
                if (f != frmPhieuNhap)
                    f.Close();
            }
            frmPhieuNhap.Show();
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        void Allow(bool val)
        {
            txtMaPhieuNhap.Enabled = val;
            cmbNhaCungCap.Enabled = val;
            dtNgayNhap.Enabled = val;
        }        
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            numGiaNhap.Value = Convert.ToDecimal(row["DON_GIA_NHAP"]);
            numSoLuong.Value = Convert.ToDecimal(row["SO_LUONG"]);
            dtNgayNhap.Value = Convert.ToDateTime(row["NGAY_NHAP"]);
            cmbSanPham.SelectedValue = row["ID_SAN_PHAM"];
            cmbSanPham.Enabled = false;
            btnClear.Enabled = true;
            toolLuu.Enabled = true;
            cbKhohang.SelectedValue = row["ID_KHO"];
            soluongbandau = numSoLuong.Value;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void ClearForm()
        {
            numGiaNhap.Value = 0;
            numSoLuong.Value = 0;
            numThanhTien.Value = 0;
            toolLuu.Enabled = false;
            cmbSanPham.Enabled = true;
        }
        
        private void CapNhatPhieuNhap()
        {
            DataRow SP_row = ctrl.NewRow();
            SP_row["ID"] = txtMaPhieuNhap.Text;
            SP_row["NO_CU"] = numNoCu.Value;
            SP_row["TONG_TIEN"] = numThanhTongTien.Value;
            SP_row["DA_TRA"] = numDaTra.Value;
            SP_row["CON_NO"] = numConNo.Value;
            ctrl.CapNhatPhieuNhap(SP_row);
            toolLuu.Enabled = false;
        }
        private void CapNhatChuoiNoCu()
        {
            PhieuNhap PN = ctrl.LayPhieuNhap(txtMaPhieuNhap.Text);
            ctrl.CapNhatChuoiNoCu(PN);
        }
        private void cmbNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            NhaCungCapController NCC = new NhaCungCapController();
            dtHanNo.Value = dtNgayNhap.Value.AddDays(NCC.LayThoiHanNoTuNCC(cmbNhaCungCap.SelectedValue.ToString()));
            cmbSanPham.Text = "";
            ctrlSanPham.HienthiAutoComboBox(cmbSanPham, cmbNhaCungCap.SelectedValue.ToString());
            vitriPN = ctrl.VitriPhieuNhapMoiNhatTuNhaCungCap(cmbNhaCungCap.SelectedValue.ToString());
            if (vitriPN > -1)
            {
                numNoCu.Value = (decimal)ctrl.LayNoCuNhaCungCap(cmbNhaCungCap.SelectedValue.ToString(), vitriPN);
                if (vitriPN > 0)
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

        private void cmbNhaCungCap_Leave(object sender, EventArgs e)
        {
            if (cmbNhaCungCap.Items.Count == 0) return;
            NhaCungCapController NCC = new NhaCungCapController();
            if (!NCC.NhaCungCapTonTai(cmbNhaCungCap.Text)) cmbNhaCungCap.SelectedIndex = 0;
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
        private void numGiaNhap_ValueChanged(object sender, EventArgs e)
        {
            SanPhamController sp = new SanPhamController();
            SanPham sanpham = sp.LaySanPham(cmbSanPham.SelectedValue.ToString());
            if (sanpham.Loai == "Khác")
                numThanhTien.Value = numGiaNhap.Value * numSoLuong.Value;
            else if (sanpham.Loai == "Kính")
                numThanhTien.Value = sanpham.Dai * Convert.ToDecimal(0.001) * sanpham.Rong * Convert.ToDecimal(0.001) * numGiaNhap.Value * numSoLuong.Value;
            else if (sanpham.Loai == "Mài")
                numThanhTien.Value = numGiaNhap.Value * numSoLuong.Value;
            numThanhTien.Value = Math.Round(numThanhTien.Value / 1000, 0) * 1000;
        }

       
        private void numNoCu_ValueChanged(object sender, EventArgs e)
        {
            numTongTien.Value = numNoCu.Value + numThanhTongTien.Value;
        }
        private void numThanhTongTien_ValueChanged(object sender, EventArgs e)
        {
            numTongTien.Value = numThanhTongTien.Value + numNoCu.Value;
        }

        private void numTongTien_ValueChanged(object sender, EventArgs e)
        {
            if (numDaTra.Value > numTongTien.Value) numDaTra.Value = numTongTien.Value;
            numConNo.Value = numTongTien.Value - numDaTra.Value;
        }
        private void numDaTra_ValueChanged(object sender, EventArgs e)
        {
            if (numDaTra.Value > numTongTien.Value) numDaTra.Value = numTongTien.Value;
            numConNo.Value = numTongTien.Value - numDaTra.Value;
        }
        private void NumEnter(object sender, EventArgs e)
        {
            NumericUpDown currentNum = (NumericUpDown)sender;
            currentNum.Select(0, currentNum.Text.Length);
        }

        private void frmNhapHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!txtMaPhieuNhap.Enabled)
            {
                numThanhTongTien.Value = ctrl.LayTongTien(txtMaPhieuNhap.Text);
                CapNhatPhieuNhap();
                CapNhatChuoiNoCu();
                //foreach (DataGridViewRow row in dataGridView.Rows)
                //{
                //    string ID_SanPham = row.Cells["colSanPham"].Value.ToString();
                //    decimal soluong = ctrlSanPham.LaySoLuongSanPham(ID_SanPham);
                //    ctrlSanPham.CapNhatSoLuongSanPham(ID_SanPham, soluong);
                //}
                if (numDaTra.Value != Datra_Cu)
                {
                    PhieuChiController _PhieuChi = new PhieuChiController();
                    BusinessObject.PhieuChi PC = new BusinessObject.PhieuChi();
                    long maso = ThamSo.PhieuChi;
                    PC.Id = maso.ToString();
                    PC.NgayChi = DateTime.Now.Date;
                    PC.TongTien = (double)numDaTra.Value;
                    PC.PhieuNhap = txtMaPhieuNhap.Text;
                    PC.GhiChu = "Số tiền thanh toán trong lần đầu lập phiếu nhập";
                    _PhieuChi.ThemPhieuChi(PC);
                    ThamSo.PhieuChi = maso + 1;
                }
            }
        }
    }
}