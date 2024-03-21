using System;
using System.Collections.Generic;

namespace QuanLyKho.Models
{
    public partial class ChiTietDonDatHang
    {
        public int MaChiTiet { get; set; }
        public int? MaDonHang { get; set; }
        public int? MaSanPham { get; set; }
        public int? SoLuong { get; set; }
        public decimal? GiaTien { get; set; }

        public virtual DonDatHang? MaDonHangNavigation { get; set; }
        public virtual SanPham? MaSanPhamNavigation { get; set; }
    }
}
