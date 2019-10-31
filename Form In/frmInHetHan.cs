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
    public partial class frmInHetHan : Form
    {
        String NhaCungCap = "";
        public frmInHetHan(DataGridView dg, String NCC)
        {
            InitializeComponent();
            NhaCungCap = NCC;
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
                //item.SoLuongNhap = Convert.ToInt32(row.Cells["Số lượng nhập"].Value);
                //item.SoLuongTon = Convert.ToInt32(row.Cells["Số lượng tồn"].Value);
                //item.NgayHetHan = Convert.ToDateTime(row.Cells["colNgayHetHan"].Value);
                //item.NhaCungCap = NhaCungCap;
                //listIn.Add(item);
                //STT++;
            }
        }
        private void frmInHetHan_Load(object sender, EventArgs e)
        {
            InChiTietQuanLyBindingSource.DataSource = listIn;
            this.reportViewer1.RefreshReport();
        }
    }
}
