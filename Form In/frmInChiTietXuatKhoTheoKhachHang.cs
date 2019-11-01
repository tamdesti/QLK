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
    public partial class frmInChiTietXuatKhoTheoKhachHang : Form
    {
        //Nếu theo khách hàng thì 
        public frmInChiTietXuatKhoTheoKhachHang(DataGridView dg, DateTime dtFrom, DateTime dtTo, string TenKhachHang)
        {
            InitializeComponent();
            GetData(dg, dtFrom, dtTo,TenKhachHang);
        }
        IList<BusinessObject.ChiTietXuatKho> listIn = new List<BusinessObject.ChiTietXuatKho>();
        private void GetData(DataGridView dg, DateTime dtFrom, DateTime dtTo, string TenKhachHang)
        {
            foreach (DataGridViewRow row in dg.Rows)
            {
                BusinessObject.ChiTietXuatKho item = new BusinessObject.ChiTietXuatKho();
                item.STT = Convert.ToInt32(row.Cells["STT"].Value.ToString());
                item.TenKhachHang = TenKhachHang;
                item.MatHang = row.Cells["Mặt hàng"].Value.ToString();
                item.NgayBan = Convert.ToDateTime(row.Cells["Ngày"].Value);
                item.SoLuongBan = Convert.ToInt32(row.Cells["Số lượng"].Value);
                item.DonGia = Convert.ToDouble(row.Cells["Đơn giá"].Value);
                item.TienHang = Convert.ToDouble(row.Cells["Tiền hàng"].Value);
                item.NgayLapPhieu = NgayThanhChu(dtFrom, dtTo);
                listIn.Add(item);
            }
        }
        private string NgayThanhChu(DateTime dtFrom, DateTime dtTo)
        {
            return "Từ ngày: " + (dtFrom.Day < 10 ? "0" + dtFrom.Day : dtFrom.Day.ToString()) + "/" + (dtFrom.Month < 10 ? "0" + dtFrom.Month : dtFrom.Month.ToString()) + "/" + dtFrom.Year + " Đến ngày: " + (dtTo.Day < 10 ? "0" + dtTo.Day : dtTo.Day.ToString()) + "/" + (dtTo.Month < 10 ? "0" + dtTo.Month : dtTo.Month.ToString()) + "/" + dtTo.Year;
        }

        private void frmInChiTietXuatKho_Load(object sender, EventArgs e)
        {
            listIn.Reverse();
            this.ChiTietXuatKhoBindingSource.DataSource = listIn;
            this.reportViewer1.RefreshReport();
        }
    }
}
