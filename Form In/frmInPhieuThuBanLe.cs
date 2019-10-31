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
    public partial class frmInPhieuThuBanLe : Form
    {
        public frmInPhieuThuBanLe(DataGridView dg)
        {
            InitializeComponent();
            GetData(dg);
        }
        IList<BusinessObject.InChiTietThuChi> listIn = new List<BusinessObject.InChiTietThuChi>();
        private void GetData(DataGridView dg)
        {
            int STT = 1;
            foreach (DataGridViewRow row in dg.Rows)
            {
                BusinessObject.InChiTietThuChi item = new BusinessObject.InChiTietThuChi();
                item.STT = STT;
                string IDPhieuBan = row.Cells["colPhieuBan"].Value.ToString();
                Controller.PhieuBanController PB = new Controller.PhieuBanController();
                BusinessObject.PhieuBan pb = PB.LayPhieuBan(IDPhieuBan);
                item.TongTien = pb.TongTien;
                item.NoCu = pb.NoCu;
                item.DaTra = pb.DaTra;
                item.ConNo = pb.ConNo;
                item.HoTen = pb.KhachHang.HoTen;
                item.DiaChi = pb.KhachHang.DiaChi;
                item.DienThoai = pb.KhachHang.DienThoai;
                item.TenDaiLy = pb.KhachHang.TenDaiLy;
                item.IDPhieuBan = pb.Id;
                item.NgayLapPhieu = Convert.ToDateTime(row.Cells["colNgayThanhToan"].Value.ToString());
                item.ThanhTien = Convert.ToInt32(row.Cells["colTongTien"].Value.ToString());
                item.GhiChu = row.Cells["colGhiChu"].Value.ToString();
                STT++;
                listIn.Add(item);
            }
        }
        private void frmInPhieuThuBanLe_Load(object sender, EventArgs e)
        {
            InChiTietThuChiBindingSource.DataSource = listIn;
            this.reportViewer1.RefreshReport();
        }
    }
}
