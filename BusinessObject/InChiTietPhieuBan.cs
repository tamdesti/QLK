using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.BusinessObject
{
    public class InChiTietPhieuBan
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
        private int m_SoLuong;

        public int SoLuong
        {
            get { return m_SoLuong; }
            set { m_SoLuong = value; }
        }
        
        private String m_Ten_DVT;

        public String TenDonViTinh
        {
            get { return m_Ten_DVT; }
            set { m_Ten_DVT = value; }
        }
        private double m_DonGia;

        public double DonGia
        {
            get { return m_DonGia; }
            set { m_DonGia = value; }
        }
        
        private String m_HoTen;

        public String HoTen
        {
            get { return m_HoTen; }
            set { m_HoTen = value; }
        }
        private String m_DiaChi;

        public String DiaChi
        {
            get { return m_DiaChi; }
            set { m_DiaChi = value; }
        }
        private String m_DienThoai;

        public String DienThoai
        {
            get { return m_DienThoai; }
            set { m_DienThoai = value; }
        }
        private String m_TenDaiLy;
        public string TenDaiLy
        {
            get { return m_TenDaiLy; }
            set { m_TenDaiLy = value; }
        }
        private double m_NoCu;

        public double NoCu
        {
            get { return m_NoCu; }
            set { m_NoCu = value; }
        }
        private double m_TongTien;

        public double TongTien
        {
            get { return m_TongTien; }
            set { m_TongTien = value; }
        }
        private double m_DaTra;

        public double DaTra
        {
            get { return m_DaTra; }
            set { m_DaTra = value; }
        }
        private double m_ConNo;

        public double ConNo
        {
            get { return m_ConNo; }
            set { m_ConNo = value; }
        }
        private String m_NgayLapPhieu;

        public String NgayLapPhieu
        {
            get { return m_NgayLapPhieu; }
            set { m_NgayLapPhieu = value; }
        }

        private String m_ID;

        public String IDPhieuBan
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
        private double m_thanhtien;

        public double ThanhTien
        {
            get { return m_thanhtien; }
            set { m_thanhtien = value; }
        }
        private double m_khoiluong;

        public double KhoiLuong
        {
            get { return m_khoiluong; }
            set { m_khoiluong = value; }
        }
        private double m_TongSoLuong;
        public double TongSoLuong
        {
            get { return m_TongSoLuong; }
            set { m_TongSoLuong = value; }
        }
        private string m_TienBangChu;
        public string TienBangChu
        {
            get { return m_TienBangChu; }
            set { m_TienBangChu = value; }
        }
    }
}
