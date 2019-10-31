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
    public partial class frmInDaNhap : Form
    {
        String NhaCungCap = "";
        DateTime FromDate = DateTime.Now;
        DateTime ToDate = DateTime.Now;
        public frmInDaNhap(DataGridView dg, String NCC, String SP, DateTime fromdate, DateTime todate)
        {
            InitializeComponent();
            NhaCungCap = NCC;
            FromDate = fromdate;
            ToDate = todate;
            GetData(dg);
        }
        IList<BusinessObject.InChiTietQuanLy> listIn = new List<BusinessObject.InChiTietQuanLy>();
        private void GetData(DataGridView dg)
        {
            Controller.DonViTinhController dvt = new Controller.DonViTinhController();
            int STT = 1;
            foreach (DataGridViewRow row in dg.Rows)
            {
                //BusinessObject.InChiTietQuanLy item = new BusinessObject.InChiTietQuanLy();
                //item.STT = STT;
                //item.TenSanPham = row.Cells["colTenSanPham"].Value.ToString();
                //item.LoHang = row.Cells["colLoID"].Value.ToString();
                //item.TenDonViTinh = dvt.LayDVT(Convert.ToInt32(row.Cells["colDVT"].Value)).Ten;
                //item.SoLuongNhap = Convert.ToInt32(row.Cells["Số lượng"].Value);
                //item.Khuyenmai = Convert.ToInt32(row.Cells["Khuyến mãi"].Value);
                //item.NgayHetHan = Convert.ToDateTime(row.Cells["colNgayHetHan"].Value);
                //item.NgaySanXuat = Convert.ToDateTime(row.Cells["colNgaySanXuat"].Value);
                //item.TongTien = Convert.ToDouble(row.Cells["Thành tiền"].Value);
                //item.NhaCungCap = NhaCungCap;
                //item.fromDate = FromDate;
                //item.toDate = ToDate;
                //listIn.Add(item);
                //STT++;
            }
        }

        private void frmInDaNhap_Load(object sender, EventArgs e)
        {
            InChiTietQuanLyBindingSource.DataSource = listIn;
            this.reportViewer1.RefreshReport();
        }
    }
}
