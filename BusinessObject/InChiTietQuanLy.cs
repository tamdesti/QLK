using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.BusinessObject
{
    class InChiTietQuanLy
    {
        private int m_STT;
        public int STT
        {
            get { return m_STT; }
            set { m_STT = value; }
        }
        private String m_TenSP;

        public String TenSanPham
        {
            get { return m_TenSP; }
            set { m_TenSP = value; }
        }
        private String m_Ten_DVT;

        public String TenDonViTinh
        {
            get { return m_Ten_DVT; }
            set { m_Ten_DVT = value; }
        }
        private double m_DonGiaNhap;

        public double DonGiaNhap
        {
            get { return m_DonGiaNhap; }
            set { m_DonGiaNhap = value; }
        }
        private double m_GiaBanSi;

        private int m_SoLuongBan;

        public int SoLuongBan
        {
            get { return m_SoLuongBan; }
            set { m_SoLuongBan = value; }
        }
        private int m_SoLuongNhap;

        public int SoLuongNhap
        {
            get { return m_SoLuongNhap; }
            set { m_SoLuongNhap = value; }
        }
        
        private int m_SoLuongTon;

        public int SoLuongTon
        {
            get { return m_SoLuongTon; }
            set { m_SoLuongTon = value; }
        }
        private double m_TongTien;

        public double TongTien
        {
            get { return m_TongTien; }
            set { m_TongTien = value; }
        }
        private double m_TongBanSi;

        public double TongBanSi
        {
            get { return m_TongBanSi; }
            set { m_TongBanSi = value; }
        }
        private double m_TongBanLe;

        public double TongBanLe
        {
            get { return m_TongBanLe; }
            set { m_TongBanLe = value; }
        }
        private double m_TongTienNhap;

        public double TongTienNhap
        {
            get { return m_TongTienNhap; }
            set { m_TongTienNhap = value; }
        }
        private double m_TongTienBan;

        public double TongTienBan
        {
            get { return m_TongTienBan; }
            set { m_TongTienBan = value; }
        }
        private string m_NCC;
        public string NhaCungCap
        {
            get { return m_NCC; }
            set { m_NCC = value; }
        }
        private string m_NhomSanPham;
        public string NhomSanPham
        {
            get { return m_NhomSanPham; }
            set { m_NhomSanPham = value; }
        }
        private string m_SanPham;
        public string SanPham
        {
            get { return m_SanPham; }
            set { m_SanPham = value; }
        }
        private DateTime m_fromDate;
        public DateTime fromDate
        {
            get { return m_fromDate; }
            set { m_fromDate = value; }
        }
        private DateTime m_toDate;
        public DateTime toDate
        {
            get { return m_toDate; }
            set { m_toDate = value; }
        }
        private double m_Dai;
        public double Dai
        {
            get { return m_Dai; }
            set { m_Dai = value; }
        }
        private double m_Rong;
        public double Rong
        {
            get { return m_Rong; }
            set { m_Rong = value; }
        }
        private double m_Li;
        public double Li
        {
            get { return m_Li; }
            set { m_Li = value; }
        }
        private string m_Loai;
        public string Loai
        {
            get { return m_Loai; }
            set { m_Loai = value; }
        }
        private double m_TonCuoi;
        public double TonCuoi
        {
            get { return m_TonCuoi; }
            set { m_TonCuoi = value; }
        }
        private double m_TonDau;
        public double TonDau
        {
            get { return m_TonDau; }
            set { m_TonDau = value; }
        }
        private double m_Nhap;
        public double Nhap
        {
            get { return m_Nhap; }
            set { m_Nhap = value; }
        }
        private double m_Xuat;
        public double Xuat
        {
            get { return m_Xuat; }
            set { m_Xuat = value; }
        }
        private double m_ThanhTien;
        public double ThanhTien
        {
            get { return m_ThanhTien; }
            set { m_ThanhTien = value; }
        }
        private string m_GhiChu;
        public string GhiChu
        {
            get { return m_GhiChu; }
            set { m_GhiChu = value; }
        }
        private String m_NgayLapPhieu;

        public String NgayLapPhieu
        {
            get { return m_NgayLapPhieu; }
            set { m_NgayLapPhieu = value; }
        }
    }
}
