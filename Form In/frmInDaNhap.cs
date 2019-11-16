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
        public frmInDaNhap(DataGridView dg, String Kho, String SP, DateTime fromdate, DateTime todate)
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
                item.TenSanPham = row.Cells["Tên Sản Phẩm"].Value.ToString();
                item.SoLuongNhap = Convert.ToInt32(row.Cells["Số lượng"].Value);
                item.DonGiaNhap = Convert.ToInt32(row.Cells["Đơn giá"].Value);
                item.TongTien = Convert.ToDouble(row.Cells["Thành tiền"].Value);
                item.NhaCungCap = row.Cells["colNCC"].FormattedValue.ToString();
                item.fromDate = FromDate;
                item.toDate = ToDate;
                listIn.Add(item);
                STT++;
            }
        }

        private void frmInDaNhap_Load(object sender, EventArgs e)
        {
            InChiTietQuanLyBindingSource.DataSource = listIn;
            this.reportViewer1.RefreshReport();
        }
    }
}
