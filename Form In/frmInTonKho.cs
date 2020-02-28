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
    public partial class frmInTonKho : Form
    {
        public frmInTonKho(DataGridView dg, String NCC)
        {
            InitializeComponent();
            GetData(dg);
        }
        IList<BusinessObject.InChiTietQuanLy> listIn = new List<BusinessObject.InChiTietQuanLy>();
        private void GetData(DataGridView dg)
        {
            foreach (DataGridViewRow row in dg.Rows)
            {
                BusinessObject.InChiTietQuanLy item = new BusinessObject.InChiTietQuanLy();
                item.STT = Convert.ToInt32(row.Cells["STT"].Value.ToString());
                item.TenSanPham = row.Cells["Tên sản phẩm"].Value.ToString();
                item.Dai = Convert.ToInt64(row.Cells["Dài"].Value.ToString());
                //if (item.Dai > 1) item.Dai = item.Dai / (double)1000;
                item.Rong = Convert.ToInt64(row.Cells["Rộng"].Value.ToString());
                //if (item.Rong > 1) item.Rong = item.Rong / (double)1000;
                double nhap = 0;
                Double.TryParse(row.Cells["Nhập"].Value.ToString(), out nhap);
                item.Nhap = nhap;
                double xuat = 0;
                Double.TryParse(row.Cells["Xuất"].Value.ToString(), out xuat);
                item.Xuat = xuat;
                item.TonDau = Convert.ToInt64(row.Cells["Tồn đầu"].Value.ToString());
                item.TonCuoi = Convert.ToInt64(row.Cells["Tồn cuối"].Value.ToString());
                item.DonGiaNhap = Convert.ToInt64(row.Cells["Đơn giá"].Value.ToString());
                item.ThanhTien = Convert.ToInt64(row.Cells["Thành tiền"].Value.ToString());
                if (row.Cells["colGhiChu"].Value != null)
                    item.GhiChu = row.Cells["colGhiChu"].Value.ToString();
                else item.GhiChu = "";
                item.NgayLapPhieu = NgayThanhChu(DateTime.Now);
                if (item.Dai == 1 && item.Rong == 1) continue;
                listIn.Add(item);
            }
        }
        private string NgayThanhChu(DateTime dt)
        {
            return "(Ngày " + dt.Day + " Tháng " + (dt.Month < 10 ? ("0" + dt.Month) : dt.Month.ToString()) + " Năm " + dt.Year + ")";
        }
        private void frmInTonKho_Load(object sender, EventArgs e)
        {
            listIn.Reverse();
            this.InChiTietQuanLyBindingSource.DataSource = listIn;
            this.reportViewer1.RefreshReport();
        }
    }
}
