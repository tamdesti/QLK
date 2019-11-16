using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using QuanLyKho.DataLayer;
using QuanLyKho.BusinessObject;

namespace QuanLyKho.Controller
{
    class TonKhoController
    {
        TonKhoFactory factory = new TonKhoFactory();
        public void CapNhatSoLuongTon_Them(string IDSP, string IDKHO, decimal soluongton)
        {
            factory.CapNhatSoLuongTon_Them(IDSP, IDKHO, soluongton);
        }
        public void CapNhatSoLuongTon(string IDSP, string IDKHO, decimal soluongton)
        {
            factory.CapNhatSoLuongTon(IDSP, IDKHO, soluongton);
        }
        public TonKho LayTonKho(string IDSP, string IDKHO)
        {
            DataTable tbl = factory.LayTonKho(IDSP, IDKHO);
            TonKho tonkho = new TonKho();
            if (tbl.Rows.Count > 0)
            {
                tonkho.KhoHang = Convert.ToString(tbl.Rows[0]["ID_KHO"]);
                tonkho.SoLuongTon = Convert.ToInt64(tbl.Rows[0]["SO_LUONG_TON"]);
                SanPhamController spCtrl = new SanPhamController();
                SanPham sp = new SanPham();
                sp = spCtrl.LaySanPham(Convert.ToString(tbl.Rows[0]["ID_SAN_PHAM"]));
                tonkho.SanPham = sp;
            }
            return tonkho;
        }
        public long LaySoLuongTon(string IDSP, string IDKHO)
        {
            return factory.LaySoLuongTon(IDSP, IDKHO);
        }
        public Boolean TonKhoDaTonTai(string IDSP, string IDKHO)
        {
            DataTable tbl = factory.LayTonKho(IDSP, IDKHO);
            if (tbl.Rows.Count > 0)
            {
                return true;
            }
            return false;

        }
        public IList<TonKho> LayTonKho()
        {
            SanPhamController spctrl = new SanPhamController();
            DataTable tbl = factory.LayTonKho();
            IList<TonKho> ds = new List<TonKho>();
            foreach (DataRow row in tbl.Rows)
            {
                TonKho tk = new TonKho();
                tk.KhoHang = Convert.ToString(row["ID_KHO"]);
                tk.SanPham = spctrl.LaySanPham(Convert.ToString(row["ID_SAN_PHAM"]));
                if (row["SO_LUONG_TON"].ToString() == "") tk.SoLuongTon = 0;
                else tk.SoLuongTon = Convert.ToInt32(row["SO_LUONG_TON"]);
                ds.Add(tk);
            }
            return ds;
        }
        public void CapNhatTatCaTonKho()
        {
            factory.CapNhatTatCaTonKho();
        }
        public long TongDaNhap(string IDSP, string IDKho)
        {
            return factory.TongSoNhap(IDSP, IDKho);
        }
        public long TongDaBan(string IDSP, string IDKho)
        {
            return factory.TongSoBan(IDSP, IDKho);
        }
        public int ThemTonKho(TonKho tk)
        {
            return factory.ThemTonKho(tk);
        }
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
    }
}
