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
    public partial class FrmInKhoanPhaiThu : Form
    {
        public FrmInKhoanPhaiThu(DataGridView dg)
        {
            InitializeComponent();
            GetData(dg);
        }
        IList<BusinessObject.InKhoanPhaiThu> listIn = new List<BusinessObject.InKhoanPhaiThu>();
        private void GetData(DataGridView dg)
        {
            foreach (DataGridViewRow row in dg.Rows)
            {
                BusinessObject.InKhoanPhaiThu item = new BusinessObject.InKhoanPhaiThu();
                item.STT = Convert.ToInt32(row.Cells["STT"].Value.ToString());
                item.TenKhachHang = row.Cells["Tên Khách hàng"].Value.ToString();
                item.DiaChi = row.Cells["Địa chỉ"].Value.ToString();
                //
                double nodauky = 0;
                Double.TryParse(row.Cells["Nợ đầu kỳ"].Value.ToString(), out nodauky);
                item.NoDauKy = nodauky;
                //
                double phatsinhtang = 0;
                Double.TryParse(row.Cells["Phát sinh tăng"].Value.ToString(), out phatsinhtang);
                item.PhatSingTang = phatsinhtang;
                //
                double phatsinhgiam = 0;
                Double.TryParse(row.Cells["Phát sinh giảm"].Value.ToString(), out phatsinhgiam);
                item.PhatSinhGiam = phatsinhgiam;
                //
                double nohientai = 0;
                Double.TryParse(row.Cells["Nợ hiện tại"].Value.ToString(), out nohientai);
                item.NoHienTai = nohientai;
                //
                item.NgayLapPhieu = NgayThanhChu(DateTime.Now);
                listIn.Add(item);
            }
        }
        private string NgayThanhChu(DateTime dt)
        {
            return "Ngày " + dt.Day + " Tháng " + (dt.Month < 10 ? ("0" + dt.Month) : dt.Month.ToString()) + " Năm " + dt.Year;
        }
        private void FrmInKhoanPhaiThu_Load(object sender, EventArgs e)
        {
            listIn.Reverse();
            this.InKhoanPhaiThuBindingSource.DataSource = listIn;
            this.reportViewer1.RefreshReport();
        }
    }
}
