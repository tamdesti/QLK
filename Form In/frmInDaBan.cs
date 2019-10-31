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
    public partial class frmInDaBan : Form
    {
        String NhaCungCap = "";
        DateTime FromDate = DateTime.Now;
        DateTime ToDate = DateTime.Now;
        public frmInDaBan(DataGridView dg, String NCC, DateTime fromdate, DateTime todate)
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
                //item.SoLuongBan = Convert.ToInt32(row.Cells["Số lượng bán"].Value);
                //item.TongTien = Convert.ToInt32(row.Cells["Tổng tiền"].Value);
                //item.TongBanSi = Convert.ToInt32(row.Cells["Bán sỉ"].Value);
                //item.TongBanLe = Convert.ToInt32(row.Cells["Bán lẻ"].Value);
                //item.NhaCungCap = NhaCungCap;
                //item.fromDate = FromDate;
                //item.toDate = ToDate;
                //listIn.Add(item);
                //STT++;
            }
        }
        private void frmInDaBan_Load(object sender, EventArgs e)
        {
            InChiTietQuanLyBindingSource.DataSource = listIn;
            this.reportViewer1.RefreshReport();
        }
    }
}
