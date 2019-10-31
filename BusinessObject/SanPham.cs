using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyKho.BusinessObject
{
    public class SanPham
    {
        public SanPham() { }
        public SanPham(String id, String tensp)
        {
            m_Id = id;
            m_FullTenSP = tensp;
        }
        private String m_Id;

        public String Id
        {
            get { return m_Id; }
            set { m_Id = value; }
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
        private decimal m_DonGiaNhap;

        public decimal DonGiaNhap
        {
            get { return m_DonGiaNhap; }
            set { m_DonGiaNhap = value; }
        }
        private DonViTinh m_DonViTinh;

        public DonViTinh DonViTinh
        {
            get { return m_DonViTinh; }
            set { m_DonViTinh = value; }
        }
        private NhaCungCap m_NCC;
        public NhaCungCap NhaCungCap
        {
            get { return m_NCC; }
            set { m_NCC = value; }
        }
        private String m_FullTenSP;

        public String FullTenSanPham
        {
            get { return m_FullTenSP; }
            set { m_FullTenSP = value; }
        }
        private long m_Dai;
        public long Dai
        {
            get { return m_Dai; }
            set { m_Dai = value; }
        }
        private long m_Rong;
        public long Rong
        {
            get { return m_Rong; }
            set { m_Rong = value; }
        }
        private int m_Li;
        public int Li
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
    }
}
