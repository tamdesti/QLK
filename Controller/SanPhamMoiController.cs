using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using QuanLyKho.BusinessObject;
using QuanLyKho.DataLayer;

namespace QuanLyKho.Controller
{
    class SanPhamMoiController
    {
        SanPhamMoiFactory factory = new SanPhamMoiFactory();
        public void HienthiDataGridview(System.Windows.Forms.DataGridView dg)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            System.Windows.Forms.BindingNavigator bn = new BindingNavigator();
            DataTable dt = new DataTable();
            dt = factory.DanhsachSanPham();
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
    }
}
