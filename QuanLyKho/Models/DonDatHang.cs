using System;
using System.Collections.Generic;

namespace QuanLyKho.Models
{
    public partial class DonDatHang
    {
        public DonDatHang()
        {
            ChiTietDonDatHangs = new HashSet<ChiTietDonDatHang>();
        }

        public int MaDonHang { get; set; }
        public DateTime? NgayDat { get; set; }
        public decimal? TongTien { get; set; }

        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }
    }
}
