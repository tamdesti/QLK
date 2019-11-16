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
        DateTime FromDate = DateTime.Now;
        DateTime ToDate = DateTime.Now;
        public frmInDaBan(DataGridView dg, String NCC, DateTime fromdate, DateTime todate)
        {
            InitializeComponent();
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
                BusinessObject.InChiTietQuanLy item = new BusinessObject.InChiTietQuanLy();
                item.STT = STT;
                item.TenSanPham = row.Cells["Tên sản phẩm"].Value.ToString();
                item.DonGiaNhap = Convert.ToInt32(row.Cells["Đơn giá"].Value);
                item.SoLuongBan = Convert.ToInt32(row.Cells["Số lượng"].Value);
                item.TongTien = Convert.ToInt32(row.Cells["Thành tiền"].Value);
                item.NhaCungCap = row.Cells["colKhachHang"].FormattedValue.ToString(); ;
                item.fromDate = FromDate;
                item.toDate = ToDate;
                listIn.Add(item);
                STT++;
            }
        }
        private void frmInDaBan_Load(object sender, EventArgs e)
        {
            InChiTietQuanLyBindingSource.DataSource = listIn;
            this.reportViewer1.RefreshReport();
        }
    }
}
