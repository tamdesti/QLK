using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho
{
    public partial class frmInPhieuChi : Form
    {
        public frmInPhieuChi(DataGridView dg)
        {
            InitializeComponent();
            GetData(dg);
        }
        IList<BusinessObject.InChiTietThuChi> listIn = new List<BusinessObject.InChiTietThuChi>();
        private void GetData(DataGridView dg)
        {
            Controller.PhieuChiController PC = new Controller.PhieuChiController();
            int STT = 1;
            foreach (DataGridViewRow row in dg.Rows)
            {
                BusinessObject.InChiTietThuChi item = new BusinessObject.InChiTietThuChi();
                item.STT = STT;
                string IDPhieuNhap = row.Cells["colPhieuBan"].Value.ToString();
                Controller.PhieuNhapController PN = new Controller.PhieuNhapController();
                BusinessObject.PhieuNhap pn = PN.LayPhieuNhap(IDPhieuNhap);
                item.NoCu = pn.NoCu;
                item.TongTien = pn.TongTien;
                item.DaTra = pn.DaTra;
                item.ConNo = pn.ConNo;
                item.TenDaiLy = pn.NhaCungCap.HoTen;
                item.DiaChi = pn.NhaCungCap.DiaChi;
                item.DienThoai = pn.NhaCungCap.DienThoai;
                item.IDPhieuBan = pn.Id;
                item.NgayLapPhieu = Convert.ToDateTime(row.Cells["colNgayThanhToan"].Value.ToString());
                item.ThanhTien = Convert.ToInt32(row.Cells["colTongTien"].Value.ToString());
                item.GhiChu = row.Cells["colGhiChu"].Value.ToString();
                STT++;
                listIn.Add(item);
            }
        }
        private void frmInPhieuChi_Load(object sender, EventArgs e)
        {
            InChiTietThuChiBindingSource.DataSource = listIn;
            this.reportViewer1.RefreshReport();
        }
    }
}
