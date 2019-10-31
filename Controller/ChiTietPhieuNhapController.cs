using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using QuanLyKho.DataLayer;
using QuanLyKho.BusinessObject;

namespace QuanLyKho.Controller
{
    public class ChiTietPhieuNhapController
    {
        ChiTietPhieuNhapFactory factory = new ChiTietPhieuNhapFactory();

        public DataRow NewRow()
        {
            return factory.NewRow();
        }
        public void Add(DataRow row)
        {
            factory.Add(row);
        }
        public bool Save()
        {
            return factory.Save();
        }

        public SanPham LaySanPham(String idChiTietPhieuNhap)
        {
            ChiTietPhieuNhapFactory f = new ChiTietPhieuNhapFactory();
            DataTable tbl = f.LaySanPham(idChiTietPhieuNhap);
            SanPham sp = null;
            DonViTinhController ctrlDVT = new DonViTinhController();
            if (tbl.Rows.Count > 0)
            {
                sp =  new  SanPham();
                sp.Id = Convert.ToString(tbl.Rows[0]["ID"]);
                sp.TenSanPham = Convert.ToString(tbl.Rows[0]["TEN_SAN_PHAM"]);
                sp.SoLuong = Convert.ToInt32(tbl.Rows[0]["SO_LUONG"]);
                sp.DonGiaNhap = Convert.ToDecimal(tbl.Rows[0]["DON_GIA_NHAP"]);
                sp.DonViTinh = ctrlDVT.LayDVT(Convert.ToInt32(tbl.Rows[0]["ID_DON_VI_TINH"]));
            }
            return sp;

        }


        public ChiTietPhieuNhap LayChiTietPhieuNhap(String idChiTietPhieuNhap)
        {
            ChiTietPhieuNhapFactory f = new ChiTietPhieuNhapFactory();
            DataTable tbl = f.LayChiTietPhieuNhap(idChiTietPhieuNhap);
            ChiTietPhieuNhap sp = null;
            SanPhamController ctrlSanPham = new SanPhamController();
            if (tbl.Rows.Count > 0)
            {
                sp = new ChiTietPhieuNhap();
                sp.Id = Convert.ToString(tbl.Rows[0]["ID"]);
                sp.SoLuong = Convert.ToInt32(tbl.Rows[0]["SO_LUONG"]);
                sp.GiaNhap = Convert.ToInt64(tbl.Rows[0]["DON_GIA_NHAP"]);
                sp.NgayNhap = Convert.ToDateTime(tbl.Rows[0]["NGAY_NHAP"]);
                sp.SanPham = ctrlSanPham.LaySanPham(tbl.Rows[0]["ID_SAN_PHAM"].ToString());
            }
            return sp;

        }
        public Boolean ChiTietPhieuNhapDaTonTai(String Ten)
        {
            ChiTietPhieuNhapFactory f = new ChiTietPhieuNhapFactory();
            DataTable tbl = f.LayChiTietPhieuNhap(Ten);
            if (tbl.Rows.Count > 0)
            {
                return true;
            }
            return false;

        }
        public void HienthiPhieuNhap(DataGridView dg, BindingNavigator bn, string id)
        {
            System.Windows.Forms.BindingSource bs = new System.Windows.Forms.BindingSource();
            DataTable dt = factory.DanhsachChiTietCoDVT(id);
            BusinessObject.Util.AddSTTColumn(ref dt, ref bs, ref bn, ref dg);
        }
        public void HienThiAutoComboBox(String sp, ComboBox cmb)
        {
            cmb.DataSource = factory.DanhsachChiTietPhieuNhapTheoSanPham(sp); ;
            cmb.DisplayMember = "ID";
            cmb.ValueMember = "ID";
            cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        }
        public void HienThiDataGridViewComboBox(DataGridViewComboBoxColumn cmb)
        {
            cmb.DataSource = factory.DanhsachTatCaChiTietPhieuNhap();
            cmb.DisplayMember = "ID";
            cmb.ValueMember = "ID";
            cmb.DataPropertyName = "ID_CHI_TIET_PHIEU_NHAP";            
        }

