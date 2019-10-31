using System;
using System.Collections.Generic;
using System.Text;
using QuanLyKho.DataLayer;
using QuanLyKho.BusinessObject;
using System.Windows.Forms;
using System.Data;

namespace QuanLyKho.Controller
{
    
    public class PhieuChiController
    {
        PhieuChiFactory factory = new PhieuChiFactory();
        public DataRow NewRow()
        {
            return factory.NewRow();
        }
        public void Add(DataRow row)
        {
            factory.Add(row);
        }
        public void Save()
        {
            factory.Save();
        }
        public int ThemPhieuChi(BusinessObject.PhieuChi PC)
        {
            return factory.ThemPhieuChi(PC);
        }
        public void HienThiDanhSachPhieuChiTheoPhieuNhap(BindingNavigator bn, DataGridView dg, String IDPhieuNhap)
        {
            BindingSource bs = new BindingSource();
            DataTable dt = new DataTable();
            dt = factory.DanhsachPhieuChiTheoPhieuNhap(IDPhieuNhap);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public int XoaPhieuChiTheoIDPhieuNhap(string IDPhieuNhap)
        {
            return factory.XoaPhieuChiTheoIDPhieuNhap(IDPhieuNhap);
        }
    }
}
