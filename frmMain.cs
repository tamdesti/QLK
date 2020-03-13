using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using QuanLyKho.BusinessObject;
using QuanLyKho.Controller;

namespace QuanLyKho
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void SetStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            //if (chkStartUp.Checked)
                rk.SetValue("QUANLYKHO", Application.ExecutablePath.ToString());
            //else
                //rk.DeleteValue("QUANLYKHO", false);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DataService.OpenConnection();
            checkDB();
        }
        private void checkDB()
        {
            if (ThamSo.NgayLapPhieu.ToShortDateString() != DateTime.Now.ToShortDateString())
            {
                ThamSo.NgayLapPhieu = DateTime.Now.Date;
                ThamSo.PhieuBanTrongNgay = 1;
                ThamSo.PhieuNhapTrongNgay = 1;
                string Str = System.Reflection.Assembly.GetEntryAssembly().Location.ToString();
                Str = Str.Remove(Str.LastIndexOf(@"\"));
                if (!Directory.Exists(@Str + @"\Back Up Data"))
                {
                    Directory.CreateDirectory(@Str + @"\Back Up Data");
                }
                if (File.Exists(@Str + @"\cuahang.mdb"))
                {
                    String filename = @"\Back Up Data\cuahang_" + DateTime.Now.Date.ToString("yyyyMMdd");
                    if (!File.Exists(@Str + @filename))
                    {
                        File.Copy(@Str + @"\cuahang.mdb", @Str + @filename);
                    }
                }
            }
        }
        private void FillFullScreen(Form form)
        {
            form.WindowState = FormWindowState.Maximized;
            foreach (var f in this.MdiChildren)
            {
                f.Close();
            }
        }

        frmDonViTinh DonViTinh = null;

        private void mnuDonViTinh_Click(object sender, EventArgs e)
        {
            if (DonViTinh == null || DonViTinh.IsDisposed)
            {
                DonViTinh = new frmDonViTinh();
                FillFullScreen(DonViTinh);
                DonViTinh.MdiParent = this;
                DonViTinh.Show();

            }
            else
                DonViTinh.Activate();
        }

        frmSanPham SanPham = null;
        private void mnuSanPham_Click(object sender, EventArgs e)
        {
            if (SanPham == null || SanPham.IsDisposed)
            {
                SanPham = new frmSanPham();
                FillFullScreen(SanPham);
                SanPham.MdiParent = this;                
                SanPham.Show();
            }
            else
                SanPham.Activate();
        }
        frmKhachHang KhachHang = null;
        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            if (KhachHang == null || KhachHang.IsDisposed)
            {
                KhachHang = new frmKhachHang();
                FillFullScreen(KhachHang);
                KhachHang.MdiParent = this;                
                KhachHang.Show();
            }
            else
                KhachHang.Activate();
        }
        frmDaiLy DaiLy = null;
        private void mnuDaiLy_Click(object sender, EventArgs e)
        {
            if (DaiLy == null || DaiLy.IsDisposed)
            {
                DaiLy = new frmDaiLy();
                FillFullScreen(DaiLy);
                DaiLy.MdiParent = this;
                DaiLy.Show();
            }
            else
                DaiLy.Activate();

        }
        frmDanhsachPhieuNhap NhapHang = null;
        private void mnuNhapHang_Click(object sender, EventArgs e)
        {
            if (NhapHang == null || NhapHang.IsDisposed)
            {
                NhapHang = new frmDanhsachPhieuNhap();
                FillFullScreen(NhapHang);
                NhapHang.MdiParent = this;
                NhapHang.Show();
            }
            else
                NhapHang.Activate();
        }
        frmDanhsachPhieuBanLe BanLe = null;
        private void mnuBanHangKH_Click(object sender, EventArgs e)
        {
            if (BanLe == null || BanLe.IsDisposed)
            {
                BanLe = new frmDanhsachPhieuBanLe();
                FillFullScreen(BanLe);
                BanLe.MdiParent = this;
                BanLe.Show();
            }
            else
                BanLe.Activate();
        }
        frmDanhsachPhieuBanSi BanSi = null;
        private void mnuBanHangDL_Click(object sender, EventArgs e)
        {
            if (BanSi == null || BanSi.IsDisposed)
            {
                BanSi = new frmDanhsachPhieuBanSi();
                FillFullScreen(BanSi);
                BanSi.MdiParent = this;
                BanSi.Show();
            }
            else
                BanSi.Activate();
        }

        private void mnuThanhCongCu_Click(object sender, EventArgs e)
        {
            mnuThanhCongCu.Checked = !mnuThanhCongCu.Checked;
            toolStrip.Visible = mnuThanhCongCu.Checked;
        }

        private void mnuThanhChucNang_Click(object sender, EventArgs e)
        {
            mnuThanhChucNang.Checked = !mnuThanhChucNang.Checked;
            taskPane.Visible = mnuThanhChucNang.Checked;
        }
        frmSoLuongBan SoLuongBan = null;
        private void mnuSoLuongBan_Click(object sender, EventArgs e)
        {
            if (SoLuongBan == null || SoLuongBan.IsDisposed)
            {
                SoLuongBan = new frmSoLuongBan();
                FillFullScreen(SoLuongBan);
                SoLuongBan.MdiParent = this;
                SoLuongBan.Show();
            }
            else
                SoLuongBan.Activate();
        }
        frmSanphamHethan SanphamHethan = null;
        private void mnuSanphamHethan_Click(object sender, EventArgs e)
        {
            if (SanphamHethan == null || SanphamHethan.IsDisposed)
            {
                SanphamHethan = new frmSanphamHethan();
                FillFullScreen(SanphamHethan);
                SanphamHethan.MdiParent = this;
                SanphamHethan.Show();
            }
            else
                SanphamHethan.Activate();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void mnuTuychinhThongtin_Click(object sender, EventArgs e)
        {
            frmThongtinCuahang ThongtinCuahang = new frmThongtinCuahang();
            ThongtinCuahang.ShowDialog();
        }
        frmThongtinLienhe ThongtinLienhe = null;
        private void mnuTrogiupLienhe_Click(object sender, EventArgs e)
        {
            if (ThongtinLienhe == null || ThongtinLienhe.IsDisposed)
            {
                ThongtinLienhe = new frmThongtinLienhe();
                ThongtinLienhe.MdiParent = this;
                ThongtinLienhe.Show();
            }
            else
                ThongtinLienhe.Activate();
        }

        frmNhaCungCap NhaCungCap = null;
        private void mnuNhaCungCap_Click(object sender, EventArgs e)
        {
            if (NhaCungCap == null || NhaCungCap.IsDisposed)
            {
                NhaCungCap = new frmNhaCungCap();
                FillFullScreen(NhaCungCap);
                NhaCungCap.MdiParent = this;
                NhaCungCap.Show();
            }
            else
                NhaCungCap.Activate();
        }
        frmLyDoChi LyDoChi = null;
        private void mnuLyDoChi_Click(object sender, EventArgs e)
        {
            if (LyDoChi == null || LyDoChi.IsDisposed)
            {
                LyDoChi = new frmLyDoChi();
                LyDoChi.MdiParent = this;
                LyDoChi.Show();
            }
            else
                LyDoChi.Activate();
        }

        private void mnuTrogiupHuongdan_Click(object sender, EventArgs e)
        {
            //Help.ShowHelp(this, "CPP.CHM");
        }
        frmQuanLy SoLuongTon = null;
        private void mnuBaocaoSoluongton_Click(object sender, EventArgs e)
        {
            if (SoLuongTon == null || SoLuongTon.IsDisposed)
            {
                SoLuongTon = new frmQuanLy(TypeOfReport.TonKho);
                FillFullScreen(SoLuongTon);
                SoLuongTon.MdiParent = this;
                SoLuongTon.Show();
            }
            else
                SoLuongTon.Activate();

        }
        frmQuanLy DaNhap = null;
        private void sảnPhẩmĐãNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DaNhap == null || DaNhap.IsDisposed)
            {
                DaNhap = new frmQuanLy(TypeOfReport.DaNhap);
                FillFullScreen(DaNhap);
                DaNhap.MdiParent = this;
                DaNhap.Show();
            }
            else
                DaNhap.Activate();
        }

        frmQuanLy DaBan = null;
        private void sảnPhẩmĐãBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DaBan == null || DaBan.IsDisposed)
            {
                DaBan = new frmQuanLy(TypeOfReport.DaBan);
                FillFullScreen(DaBan);
                DaBan.MdiParent = this;
                DaBan.Show();
            }
            else
                DaBan.Activate();
        }
        frmQuanLy HetHan = null;
        private void sảnPhẩmHếtHạnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (HetHan == null || HetHan.IsDisposed)
            {
                HetHan = new frmQuanLy(TypeOfReport.HetHan);
                FillFullScreen(HetHan);
                HetHan.MdiParent = this;
                HetHan.Show();
            }
            else
                HetHan.Activate();
        }
        frmTongHopNoCongTy DuNo = null;
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (DuNo == null || DuNo.IsDisposed)
            {
                DuNo = new frmTongHopNoCongTy();
                FillFullScreen(DuNo);
                DuNo.MdiParent = this;
                DuNo.Show();
            }
            else
                DuNo.Activate();
        }
        frmTongHopNoDaiLy DuNoDaiLy = null;
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (DuNoDaiLy == null || DuNoDaiLy.IsDisposed)
            {
                DuNoDaiLy = new frmTongHopNoDaiLy(QuanLyKho.DuNo.BanSi);
                FillFullScreen(DuNoDaiLy);
                DuNoDaiLy.MdiParent = this;
                DuNoDaiLy.Show();
            }
            else
                DuNoDaiLy.Activate();
        }
        frmTongHopNoDaiLy DuNoKH = null;
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (DuNoKH == null || DuNoKH.IsDisposed)
            {
                DuNoKH = new frmTongHopNoDaiLy(QuanLyKho.DuNo.BanLe);
                FillFullScreen(DuNoKH);
                DuNoKH.MdiParent = this;
                DuNoKH.Show();
            }
            else
                DuNoKH.Activate();
        }
        frmDanhSachPhieuChi PhieuChi = null;
        private void itemPhieuChi_Click(object sender, EventArgs e)
        {
            if(PhieuChi == null || PhieuChi.IsDisposed)
            {
                PhieuChi = new frmDanhSachPhieuChi();
                FillFullScreen(PhieuChi);
                PhieuChi.MdiParent = this;
                PhieuChi.Show();
            }
            else
                PhieuChi.Activate();
        }
        frmDanhSachPhieuThu PhieuThu = null;
        private void itemThanhToan_Click(object sender, EventArgs e)
        {
            if (PhieuThu == null || PhieuThu.IsDisposed)
            {
                PhieuThu = new frmDanhSachPhieuThu();
                FillFullScreen(PhieuThu);
                PhieuThu.MdiParent = this;
                PhieuThu.Show();
            }
            else
                PhieuThu.Activate();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var f in this.MdiChildren)
            {
                f.Close();
            }
        }

        private void phieuNhapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhieuNhapController PNCtrl = new PhieuNhapController();
            PhieuNhap PN = new PhieuNhap();
            NhaCungCapController NCCCtrl = new NhaCungCapController();
            SanPhamController SPCtrl = new SanPhamController();
            ChiTietPhieuNhapController CTPNCtrl = new ChiTietPhieuNhapController();
            IList<NhaCungCap> NCClist = new List<BusinessObject.NhaCungCap>();
            NCClist = NCCCtrl.LayDanhSachNCC();
            DateTime ExpDate = DateTime.Now.AddMonths(-1);
            foreach (NhaCungCap ncc in NCClist)
            {
                long maso = ThamSo.PhieuNhapTrongNgay;
                PN.Id = DateTime.Now.ToString("yyyyMMdd") + maso.ToString();
                PN.NgayNhap = DateTime.Now.Date;
                if (PNCtrl.VitriPhieuNhapMoiNhatTuNhaCungCap(ncc.Id) > -1)
                    PN.NoCu = PNCtrl.LayNoCuNhaCungCap(ncc.Id.ToString(), PNCtrl.VitriPhieuNhapMoiNhatTuNhaCungCap(ncc.Id));
                else
                    PN.NoCu = 0;
                PN.TongTien = 0;
                PN.DaTra = 0;
                PN.ConNo = 0;
                PN.NhaCungCap = ncc;
                if (PNCtrl.ThemPhieuNhap(PN) < 1) return;
                ThamSo.PhieuNhapTrongNgay = maso + 1;
                IList<SanPham> SPList = new List<SanPham>();
                SPList = SPCtrl.LayDanhSachSanPham(ncc.Id);
                Random random = new Random();
                for (int i= 0; i< 10; i++)
                {
                    ChiTietPhieuNhap MSP = new ChiTietPhieuNhap();
                    MSP.Id = random.Next(20171002,20181231).ToString();
                    ExpDate = ExpDate.AddDays(1);
                    MSP.SanPham = SPList[random.Next(0, SPList.Count - 1)];
                    MSP.PhieuNhap = PN;
                    MSP.GiaNhap = (double)random.Next(1100, 10000);
                    MSP.SoLuong = random.Next(1000, 5000);
                    MSP.NgayNhap = DateTime.Now;
                    try
                    {
                        CTPNCtrl.ThemChiTietPhieuNhap(MSP);
                        SPCtrl.CapNhatSoLuongSanPham(MSP.SanPham.Id, MSP.SanPham.SoLuong + MSP.SoLuong);
                        PN.TongTien += MSP.GiaNhap * MSP.SoLuong;
                    }
                    catch { }
                }
                PN.DaTra = random.Next(0, (int)(PN.TongTien + PN.NoCu));
                PhieuChiController PhieuChi = new PhieuChiController();
                BusinessObject.PhieuChi PC = new BusinessObject.PhieuChi();
                long _maso = ThamSo.PhieuChi;
                PC.Id = _maso.ToString();
                PC.NgayChi = DateTime.Now.Date;
                PC.TongTien = PN.DaTra;
                PC.PhieuNhap = PN.Id;
                PC.GhiChu = "Số tiền thanh toán trong lần đầu lập phiếu nhập";
                PhieuChi.ThemPhieuChi(PC);
                ThamSo.PhieuChi = maso + 1;
                PN.ConNo = PN.TongTien + PN.NoCu - PN.DaTra;
                PNCtrl.CapNhatPhieuNhap(PN);
            }
            

            //ChiTietPhieuNhap MSP = new ChiTietPhieuNhap();
            //DataRow row = ctrlChiTietPhieuNhap.NewRow();
            //row["ID"] = txtMasoLohang.Text;
            //row["ID_SAN_PHAM"] = cmbSanPham.SelectedValue;
            //row["ID_PHIEU_NHAP"] = txtMaPhieuNhap.Text;
            //row["DON_GIA_NHAP"] = numGiaNhap.Value;
            //row["SO_LUONG"] = numSoLuong.Value;
            //row["KHUYEN_MAI"] = numKhuyenmai.Value;
            //row["CHIET_KHAU"] = numChietKhau.Value;
            //row["NGAY_NHAP"] = dtNgayNhap.Value.Date;
            //row["NGAY_SAN_XUAT"] = dtNgaySanXuat.Value.Date;
            //row["NGAY_HET_HAN"] = dtNgayHetHan.Value.Date;
            //if (ctrlChiTietPhieuNhap.ThemChiTietPhieuNhap(row) > 0)
            //{
            //    cmbNhaCungCap.Enabled = false;
            //    ReloadForm();
            //    numThanhTongTien.Value = ctrl.LayTongTien(txtMaPhieuNhap.Text);
            //    CapNhatPhieuNhap();
            //}
        }
        frmQuanLy SoLuongTonMoi = null;
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (SoLuongTonMoi == null || SoLuongTonMoi.IsDisposed)
            {
                SoLuongTonMoi = new frmQuanLy(TypeOfReport.TonKhoMoi);
                FillFullScreen(SoLuongTonMoi);
                SoLuongTonMoi.MdiParent = this;
                SoLuongTonMoi.Show();
            }
            else
                SoLuongTon.Activate();
        }
        frmKhoHang KhoHang = null;
        private void taskItem4_Click(object sender, EventArgs e)
        {
            if (KhoHang == null || KhoHang.IsDisposed)
            {
                KhoHang = new frmKhoHang();
                FillFullScreen(KhoHang);
                KhoHang.MdiParent = this;
                KhoHang.Show();
            }
            else
                KhoHang.Activate();
        }
        
        frmDanhSachKhoanPhaiThu DSKhoanThu = null;
        private void danhSáchKhoảnThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DSKhoanThu == null || DSKhoanThu.IsDisposed)
            {
                DSKhoanThu = new frmDanhSachKhoanPhaiThu();
                FillFullScreen(DSKhoanThu);
                DSKhoanThu.MdiParent = this;
                DSKhoanThu.Show();
            }
            else
                DSKhoanThu.Activate();
        }
        FrmChiTietXuatKho frmChiTietXuatKho = null;
        private void chiTiếtXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmChiTietXuatKho == null || frmChiTietXuatKho.IsDisposed)
            {
                frmChiTietXuatKho = new FrmChiTietXuatKho();
                FillFullScreen(frmChiTietXuatKho);
                frmChiTietXuatKho.MdiParent = this;
                frmChiTietXuatKho.Show();
            }
            else
                frmChiTietXuatKho.Activate();
        }
        FrmChiTietXuatKhoTheoKhachHang frmChiTietXuatKhoTheoKhachHang = null;
        private void chiTiếtXuấtKhoTheoKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmChiTietXuatKhoTheoKhachHang == null || frmChiTietXuatKhoTheoKhachHang.IsDisposed)
            {
                frmChiTietXuatKhoTheoKhachHang = new FrmChiTietXuatKhoTheoKhachHang();
                FillFullScreen(frmChiTietXuatKhoTheoKhachHang);
                frmChiTietXuatKhoTheoKhachHang.MdiParent = this;
                frmChiTietXuatKhoTheoKhachHang.Show();
            }
            else
                frmChiTietXuatKhoTheoKhachHang.Activate();
        }
    }
}