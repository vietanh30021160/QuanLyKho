using System;
using System.Collections.Generic;

namespace QuanLyKho.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            ChiTietDonDatHangs = new HashSet<ChiTietDonDatHang>();
        }

        public int MaSanPham { get; set; }
        public string? TenSanPham { get; set; }
        public int? MaDanhMuc { get; set; }
        public int? MaNhaCungCap { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }

        public virtual DanhMuc? MaDanhMucNavigation { get; set; }
        public virtual NhaCungCap? MaNhaCungCapNavigation { get; set; }
        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }
    }
}
