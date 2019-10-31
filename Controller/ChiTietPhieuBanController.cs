using System;
using System.Collections.Generic;
using System.Text;
using QuanLyKho.DataLayer;
using QuanLyKho.BusinessObject;
using System.Windows.Forms;
using System.Data;

namespace QuanLyKho.Controller
{

    public class ChiTietPhieuBanController
    {
        ChiTietPhieuBanFactory factory = new ChiTietPhieuBanFactory();



        public void HienThiChiTiet(DataGridView dg, BindingNavigator bn, String idPhieuBan)
        {
            BindingSource bs = new BindingSource();
            DataTable dt = factory.DanhsachChiTietPhieuBan(idPhieuBan);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
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


        public IList<ChiTietPhieuBan> ChiTietPhieuBan(String idPhieuBan)
        {
            IList<ChiTietPhieuBan> ds = new List<ChiTietPhieuBan>();

            DataTable tbl = factory.DanhsachChiTietPhieuBan(idPhieuBan);
            foreach (DataRow row in tbl.Rows)
            {
                ChiTietPhieuNhapController ctrl = new ChiTietPhieuNhapController();
                SanPhamController SP = new SanPhamController();
                ChiTietPhieuBan ct = new ChiTietPhieuBan();
                ct.ID = Convert.ToInt32(row["ID"]);
                ct.DonGia = Convert.ToDouble(row["DON_GIA"]);
                ct.SoLuong = Convert.ToInt32(row["SO_LUONG"]);
                ct.ThanhTien = Convert.ToInt64(row["THANH_TIEN"]);
                ct.SanPham = SP.LaySanPham(Convert.ToString(row["ID_SAN_PHAM"]));
                ct.KhoHang = row["ID_KHO"].ToString();
                ds.Add(ct);
            }
            return ds;
        }

        public IList<ChiTietPhieuBan> ChiTietPhieuBan(DateTime dtNgayBan)
        {
            IList<ChiTietPhieuBan> ds = new List<ChiTietPhieuBan>();

            DataTable tbl = factory.LayChiTietPhieuBan(dtNgayBan);
            foreach (DataRow row in tbl.Rows)
            {
                ChiTietPhieuNhapController ctrl = new ChiTietPhieuNhapController();
                ChiTietPhieuBan ct = new ChiTietPhieuBan();
                ct.ID = Convert.ToInt32(row["ID"]);
                ct.DonGia = Convert.ToDouble(row["DON_GIA"]);
                ct.SoLuong = Convert.ToInt32(row["SO_LUONG"]);
                ct.ThanhTien = Convert.ToInt64(row["THANH_TIEN"]);
                ct.SanPham = ctrl.LaySanPham(Convert.ToString(row["ID_SAN_PHAM"]));
                ct.KhoHang = row["ID_KHO"].ToString();
                ds.Add(ct);
            }
            return ds;
        }
        public IList<ChiTietPhieuBan> ChiTietPhieuBan(int thang, int nam)
        {
            IList<ChiTietPhieuBan> ds = new List<ChiTietPhieuBan>();
            ChiTietPhieuNhapController ctrl = new ChiTietPhieuNhapController();
            KhoHangController ctrlKH = new KhoHangController();
            DataTable tbl = factory.LayChiTietPhieuBan(thang, nam);
            foreach (DataRow row in tbl.Rows)
            {
                ChiTietPhieuBan ct = new ChiTietPhieuBan();
                ct.ID = Convert.ToInt32(row["ID"]);
                ct.DonGia = Convert.ToDouble(row["DON_GIA"]);
                ct.SoLuong = Convert.ToInt32(row["SO_LUONG"]);
                ct.ThanhTien = Convert.ToInt64(row["THANH_TIEN"]);
                ct.SanPham = ctrl. LaySanPham(Convert.ToString(row["ID_SAN_PHAM"]));
                ct.KhoHang = row["ID_KHO"].ToString();
                ds.Add(ct);
            }
            return ds;
        }
        public int ThemChiTietPhieuBan(DataRow row)
        {
            PhieuBanController PB = new PhieuBanController();
            PhieuBan phieuban = PB.LayPhieuBan(row["ID_PHIEU_BAN"].ToString());
            row["NGAY_BAN"] = phieuban.NgayBan;
            return factory.ThemChiTietPhieuBan(row);
        }
        public void XoaChiTietPhieuBan(String ID)
        {
            factory.XoaChiTietPhieuBan(ID);
        }
        public void CapNhatChiTietPhieuBan(DataRowView row)
        {
            ChiTietPhieuBanFactory CTPB = new ChiTietPhieuBanFactory();
            DataTable tbl = CTPB.LayChiTietPhieuBan(row["ID"].ToString());
            if (tbl.Rows.Count > 0)
            {
                tbl.Rows[0]["ID_PHIEU_BAN"] = row["ID_PHIEU_BAN"];
                tbl.Rows[0]["ID_SAN_PHAM"] = row["ID_SAN_PHAM"];
                tbl.Rows[0]["SO_LUONG"] = row["SO_LUONG"];
                tbl.Rows[0]["DON_GIA"] = row["DON_GIA"];
                tbl.Rows[0]["THANH_TIEN"] = row["THANH_TIEN"];
                tbl.Rows[0]["ID_KHO"] = row["ID_KHO"];
                CTPB.Save();
            }
        }
    }
}
