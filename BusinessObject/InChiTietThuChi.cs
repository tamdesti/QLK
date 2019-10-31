using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.BusinessObject
{
    class InChiTietThuChi
    {
        private int m_STT;
        public int STT
        {
            get { return m_STT; }
            set { m_STT = value; }
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
        private DateTime m_NgayLapPhieu;

        public DateTime NgayLapPhieu
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
        private String m_GhiChu;
        public String GhiChu
        {
            get { return m_GhiChu; }
            set { m_GhiChu = value; }
        }
        private double m_ThanhTien;
        public double ThanhTien
        {
            get { return m_ThanhTien; }
            set { m_ThanhTien = value; }
        }
    }
}
