using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace QuanLyKho.DataLayer
{
    public class SanPhamFactory
    {
        DataService m_Ds = new DataService();

        public DataTable DanhsachSanPham()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM SAN_PHAM ORDER BY TEN_SAN_PHAM");
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable LaySanPhamTuTen(String ten)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT SP.* FROM SAN_PHAM SP INNER JOIN DON_VI_TINH DVT ON DVT.ID = SP.ID_DON_VI_TINH WHERE SP.TEN_SAN_PHAM = @ten");
            cmd.Parameters.Add("ten", OleDbType.VarChar, 50).Value = ten;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable DanhsachSanPhamCoDVT()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT SP.*, SP.TEN_SAN_PHAM + ' - ' + DVT.TEN_DON_VI AS [FULL_TEN_SAN_PHAM] FROM SAN_PHAM SP INNER JOIN DON_VI_TINH DVT ON DVT.ID = SP.ID_DON_VI_TINH");
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable DanhsachSanPhamFullByNCC(String IDNCC)
        {
            if (IDNCC == "0" || IDNCC == "-1") return DanhsachSanPhamCoDVT();
            OleDbCommand cmd = new OleDbCommand("SELECT SP.*, SP.TEN_SAN_PHAM + ' - ' + DVT.TEN_DON_VI AS [FULL_TEN_SAN_PHAM] FROM SAN_PHAM SP INNER JOIN DON_VI_TINH DVT ON DVT.ID = SP.ID_DON_VI_TINH WHERE SP.ID_NHA_CUNG_CAP = @IDNCC");
            cmd.Parameters.Add("IDNCC", OleDbType.VarChar).Value = IDNCC;
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable DanhsachSanPhamByNCC(String IDNCC)
        {
            if (IDNCC == "0" || IDNCC == "-1") return DanhsachSanPhamCoDVT();
            OleDbCommand cmd = new OleDbCommand("SELECT SP.* FROM SAN_PHAM SP INNER JOIN DON_VI_TINH DVT ON DVT.ID = SP.ID_DON_VI_TINH WHERE SP.ID_NHA_CUNG_CAP = @IDNCC");
            cmd.Parameters.Add("IDNCC", OleDbType.VarChar).Value = IDNCC;
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable DanhSachSanPhamByKho(String IDKHO)
        {
            if (IDKHO == "0" || IDKHO == "-1") return DanhsachSanPham();
            OleDbCommand cmd = new OleDbCommand("SELECT SAN_PHAM.ID, SAN_PHAM.TEN_SAN_PHAM, SAN_PHAM.ID_DON_VI_TINH, SAN_PHAM.ID_NHA_CUNG_CAP " +
                                                    "FROM SAN_PHAM INNER JOIN CHI_TIET_PHIEU_NHAP ON SAN_PHAM.ID = CHI_TIET_PHIEU_NHAP.ID_SAN_PHAM " +
                                                    "WHERE (CHI_TIET_PHIEU_NHAP.ID_KHO=@IDKHO) " +
                                                    "GROUP BY SAN_PHAM.ID, SAN_PHAM.TEN_SAN_PHAM, SAN_PHAM.ID_DON_VI_TINH, SAN_PHAM.ID_NHA_CUNG_CAP "+
                                                    "ORDER BY SAN_PHAM.TEN_SAN_PHAM");
            cmd.Parameters.Add("IDKHO", OleDbType.VarChar, 50).Value = IDKHO;
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable DanhSachSanPhamXuatKho(String IDKHO, DateTime fromDate, DateTime toDate)
        {
            string WhereString = "";
            if (IDKHO != "0")
            {
                WhereString += " AND CHI_TIET_PHIEU_BAN.ID_KHO=@IDKHO";
            }
            OleDbCommand cmd = new OleDbCommand("SELECT SAN_PHAM.ID, SAN_PHAM.TEN_SAN_PHAM, SAN_PHAM.ID_DON_VI_TINH, SAN_PHAM.ID_NHA_CUNG_CAP " +
                                                    "FROM ((SAN_PHAM INNER JOIN CHI_TIET_PHIEU_BAN ON SAN_PHAM.ID = CHI_TIET_PHIEU_BAN.ID_SAN_PHAM) INNER JOIN PHIEU_BAN ON PHIEU_BAN.ID = CHI_TIET_PHIEU_BAN.ID_PHIEU_BAN) " +
                                                    "WHERE CHI_TIET_PHIEU_BAN.NGAY_BAN >= @date1 AND CHI_TIET_PHIEU_BAN.NGAY_BAN <= @date2 " + WhereString +
                                                    " GROUP BY SAN_PHAM.ID, SAN_PHAM.TEN_SAN_PHAM, SAN_PHAM.ID_DON_VI_TINH, SAN_PHAM.ID_NHA_CUNG_CAP " +
                                                    "ORDER BY SAN_PHAM.TEN_SAN_PHAM");
            cmd.Parameters.Add("date1", OleDbType.Date).Value = fromDate.Date;
            cmd.Parameters.Add("date2", OleDbType.Date).Value = toDate.Date;
            if (IDKHO != "0") cmd.Parameters.Add("IDKHO", OleDbType.VarChar, 50).Value = IDKHO;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable DanhSachSanPhamByKhoVaKhach(String IDKHO, String IDKhach, DateTime fromDate, DateTime toDate)
        {
            string WhereString = "";
            if (IDKhach != "0")
            {
                WhereString = " AND PHIEU_BAN.ID_KHACH_HANG=@IDKHACH ";
                if (IDKHO != "0")
                {
                    WhereString += " AND CHI_TIET_PHIEU_BAN.ID_KHO=@IDKHO";
                }
            }
            else
            {
                if (IDKHO != "0")
                {
                    WhereString += " AND CHI_TIET_PHIEU_BAN.ID_KHO=@IDKHO";
                }
            }
            OleDbCommand cmd = new OleDbCommand("SELECT SAN_PHAM.ID, SAN_PHAM.TEN_SAN_PHAM, SAN_PHAM.ID_DON_VI_TINH, SAN_PHAM.ID_NHA_CUNG_CAP " +
                                                    "FROM ((SAN_PHAM INNER JOIN CHI_TIET_PHIEU_BAN ON SAN_PHAM.ID = CHI_TIET_PHIEU_BAN.ID_SAN_PHAM) INNER JOIN PHIEU_BAN ON PHIEU_BAN.ID = CHI_TIET_PHIEU_BAN.ID_PHIEU_BAN) " +
                                                    "WHERE CHI_TIET_PHIEU_BAN.NGAY_BAN >= @date1 AND CHI_TIET_PHIEU_BAN.NGAY_BAN <= @date2 " + WhereString + 
                                                    " GROUP BY SAN_PHAM.ID, SAN_PHAM.TEN_SAN_PHAM, SAN_PHAM.ID_DON_VI_TINH, SAN_PHAM.ID_NHA_CUNG_CAP " +
                                                    "ORDER BY SAN_PHAM.TEN_SAN_PHAM");
            cmd.Parameters.Add("date1", OleDbType.Date).Value = fromDate.Date;
            cmd.Parameters.Add("date2", OleDbType.Date).Value = toDate.Date;
            if (IDKhach != "0") cmd.Parameters.Add("IDKHACH", OleDbType.VarChar, 50).Value = IDKhach;
            if (IDKHO != "0") cmd.Parameters.Add("IDKHO", OleDbType.VarChar, 50).Value = IDKHO;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable TimChiTietPhieuNhap(String id)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM SAN_PHAM WHERE ID LIKE '%' + @id + '%'");
            cmd.Parameters.Add("id", OleDbType.VarChar).Value = id;
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public DataTable TimTenSanPham(String ten)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM SAN_PHAM WHERE TEN_SAN_PHAM LIKE '%' + @ten + '%'");
            cmd.Parameters.Add("ten", OleDbType.VarChar).Value = ten;
            m_Ds.Load(cmd);

            return m_Ds;
        }


        public DataTable LaySanPham(String id)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM SAN_PHAM WHERE ID = @id");
            cmd.Parameters.Add("id", OleDbType.VarChar, 50).Value = id;
            m_Ds.Load(cmd);
            return m_Ds;
        }
       
        public DataTable LaySoLuongTonByNCC(String NCC) 
        {
            OleDbCommand cmd = new OleDbCommand("SELECT SP.ID, SP.TEN_SAN_PHAM, MSP.ID AS LO_ID, SP.ID_DON_VI_TINH, MSP.SO_LUONG AS [Số lượng nhập], SUM(MSP.SO_LUONG * MSP.DON_GIA_NHAP) AS [Tổng tiền nhập], MSP.SO_LUONG_TON AS [Số lượng tồn], IIF(DSUM(\"CHI_TIET_PHIEU_BAN.SO_LUONG\", \"CHI_TIET_PHIEU_BAN\", \"ID_CHI_TIET_PHIEU_NHAP='\" & MSP.ID & \"'\") > 0, DSUM(\"CHI_TIET_PHIEU_BAN.SO_LUONG\", \"CHI_TIET_PHIEU_BAN\", \"ID_CHI_TIET_PHIEU_NHAP='\" & MSP.ID & \"'\"), 0) AS [Số lượng bán], IIF(DSUM(\"CHI_TIET_PHIEU_BAN.THANH_TIEN\", \"CHI_TIET_PHIEU_BAN\", \"ID_CHI_TIET_PHIEU_NHAP='\" & MSP.ID & \"'\") > 0, DSUM(\"CHI_TIET_PHIEU_BAN.THANH_TIEN\", \"CHI_TIET_PHIEU_BAN\", \"ID_CHI_TIET_PHIEU_NHAP='\" & MSP.ID & \"'\"), 0) AS [Tổng tiền bán] " +
                "FROM (SAN_PHAM SP INNER JOIN CHI_TIET_PHIEU_NHAP MSP ON SP.ID = MSP.ID_SAN_PHAM) " +
                "WHERE MSP.SO_LUONG_TON > 0 " + (NCC == "0" ? " " : " AND SP.ID_NHA_CUNG_CAP=@NCC ") + "  " +
                "GROUP BY SP.ID, SP.TEN_SAN_PHAM, MSP.ID, SP.ID_DON_VI_TINH, MSP.SO_LUONG, MSP.SO_LUONG_TON ");
            if (NCC != "0") cmd.Parameters.Add("NCC", OleDbType.VarChar, 50).Value = NCC;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable LaySoLuongTonByKho(String IDKHO)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT KH.TEN_KHO AS [Kho hàng], TK.SO_LUONG_TON AS [Tồn cuối], TK.SO_LUONG_TON AS [Tồn đầu], SP.TEN_SAN_PHAM AS [Tên sản phẩm], SP.DAI AS [Dài], SP.RONG AS [Rộng], " +
                                                "DSum(\"CHI_TIET_PHIEU_NHAP.SO_LUONG\",\"CHI_TIET_PHIEU_NHAP\",\"ID_SAN_PHAM = '\" & SP.ID & \"' AND ID_KHO = '\" & KH.ID & \"' AND NGAY_NHAP = Date() \") AS [Nhập], " +
                                                "DSum(\"CHI_TIET_PHIEU_BAN.SO_LUONG\",\"CHI_TIET_PHIEU_BAN\",\"ID_SAN_PHAM = '\" & SP.ID & \"' AND ID_KHO = '\" & KH.ID & \"' AND NGAY_BAN = Date() \") AS [Xuất], " +
                                                "SP.GIA_NHAP AS [Đơn giá], SP.LOAI AS [Loại], SP.GIA_NHAP AS [Thành tiền] " + 
                                                "FROM(SAN_PHAM  SP INNER JOIN TON_KHO TK ON SP.ID = TK.ID_SAN_PHAM) INNER JOIN KHO_HANG KH ON TK.ID_KHO = KH.ID " +
                                                "WHERE TK.SO_LUONG_TON > 0 " + (IDKHO == "0" ? " " : " AND TK.ID_KHO = @KHO ") +  
                                                "ORDER BY SP.TEN_SAN_PHAM; ");
            if (IDKHO != "0") cmd.Parameters.Add("KHO", OleDbType.VarChar, 50).Value = IDKHO;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable LaySoLuongTonBySP(string IDSP)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT KH.TEN_KHO AS [Kho hàng], TK.SO_LUONG_TON AS [Tồn cuối], TK.SO_LUONG_TON AS [Tồn đầu], SP.TEN_SAN_PHAM AS [Tên sản phẩm], SP.DAI AS [Dài], SP.RONG AS [Rộng], " +
                                                "DSum(\"CHI_TIET_PHIEU_NHAP.SO_LUONG\",\"CHI_TIET_PHIEU_NHAP\",\"ID_SAN_PHAM = '\" & SP.ID & \"' AND ID_KHO = '\" & KH.ID & \"' AND NGAY_NHAP = Date() \") AS [Nhập], " +
                                                "DSum(\"CHI_TIET_PHIEU_BAN.SO_LUONG\",\"CHI_TIET_PHIEU_BAN\",\"ID_SAN_PHAM = '\" & SP.ID & \"' AND ID_KHO = '\" & KH.ID & \"' AND NGAY_BAN = Date() \") AS [Xuất], " +
                                                "SP.GIA_NHAP AS [Đơn giá], SP.LOAI AS [Loại], SP.GIA_NHAP AS [Thành tiền] " +
                                                "FROM(SAN_PHAM  SP INNER JOIN TON_KHO TK ON SP.ID = TK.ID_SAN_PHAM) INNER JOIN KHO_HANG KH ON TK.ID_KHO = KH.ID " +
                                                "WHERE TK.SO_LUONG_TON > 0 " + (IDSP == "0" ? " " : " AND TK.ID_SAN_PHAM = @IDSP ") + "; ");
            if (IDSP != "0") cmd.Parameters.Add("IDSP", OleDbType.VarChar, 50).Value = IDSP;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable LayHangDaNhapByKho(String IDKHO, DateTime fromdate, DateTime toDate)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT SP.TEN_SAN_PHAM AS [Tên sản phẩm], PN.ID_NHA_CUNG_CAP, CTPN.SO_LUONG AS [Số lượng], CTPN.DON_GIA_NHAP AS [Đơn giá], CTPN.THANH_TIEN AS [Thành tiền], CTPN.NGAY_NHAP AS [Ngày nhập] " +
                                                "FROM((CHI_TIET_PHIEU_NHAP CTPN INNER JOIN SAN_PHAM SP ON SP.ID = CTPN.ID_SAN_PHAM) INNER JOIN KHO_HANG KH ON CTPN.ID_KHO = KH.ID) INNER JOIN PHIEU_NHAP PN ON PN.ID = CTPN.ID_PHIEU_NHAP " +
                                                "WHERE CTPN.NGAY_NHAP >= @date1 AND CTPN.NGAY_NHAP <= @date2 " + (IDKHO == "0" ? " " : " AND TK.ID_KHO = @KHO ") + 
                                                "ORDER BY SP.TEN_SAN_PHAM ASC; ");
            if (IDKHO != "0") cmd.Parameters.Add("KHO", OleDbType.VarChar, 50).Value = IDKHO;
            cmd.Parameters.Add("date1", OleDbType.Date).Value = fromdate.Date;
            cmd.Parameters.Add("date2", OleDbType.Date).Value = toDate.Date;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable LayHangDaNhapBySP(string IDSP, DateTime fromdate, DateTime toDate)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT SP.TEN_SAN_PHAM AS [Tên sản phẩm], PN.ID_NHA_CUNG_CAP, CTPN.SO_LUONG AS [Số lượng], CTPN.DON_GIA_NHAP AS [Đơn giá], CTPN.THANH_TIEN AS [Thành tiền], CTPN.NGAY_NHAP AS [Ngày nhập] " +
                 "FROM((CHI_TIET_PHIEU_NHAP CTPN INNER JOIN SAN_PHAM SP ON SP.ID = CTPN.ID_SAN_PHAM) INNER JOIN KHO_HANG KH ON CTPN.ID_KHO = KH.ID) INNER JOIN PHIEU_NHAP PN ON PN.ID = CTPN.ID_PHIEU_NHAP " +
                "WHERE SP.ID=@ID AND CTPN.NGAY_NHAP >= @date1 AND CTPN.NGAY_NHAP <= @date2 " +
                "ORDER BY SP.TEN_SAN_PHAM ASC;");
            cmd.Parameters.Add("ID", OleDbType.Integer).Value = Convert.ToInt32(IDSP);
            cmd.Parameters.Add("date1", OleDbType.Date).Value = fromdate.Date;
            cmd.Parameters.Add("date2", OleDbType.Date).Value = toDate.Date;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        
        public DataTable LayHangDaBanByKho(String IDKHO, DateTime fromdate, DateTime toDate)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT SP.TEN_SAN_PHAM AS [Tên sản phẩm], PB.ID_KHACH_HANG AS [Khách hàng], CTPB.SO_LUONG AS [Số lượng], CTPB.DON_GIA AS [Đơn giá], CTPB.THANH_TIEN AS [Thành tiền], CTPB.NGAY_BAN AS [Ngày bán] " +
                                                "FROM((CHI_TIET_PHIEU_BAN CTPB INNER JOIN SAN_PHAM SP ON SP.ID = CTPB.ID_SAN_PHAM) INNER JOIN KHO_HANG KH ON CTPB.ID_KHO = KH.ID) INNER JOIN PHIEU_BAN PB ON PB.ID = CTPB.ID_PHIEU_BAN " +
                                                "WHERE CTPB.NGAY_BAN >= @date1 AND CTPB.NGAY_BAN <= @date2 " + (IDKHO == "0" ? " " : " AND TK.ID_KHO = @KHO ") +
                                                "ORDER BY SP.TEN_SAN_PHAM ASC; ");
            if (IDKHO != "0") cmd.Parameters.Add("KHO", OleDbType.VarChar, 50).Value = IDKHO;
            cmd.Parameters.Add("date1", OleDbType.Date).Value = fromdate.Date;
            cmd.Parameters.Add("date2", OleDbType.Date).Value = toDate.Date;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable LayHangDaBanBySP(string IDSP, DateTime fromdate, DateTime toDate)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT SP.ID, SP.TEN_SAN_PHAM, MSP.ID AS LO_ID, SP.ID_DON_VI_TINH, Val(MSP.SO_LUONG + MSP.KHUYEN_MAI) AS [Số lượng nhập], MSP.SO_LUONG_TON AS [Số lượng tồn], MSP.NGAY_HET_HAN, SUM(CTPB.SO_LUONG) AS [Số lượng bán], SUM(CTPB.THANH_TIEN) AS [Tổng tiền], SUM(IIF(KH.LOAI_KH=true, CTPB.THANH_TIEN, 0)) AS [Bán sỉ], SUM(IIF(KH.LOAI_KH=false, CTPB.THANH_TIEN, 0)) AS [Bán lẻ] " +
                "FROM ((((SAN_PHAM SP INNER JOIN CHI_TIET_PHIEU_NHAP MSP ON SP.ID = MSP.ID_SAN_PHAM) INNER JOIN CHI_TIET_PHIEU_BAN CTPB ON CTPB.ID_CHI_TIET_PHIEU_NHAP = MSP.ID) INNER JOIN PHIEU_BAN PB ON PB.ID = CTPB.ID_PHIEU_BAN) INNER JOIN KHACH_HANG KH ON KH.ID = PB.ID_KHACH_HANG)" +
                "WHERE SP.ID=@ID AND PB.NGAY_BAN >= @date1 AND PB.NGAY_BAN <= @date2 " +
                "GROUP BY SP.ID, SP.TEN_SAN_PHAM, MSP.ID, SP.ID_DON_VI_TINH, MSP.DON_GIA_NHAP, MSP.NGAY_HET_HAN, MSP.SO_LUONG + MSP.KHUYEN_MAI, MSP.SO_LUONG_TON ORDER BY SP.TEN_SAN_PHAM DESC");
            cmd.Parameters.Add("ID", OleDbType.Integer).Value = Convert.ToInt32(IDSP);
            cmd.Parameters.Add("date1", OleDbType.Date).Value = fromdate.Date;
            cmd.Parameters.Add("date2", OleDbType.Date).Value = toDate.Date;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable LayHangGanHetHan(long songay)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT SP.ID, SP.TEN_SAN_PHAM, MSP.ID AS LO_ID, SP.ID_DON_VI_TINH, Val(MSP.SO_LUONG + MSP.KHUYEN_MAI) AS [Số lượng nhập], SUM((MSP.SO_LUONG * MSP.DON_GIA_NHAP) * (1 - (MSP.CHIET_KHAU / 100))) AS [Tổng tiền nhập], MSP.SO_LUONG_TON AS [Số lượng tồn], MSP.NGAY_HET_HAN, Val(MSP.NGAY_HET_HAN - DATE()) AS [Còn hạn (ngày)], IIF(DSUM(\"CHI_TIET_PHIEU_BAN.SO_LUONG\", \"CHI_TIET_PHIEU_BAN\", \"ID_CHI_TIET_PHIEU_NHAP='\" & MSP.ID & \"'\") > 0, DSUM(\"CHI_TIET_PHIEU_BAN.SO_LUONG\", \"CHI_TIET_PHIEU_BAN\", \"ID_CHI_TIET_PHIEU_NHAP='\" & MSP.ID & \"'\"), 0) AS [Số lượng bán], IIF(DSUM(\"CHI_TIET_PHIEU_BAN.KHUYEN_MAI\", \"CHI_TIET_PHIEU_BAN\", \"ID_CHI_TIET_PHIEU_NHAP='\" & MSP.ID & \"'\") > 0, DSUM(\"CHI_TIET_PHIEU_BAN.KHUYEN_MAI\", \"CHI_TIET_PHIEU_BAN\", \"ID_CHI_TIET_PHIEU_NHAP='\" & MSP.ID & \"'\"), 0) AS [Khuyến mãi], IIF(DSUM(\"CHI_TIET_PHIEU_BAN.THANH_TIEN\", \"CHI_TIET_PHIEU_BAN\", \"ID_CHI_TIET_PHIEU_NHAP='\" & MSP.ID & \"'\") > 0, DSUM(\"CHI_TIET_PHIEU_BAN.THANH_TIEN\", \"CHI_TIET_PHIEU_BAN\", \"ID_CHI_TIET_PHIEU_NHAP='\" & MSP.ID & \"'\"), 0) AS [Tổng tiền bán] " +
                "FROM (SAN_PHAM SP INNER JOIN CHI_TIET_PHIEU_NHAP MSP ON SP.ID = MSP.ID_SAN_PHAM) " +
                "WHERE (((MSP.NGAY_HET_HAN)>= Date())) AND Val(MSP.NGAY_HET_HAN - Date()) =< @songay " +
                "GROUP BY SP.ID, SP.TEN_SAN_PHAM, MSP.ID, SP.ID_DON_VI_TINH, MSP.NGAY_HET_HAN, MSP.SO_LUONG + MSP.KHUYEN_MAI, MSP.SO_LUONG_TON " +
                "ORDER BY MSP.NGAY_HET_HAN ASC");
            cmd.Parameters.Add("songay", OleDbType.Integer).Value = songay;
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable LayHangHetHanByNCC(String NCC)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT SP.ID, SP.TEN_SAN_PHAM, MSP.ID AS LO_ID, SP.ID_DON_VI_TINH, Val(MSP.SO_LUONG + MSP.KHUYEN_MAI) AS [Số lượng nhập], MSP.SO_LUONG_TON AS [Số lượng tồn], MSP.NGAY_HET_HAN " +
                "FROM (SAN_PHAM SP INNER JOIN CHI_TIET_PHIEU_NHAP MSP ON SP.ID = MSP.ID_SAN_PHAM) "+
                "WHERE MSP.NGAY_HET_HAN <= DATE() " + (NCC == "0" ? "" : "AND SP.ID_NHA_CUNG_CAP= \"" + NCC + "\"") + " "+
                "ORDER BY SP.TEN_SAN_PHAM DESC");
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable LayHangHetHanBySP(string IDSP)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT SP.ID, SP.TEN_SAN_PHAM, MSP.ID AS LO_ID, SP.ID_DON_VI_TINH, Val(MSP.SO_LUONG + MSP.KHUYEN_MAI) AS [Số lượng nhập], MSP.SO_LUONG_TON AS [Số lượng tồn], MSP.NGAY_HET_HAN " +
                "FROM (SAN_PHAM SP INNER JOIN CHI_TIET_PHIEU_NHAP MSP ON SP.ID = MSP.ID_SAN_PHAM) " +
                "WHERE MSP.NGAY_HET_HAN <= DATE() AND SP.ID= \"" + IDSP + "\" " +
                "ORDER BY SP.TEN_SAN_PHAM DESC");
            m_Ds.Load(cmd);
            return m_Ds;
        }
        public DataTable DanhsachSanPhamHetHan(DateTime dt, string CompanyID)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT SP.TEN_SAN_PHAM AS [Sản phẩm], MSP.SO_LUONG AS [Số lượng], MSP.NGAY_NHAP AS [Ngày Nhập], MSP.NGAY_SAN_XUAT AS [Ngày sản xuất], MSP.NGAY_HET_HAN AS [Ngày hết hạn] FROM ((SAN_PHAM AS SP INNER JOIN CHI_TIET_PHIEU_NHAP MSP ON SP.ID = MSP.ID_SAN_PHAM) INNER JOIN LOAI_SAN_PHAM LSP ON LSP.ID=SP.ID_LOAI_SAN_PHAM) WHERE LSP.ID_NHA_CUNG_CAP = \"" + CompanyID + "\" AND MSP.NGAY_HET_HAN <= @ngay ORDER BY SP.TEN_SAN_PHAM");
            cmd.Parameters.Add("ngay", OleDbType.Date).Value = DateTime.Now;
            m_Ds.Load(cmd);

            return m_Ds;
        }
        public int ThemSanPham(DataRow row)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO SAN_PHAM VALUES(@ID, @Ten, @Soluong, @DVT, @NCC, @Dai, @Rong, @Li, @Loai, 0)");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = row["ID"].ToString();
            cmd.Parameters.Add("Ten", OleDbType.VarChar, 50).Value = row["TEN_SAN_PHAM"].ToString();
            cmd.Parameters.Add("Soluong", OleDbType.Integer).Value = Convert.ToInt32(row["SO_LUONG"].ToString());
            cmd.Parameters.Add("DVT", OleDbType.Integer).Value = Convert.ToInt32(row["ID_DON_VI_TINH"].ToString());
            cmd.Parameters.Add("NCC", OleDbType.VarChar).Value = row["ID_NHA_CUNG_CAP"].ToString();
            cmd.Parameters.Add("Dai", OleDbType.Integer).Value = Convert.ToInt32(row["DAI"].ToString());
            cmd.Parameters.Add("Rong", OleDbType.Integer).Value = Convert.ToInt32(row["RONG"].ToString());
            cmd.Parameters.Add("Li", OleDbType.Integer).Value = Convert.ToInt32(row["LI"].ToString());
            cmd.Parameters.Add("Loai", OleDbType.VarChar, 50).Value = row["LOAI"].ToString();
            return m_Ds.ExecuteNoneQuery(cmd);
        }
        public void XoaSanPham(String ID)
        {
            OleDbCommand cmd = new OleDbCommand("DELETE FROM SAN_PHAM WHERE ID = @ID");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = ID;
            m_Ds.ExecuteNoneQuery(cmd);
        }
        public decimal SoLuongSanPham(String ID)
        {
            OleDbCommand cmd = new OleDbCommand("SELECT SUM(SO_LUONG) FROM CHI_TIET_PHIEU_NHAP WHERE ID_SAN_PHAM = @ID");
            cmd.Parameters.Add("ID", OleDbType.VarChar, 50).Value = ID;
            return Convert.ToDecimal(m_Ds.ExecuteScalar(cmd));
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
