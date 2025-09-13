using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QuanLyDoanhThuBH.Models
{
    [Table("HoaDon")]
    public class HoaDon
    {
        [Key]
        public int MaHD { get; set; }


        [Required]
        public DateTime NgayTao { get; set; }


        // FK tới SanPham
        [ForeignKey("SanPham")]
        public int MaSP { get; set; }
        public SanPham? SanPham { get; set; }


        // FK tới KhachHang
        [ForeignKey("KhachHang")]
        public int MaKH { get; set; }
        public KhachHang? KhachHang { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal DonGia { get; set; }


        public int SoLuong { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal TongTien { get; set; }
    }
}