using System;
using System.Collections.Generic;
using System.Text;
using QuanLyKho.DataLayer;
using QuanLyKho.BusinessObject;
using System.Windows.Forms;
using System.Data;

namespace QuanLyKho.Controller
{
    
    public class PhieuThanhToanController
    {
        PhieuThanhToanFactory factory = new PhieuThanhToanFactory();


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

        public PhieuThanhToan LayPhieuThanhToan(String id)
        {
            PhieuThanhToan ph = null;
            DataTable tbl = factory.LayPhieuThanhToan(id);
            if (tbl.Rows.Count > 0 )
            {
                ph = new PhieuThanhToan();
                ph.Id = Convert.ToString(tbl.Rows[0]["ID"]);
                ph.KhachHang = tbl.Rows[0]["ID_KHACH_HANG"].ToString();
                ph.NgayThanhToan = Convert.ToDateTime(tbl.Rows[0]["NGAY_THANH_TOAN"]);
                ph.TongTien = Convert.ToInt64(tbl.Rows[0]["TONG_TIEN"]);
                ph.GhiChu = Convert.ToString(tbl.Rows[0]["GHI_CHU"]);
                ph.PhieuBan = tbl.Rows[0]["ID_PHIEU_BAN"].ToString();
            }
            return ph;
        }
        public void CapNhatChiTietPhieuThu(DataRowView row)
        {
            PhieuThanhToanFactory CTPT = new PhieuThanhToanFactory();
            DataTable tbl = CTPT.LayPhieuThanhToan(row["ID"].ToString());
            if (tbl.Rows.Count > 0)
            {
                tbl.Rows[0]["GHI_CHU"] = row["GHI_CHU"];
                tbl.Rows[0]["TONG_TIEN"] = row["TONG_TIEN"];
                CTPT.Save();
            }
        }
        public void HienthiPhieuThanhToan(BindingNavigator bn, DataGridView dg, String IDPhieuBan)
        {
            BindingSource bs = new BindingSource();
            DataTable dt = new DataTable();
            dt = factory.DanhsachPhieuThanhToanTheoPhieuBan(IDPhieuBan);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public int ThemPhieuThanhToan(BusinessObject.PhieuThanhToan PTT)
        {
            return factory.ThemPhieuThanhToan(PTT);
        }
        public int XoaPhieuThanhToanTheoIDPhieuBan(string IDPhieuBan)
        {
            return factory.XoaPhieuThanhToanTheoIDPhieuBan(IDPhieuBan);
        }
    }
}
