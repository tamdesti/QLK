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
    public partial class frmBanSi: Form
    {
        SanPhamController ctrlSanPham = new SanPhamController();
        KhachHangController ctrlKhachHang = new KhachHangController();
        ChiTietPhieuNhapController ctrlChiTietPhieuNhap = new ChiTietPhieuNhapController();
        PhieuBanController ctrlPhieuBan = new PhieuBanController();
        ChiTietPhieuBanController ctrlChiTietPhieuBan = new ChiTietPhieuBanController();
        NhaCungCapController ctrlNCC = new NhaCungCapController();

        DataRowView PhieuBanRow = null;

        Controll status = Controll.Normal;
        Decimal SoLuongTon_Cu = 0;
        Decimal SoLuong_Cu = 0;
        Decimal KhuyenMai_Cu = 0;
        Decimal DaTra_Cu = 0;
        String MaPhieuBan = "";
        int vitriPB = -1;

        public frmBanSi()
        {
            InitializeComponent();
            
            status = Controll.AddNew;
        }


        public frmBanSi(PhieuBanController ctrlPB, DataRowView PBRow)
            : this()
        {
            this.ctrlPhieuBan = ctrlPB;
            status = Controll.Normal;
            PhieuBanRow = PBRow;
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            ctrlNCC.HienthiAllComboBox(cmbNhaCungCap);
            ctrlKhachHang.HienthiDaiLyAutoComboBox(cmbKhachHang);
            if (cmbNhaCungCap.Items.Count == 0) return;
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
                DaTra_Cu = numDaTra.Value;
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
            dgv.Columns["colChiTietPhieuNhap"].DisplayIndex = 1;
            dgv.Columns["colSanPham"].DisplayIndex = 2;
            dgv.Columns["colDVT"].DisplayIndex = 3;
            dgv.Columns["colDonGia"].DisplayIndex = 4;
            dgv.Columns["colSoLuong"].DisplayIndex = 5;
            dgv.Columns["colKhuyenMai"].DisplayIndex = 6;
            dgv.Columns["colChietKhau"].DisplayIndex = 7;
            dgv.Columns["colThanhTien"].DisplayIndex = 8;
        }
        private void ReloadForm()
        {
            SanPhamController SPCtrl = new SanPhamController();
            SPCtrl.HienthiDataGridViewComboBoxColumn(colSanPham);
            ChiTietPhieuNhapController MSPCtrl = new ChiTietPhieuNhapController();
            MSPCtrl.HienThiDataGridViewComboBox(colChiTietPhieuNhap);
            DonViTinhController DVTCtrl = new DonViTinhController();
            DVTCtrl.HienthiDataGridViewComboBoxColumn(colDVT);
            ctrlChiTietPhieuBan.HienThiChiTiet(dgv, bindingNavigator, MaPhieuBan);
        }
        private void ErrorMessage(string ErrorString)
        {
            MessageBox.Show(ErrorString, "Bán Sỉ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private int DataValidate(bool isAdd = true)
        {
            if (cmbKhachHang.Text == "")
            {
                ErrorMessage("Vui lòng chọn đại lý!");
                return 0;
            }
            if (cmbSanPham.Text == "")
            {
                ErrorMessage("Vui lòng chọn sản phẩm!");
                return 0;
            }
            if (cmbChiTietPhieuNhap.Text == "")
            {
                ErrorMessage("Vui lòng chọn lô sản phẩm!");
                return 0;
            }
            if (numSoLuong.Value <= 0)
            {
                ErrorMessage("Vui lòng nhập Số lượng!");
                return 0;
            }
            if (numDonGia.Value < 0)
            {
                ErrorMessage("Vui lòng nhập Đơn giá!");
                return 0;
            }
            return 1;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (DataValidate() == 0) return;
            status = Controll.Normal;
            if (MaPhieuBan != "")
            {
                DataRow row = ctrlChiTietPhieuBan.NewRow();
                long maso = ThamSo.LayMaPhieuBan();
                row["ID"] = maso;
                row["ID_SAN_PHAM"] = cmbSanPham.SelectedValue;
                row["ID_CHI_TIET_PHIEU_NHAP"] = cmbChiTietPhieuNhap.SelectedValue;
                row["ID_PHIEU_BAN"] = MaPhieuBan;
                row["DON_GIA"] = numDonGia.Value;
                row["SO_LUONG"] = numSoLuong.Value;
                row["THANH_TIEN"] = numThanhTien.Value;
                row["CHIET_KHAU"] = numChietKhau.Value;
                row["KHUYEN_MAI"] = numKhuyenMai.Value;
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
                    ctrlChiTietPhieuNhap.CapNhatSoLuongTon(cmbChiTietPhieuNhap.SelectedValue.ToString(), numSoLuongTon.Value);
                    ClearData();
                }
            }
            else
            {
                DataRow SP_row = ctrlPhieuBan.NewRow();
                long PhieuBanTrongNgay = ThamSo.PhieuBanTrongNgay;
                SP_row["ID"] = DateTime.Now.ToString("yyyyMMdd") + PhieuBanTrongNgay.ToString();
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
                long maso = ThamSo.LayMaPhieuBan();
                row["ID"] = maso;
                row["ID_SAN_PHAM"] = cmbSanPham.SelectedValue;
                row["ID_CHI_TIET_PHIEU_NHAP"] = cmbChiTietPhieuNhap.SelectedValue;
                row["ID_PHIEU_BAN"] = MaPhieuBan;
                row["DON_GIA"] = numDonGia.Value;
                row["SO_LUONG"] = numSoLuong.Value;
                row["THANH_TIEN"] = numThanhTien.Value;
                row["CHIET_KHAU"] = numChietKhau.Value;
                row["KHUYEN_MAI"] = numKhuyenMai.Value;
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
                    ctrlChiTietPhieuNhap.CapNhatSoLuongTon(cmbChiTietPhieuNhap.SelectedValue.ToString(), numSoLuongTon.Value);
                    ClearData();
                }
            }
            toolLuu.Enabled = false;
            toolIn.Enabled = true;
        }
       

        private void toolLuu_Click(object sender, EventArgs e)
        {
            if (DataValidate(false) == 0) return;
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            ChiTietPhieuBanController ChiTietPhieuBanCtrl = new ChiTietPhieuBanController();
            row["ID_PHIEU_BAN"] = MaPhieuBan;
            row["ID_CHI_TIET_PHIEU_NHAP"] = cmbChiTietPhieuNhap.SelectedValue;
            row["ID_SAN_PHAM"] = cmbSanPham.SelectedValue;
            row["SO_LUONG"] = numSoLuong.Value;
            row["DON_GIA"] = numDonGia.Value;
            row["THANH_TIEN"] = numThanhTien.Value;
            row["CHIET_KHAU"] = numChietKhau.Value;
            row["KHUYEN_MAI"] = numKhuyenMai.Value;
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
            if (numSoLuong.Value != SoLuong_Cu || numKhuyenMai.Value != KhuyenMai_Cu)
                ctrlChiTietPhieuNhap.CapNhatSoLuongTon(cmbChiTietPhieuNhap.SelectedValue.ToString(), numSoLuongTon.Value);
            status = Controll.Normal;
        }
        private void toolIn_Click(object sender, EventArgs e)
        {
            CapNhatPhieuBan();
            String ma_phieu = MaPhieuBan;
            PhieuBanController ctrlPB = new PhieuBanController();
            QuanLyKho.BusinessObject.PhieuBan ph = ctrlPB.LayPhieuBan(ma_phieu);
            frmInChiTietPhieuBan InPhieuBan = new frmInChiTietPhieuBan(ph);
            InPhieuBan.Size = new Size(900, 550);
            InPhieuBan.ShowDialog();
        }

        private void dgvDanhsachSP_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        
        void Allow(bool val)
        {
            cmbNhaCungCap.Enabled = val;            
            cmbSanPham.Enabled = val;
            cmbChiTietPhieuNhap.Enabled = val;
        }

        private void toolThoat_Click(object sender, EventArgs e)
        {
            frmDanhsachPhieuBanSi frmPhieuBanSi = new frmDanhsachPhieuBanSi();
            frmPhieuBanSi.WindowState = FormWindowState.Maximized;
            frmPhieuBanSi.MdiParent = this.MdiParent;
            foreach (var f in this.MdiParent.MdiChildren)
            {
                if (f != frmPhieuBanSi)
                    f.Close();
            }
            frmPhieuBanSi.Show();
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
                try {
                    ctrlChiTietPhieuNhap.CapNhatSoLuongTon(cmbChiTietPhieuNhap.SelectedValue.ToString(), numSoLuongTon.Value);
                }
                catch { }
                SoLuong_Cu = 0;
                KhuyenMai_Cu = 0;
                numChietKhau.Value = 0;
                toolLuu.Enabled = false;
                toolXoa.Enabled = false;
                ClearData();
            }
        }
       

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView row = (DataRowView)bindingNavigator.BindingSource.Current;
            cmbSanPham.SelectedValue = row["ID_SAN_PHAM"];
            BusinessObject.SanPham sp = ctrlSanPham.LaySanPham(row["ID_SAN_PHAM"].ToString());
            cmbNhaCungCap.SelectedValue = sp.NhaCungCap.Id;
            if (cmbNhaCungCap.Text != "") ctrlSanPham.HienthiAutoComboBox(cmbSanPham, cmbNhaCungCap.SelectedValue.ToString());
            cmbSanPham.SelectedValue = sp.Id;
            if (cmbSanPham.Text != "")
            {
                ctrlChiTietPhieuNhap.HienThiAutoComboBox(cmbSanPham.SelectedValue.ToString(), cmbChiTietPhieuNhap);
            }
            btnClear.Enabled = true;
            toolLuu.Enabled = true;
            toolXoa.Enabled = true;
            numDonGia.Value = Convert.ToDecimal(row["DON_GIA"]);
            SoLuong_Cu = Convert.ToDecimal(row["SO_LUONG"]);
            KhuyenMai_Cu = Convert.ToDecimal(row["KHUYEN_MAI"]);
            numSoLuong.Value = Convert.ToDecimal(row["SO_LUONG"]);
            numChietKhau.Value = Convert.ToDecimal(row["CHIET_KHAU"]);
            numKhuyenMai.Value = Convert.ToDecimal(row["KHUYEN_MAI"]);
            cmbChiTietPhieuNhap.SelectedValue = row["ID_CHI_TIET_PHIEU_NHAP"];
            if (cmbChiTietPhieuNhap.Text != "")
            {
                ChiTietPhieuNhapController MSPCtrl = new Controller.ChiTietPhieuNhapController();
                ChiTietPhieuNhap msp = MSPCtrl.LayChiTietPhieuNhap(cmbChiTietPhieuNhap.SelectedValue.ToString());
                //numSoLuongTon.Value = msp.SoLuongTon;
            }
            SoLuongTon_Cu = numSoLuongTon.Value + numSoLuong.Value + numKhuyenMai.Value;
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
            numChietKhau.Value = 0;
            numKhuyenMai.Value = 0;
            cmbNhaCungCap.SelectedIndex = 0;
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
            numThanhTien.Value = numDonGia.Value * numSoLuong.Value;
            numThanhTien.Value = numThanhTien.Value * (1 - (decimal)(numChietKhau.Value / 100));
        }

        

        private void numChietKhau_ValueChanged(object sender, EventArgs e)
        {
            numThanhTien.Value = numDonGia.Value * numSoLuong.Value;
            numThanhTien.Value = numThanhTien.Value * (1 - (decimal)(numChietKhau.Value / 100));
        }

        private void cmbNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSanPham.Text = "";
            if (cmbNhaCungCap.SelectedValue.ToString() == "-1")
                cmbSanPham.DataSource = null;
            else
                ctrlSanPham.HienthiAutoComboBox(cmbSanPham, cmbNhaCungCap.SelectedValue.ToString());
            SanPhamLoading();            
        }
        private void cmbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            SanPhamLoading();
        }
        private void cmbChiTietPhieuNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChiTietPhieuNhapLoading();
        }
        public void SanPhamLoading()
        {
            if (cmbSanPham.Text == "")
            {
                numDonGia.Value = 0;
                ctrlChiTietPhieuNhap.HienThiAutoComboBox("0", cmbChiTietPhieuNhap);
            }
            else
            {
                SanPhamController SPCtrl = new SanPhamController();
                SanPham sp = SPCtrl.LaySanPham(cmbSanPham.SelectedValue.ToString());
                numDonGia.Value = 0;
                ctrlChiTietPhieuNhap.HienThiAutoComboBox(cmbSanPham.SelectedValue.ToString(), cmbChiTietPhieuNhap);
            }
            ChiTietPhieuNhapLoading();
        }
        public void ChiTietPhieuNhapLoading()
        {
            if (cmbChiTietPhieuNhap.Text != "")
            {
                ChiTietPhieuNhapController MSPCtrl = new Controller.ChiTietPhieuNhapController();
                ChiTietPhieuNhap msp = MSPCtrl.LayChiTietPhieuNhap(cmbChiTietPhieuNhap.SelectedValue.ToString());
                if (msp != null)
                {
                    //numSoLuongTon.Value = msp.SoLuongTon;
                    //SoLuongTon_Cu = msp.SoLuongTon + numSoLuong.Value + numKhuyenMai.Value;
                    //if (msp.NgayHetHan > DateTime.Now) lbHethan.Visible = false;
                    //else lbHethan.Visible = true;
                }
                else
                {
                    numSoLuongTon.Value = 0;
                    SoLuongTon_Cu = 0;
                    lbHethan.Visible = false;
                }
            }
            else
            {
                numSoLuongTon.Value = 0;
                SoLuongTon_Cu = 0;
                lbHethan.Visible = false;
            }
        }

        private void cmbNhaCungCap_Leave(object sender, EventArgs e)
        {
            if (cmbNhaCungCap.Items.Count == 0) return;
            NhaCungCapController NCC = new NhaCungCapController();
            if (cmbNhaCungCap.Text == "Tất cả" || cmbNhaCungCap.Text == "--- Chọn nhà cung cấp ---") return;
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

        private void cmbChiTietPhieuNhap_Leave(object sender, EventArgs e)
        {
            ChiTietPhieuNhapController MSP = new ChiTietPhieuNhapController();
            if (!MSP.ChiTietPhieuNhapDaTonTai(cmbChiTietPhieuNhap.Text))
            {
                if (cmbChiTietPhieuNhap.Items.Count > 0)
                    cmbChiTietPhieuNhap.SelectedIndex = 0;
                else
                    cmbChiTietPhieuNhap.Text = "";
            }
        }
        private void numSoLuong_ValueChanged(object sender, EventArgs e)
        {
            if (SoLuongTon_Cu - numSoLuong.Value - numKhuyenMai.Value >= 0)
                numSoLuongTon.Value = SoLuongTon_Cu - numSoLuong.Value - numKhuyenMai.Value;
            else if (numSoLuong.Value != SoLuong_Cu)
            {
                numSoLuong.Value = SoLuongTon_Cu - numKhuyenMai.Value;
                numSoLuongTon.Value = 0;
            }
            numThanhTien.Value = numDonGia.Value * numSoLuong.Value;
            numThanhTien.Value = numThanhTien.Value * (1 - (decimal)(numChietKhau.Value / 100));
        }
        private void numKhuyenMai_ValueChanged(object sender, EventArgs e)
        {
            if (SoLuongTon_Cu - numSoLuong.Value - numKhuyenMai.Value >= 0)
                numSoLuongTon.Value = SoLuongTon_Cu - numSoLuong.Value - numKhuyenMai.Value;
            else if (numKhuyenMai.Value != KhuyenMai_Cu)
            {
                numKhuyenMai.Value = SoLuongTon_Cu - numSoLuong.Value;
                numSoLuongTon.Value = 0;
            }
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
            if (numDaTra.Value > numTongPhieuBan.Value) numDaTra.Value = numTongPhieuBan.Value;
            numConNo.Value = numTongPhieuBan.Value - numDaTra.Value;
        }

        private void numTongPhieuBan_ValueChanged(object sender, EventArgs e)
        {
            if (numDaTra.Value > numTongPhieuBan.Value) numDaTra.Value = numTongPhieuBan.Value;
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

        private void frmBanSi_FormClosing(object sender, FormClosingEventArgs e)
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
                if (numDaTra.Value != DaTra_Cu)
                {
                    PhieuThanhToanController PhieuThanhToan = new PhieuThanhToanController();
                    PhieuThanhToan.XoaPhieuThanhToanTheoIDPhieuBan(MaPhieuBan);
                    BusinessObject.PhieuThanhToan PTT = new BusinessObject.PhieuThanhToan();
                    long maso = ThamSo.LayMaPhieuThanhToan();
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
    }
}
