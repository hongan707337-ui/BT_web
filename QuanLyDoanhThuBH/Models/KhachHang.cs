using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QuanLyDoanhThuBH.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        public int MaKH { get; set; }


        [Required]
        [StringLength(100)]
        public string? TenKH { get; set; }


        [StringLength(200)]
        public string? DiaChi { get; set; }


        [StringLength(15)]
        public string? SoDienThoai { get; set; }


        [StringLength(100)]
        public string? Email { get; set; }

        public ICollection<HoaDon> HoaDon { get; set; } = new List<HoaDon>();
    }
}