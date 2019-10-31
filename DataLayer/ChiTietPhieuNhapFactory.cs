using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using QuanLyKho.BusinessObject;

namespace QuanLyKho.DataLayer
{
    public class ChiTietPhieuNhapFactory
    {
        DataService m_Ds = new DataService();

        public void LoadSchema()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM CHI_TIET_PHIEU_NHAP WHERE ID = '-1'");
            m_Ds.Load(cmd);
        }

        public DataTable DanhsachChiTietPhieuNhapTheoSanPham(String sp)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM CHI_TIET_PHIEU_NHAP WHERE ID_SAN_PHAM=@id");
            cmd.Parameters.Add("id", OleDbType.VarChar, 50).Value = sp;
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable DanhsachKhoTheoSanPham(String sp)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM CHI_TIET_PHIEU_NHAP WHERE ID_SAN_PHAM=@id");
            cmd.Parameters.Add("id", OleDbType.VarChar, 50).Value = sp;
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable DanhsachChiTiet(String sp)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM CHI_TIET_PHIEU_NHAP WHERE ID_PHIEU_NHAP=@id");
            cmd.Parameters.Add("id", OleDbType.VarChar, 50).Value = sp;
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable DanhsachChiTietCoDVT(String sp)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT MSP.*, SP.ID_DON_VI_TINH FROM CHI_TIET_PHIEU_NHAP MSP INNER JOIN SAN_PHAM SP ON MSP.ID_SAN_PHAM = SP.ID WHERE ID_PHIEU_NHAP=@id ORDER BY MSP.ID DESC");
            cmd.Parameters.Add("id", OleDbType.VarChar, 50).Value = sp;
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable LaySanPham(String idChiTietPhieuNhap)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT SP.* FROM SAN_PHAM SP INNER JOIN CHI_TIET_PHIEU_NHAP MSP ON SP.ID = MSP.ID_SAN_PHAM WHERE MSP.ID = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar,50).Value = idChiTietPhieuNhap;
            m_Ds.Load(cmd);
            return m_Ds;
        }

        public DataTable LayChiTietPhieuNhap(String idChiTietPhieuNhap)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM CHI_TIET_PHIEU_NHAP CTPN WHERE ID = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar,50).Value = idChiTietPhieuNhap;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable DanhsachTatCaChiTietPhieuNhap()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM CHI_TIET_PHIEU_NHAP");
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public static void CapNhatSoLuong(String masp, int so_luong)
        {
            DataService ds = new DataService();
            OleDbCommand cmd = new OleDbCommand("UPDATE CHI_TIET_PHIEU_NHAP SET SO_LUONG_TON = SO_LUONG_TON + @so WHERE ID = @id");
            cmd.Parameters.Add("so", OleDbType.Integer).Value = so_luong;
            cmd.Parameters.Add("id", OleDbType.VarChar).Value = masp;
            ds.ExecuteNoneQuery(cmd);
        }
        public int ThemChiTietPhieuNhap(DataRow row)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO CHI_TIET_PHIEU_NHAP VALUES(@ID, @SP, @PN, @GiaNhap, @SoLuong, @NgayNhap, @Kho, @ThanhTien)");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = row["ID"].ToString();
            cmd.Parameters.Add("SP", OleDbType.VarChar, 50).Value = row["ID_SAN_PHAM"].ToString();
            cmd.Parameters.Add("PN", OleDbType.VarChar, 50).Value = row["ID_PHIEU_NHAP"].ToString();
            cmd.Parameters.Add("GiaNhap", OleDbType.Double).Value = Convert.ToDouble(row["DON_GIA_NHAP"].ToString());
            cmd.Parameters.Add("SoLuong", OleDbType.Integer).Value = Convert.ToInt32(row["SO_LUONG"].ToString());
            cmd.Parameters.Add("NgayNhap", OleDbType.Date).Value = Convert.ToDateTime(row["NGAY_NHAP"].ToString());
            cmd.Parameters.Add("Kho", OleDbType.VarChar, 50).Value = row["ID_KHO"].ToString();
            cmd.Parameters.Add("ThanhTien", OleDbType.Double).Value = Convert.ToDouble(row["THANH_TIEN"].ToString());
            return m_Ds.ExecuteNoneQuery(cmd);
        }
        public int ThemChiTietPhieuNhap(ChiTietPhieuNhap CTPN)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO CHI_TIET_PHIEU_NHAP VALUES(@ID, @SP, @PN, @GiaNhap, @SoLuong, @NgayNhap, @Kho, @ThanhTien)");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = CTPN.Id;
            cmd.Parameters.Add("SP", OleDbType.VarChar, 50).Value = CTPN.SanPham.Id;
            cmd.Parameters.Add("PN", OleDbType.VarChar, 50).Value = CTPN.PhieuNhap.Id;
            cmd.Parameters.Add("GiaNhap", OleDbType.Double).Value = CTPN.GiaNhap;
            cmd.Parameters.Add("SoLuong", OleDbType.Integer).Value = CTPN.SoLuong;
            cmd.Parameters.Add("NgayNhap", OleDbType.Date).Value = CTPN.NgayNhap;
            cmd.Parameters.Add("Kho", OleDbType.VarChar, 50).Value = CTPN.KhoHang;
            cmd.Parameters.Add("ThanhTien", OleDbType.Double).Value = CTPN.ThanhTien;
            return m_Ds.ExecuteNoneQuery(cmd);
        }
        public void XoaChiTietPhieuNhap(String ID)
        {
            OleDbCommand cmd = new OleDbCommand("DELETE FROM CHI_TIET_PHIEU_NHAP WHERE ID = @ID");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = ID;
            m_Ds.ExecuteNoneQuery(cmd);
        }
        public DataRow NewRow()
        {
            return m_Ds.NewRow();
        }
        public void Add(DataRow row)
        {
            m_Ds.Rows.Add(row);
        }
        public bool Save()
        {
            return m_Ds.ExecuteNoneQuery() > 0;
        }
    }
}