        public IList<ChiTietPhieuNhap> ChiTietPhieuNhap(String id)
        {
            SanPhamController ctrlSanPham = new SanPhamController();
            IList<ChiTietPhieuNhap> ds = new List<ChiTietPhieuNhap>();
            DataTable tbl = factory.DanhsachChiTiet(id);
            foreach (DataRow row in tbl.Rows)
            {
                ChiTietPhieuNhap sp = new ChiTietPhieuNhap();
                sp = new ChiTietPhieuNhap();
                sp.Id = Convert.ToString(row["ID"]);
                sp.SoLuong = Convert.ToInt32(row["SO_LUONG"]);
                sp.GiaNhap = Convert.ToInt64(row["DON_GIA_NHAP"]);
                sp.ThanhTien = sp.SoLuong * sp.GiaNhap;
                sp.NgayNhap = Convert.ToDateTime(row["NGAY_NHAP"]);
                sp.SanPham = ctrlSanPham.LaySanPham(row["ID_SAN_PHAM"].ToString());
                ds.Add(sp);
            }
            return ds;
        }
        public int ThemChiTietPhieuNhap(DataRow row)
        {
            SanPhamController SPCtrl = new Controller.SanPhamController();
            SanPham SP = SPCtrl.LaySanPham(row["ID_SAN_PHAM"].ToString());
            SP.DonGiaNhap = Convert.ToDecimal(row["DON_GIA_NHAP"]);
            SPCtrl.CapNhatDonGiaNhap(SP);
            return factory.ThemChiTietPhieuNhap(row);
        }
        public int ThemChiTietPhieuNhap(ChiTietPhieuNhap msp)
        {
            return factory.ThemChiTietPhieuNhap(msp);
        }
        public void XoaChiTietPhieuNhap(String ID)
        {
            factory.XoaChiTietPhieuNhap(ID);
        }
        public void CapNhatChiTietPhieuNhap(DataRowView row, string old_ID)
        {
            DataTable tbl = factory.LayChiTietPhieuNhap(old_ID);
            if (tbl.Rows.Count > 0)
            {
                tbl.Rows[0]["ID"] = row["ID"];
                tbl.Rows[0]["ID_SAN_PHAM"] = row["ID_SAN_PHAM"];
                tbl.Rows[0]["DON_GIA_NHAP"] = row["DON_GIA_NHAP"];
                tbl.Rows[0]["SO_LUONG"] = row["SO_LUONG"];
                tbl.Rows[0]["NGAY_NHAP"] = row["NGAY_NHAP"];
                tbl.Rows[0]["THANH_TIEN"] = row["THANH_TIEN"];
                factory.Save();
            }
            SanPhamController SPCtrl = new Controller.SanPhamController();
            SanPham SP = SPCtrl.LaySanPham(row["ID_SAN_PHAM"].ToString());
            SP.DonGiaNhap = Convert.ToDecimal(row["DON_GIA_NHAP"]);
            SPCtrl.CapNhatDonGiaNhap(SP);
        }
        public void CapNhatSoLuongTon(string ID, decimal SoluongTon)
        {
            ChiTietPhieuNhapFactory MSPFactory = new ChiTietPhieuNhapFactory();
            DataTable tbl = MSPFactory.LayChiTietPhieuNhap(ID);
            if (tbl.Rows.Count > 0)
            {
                tbl.Rows[0]["SO_LUONG_TON"] = SoluongTon;
                MSPFactory.Save();
            }
        }
        public bool MaSoLoHangDaCo(String ID)
        {
            DataTable dt = factory.LayChiTietPhieuNhap(ID);
            if (dt.Rows.Count > 0) return true;
            return false;
        }        
    }
}
