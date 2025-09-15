
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
        [Required]
        public int MaSP { get; set; }
        
        public SanPham? SanPham { get; set; }


        // FK tới KhachHang
        [ForeignKey("KhachHang")]
        [Required]
        public int MaKH { get; set; }
      
        public KhachHang? KhachHang { get; set; }


        [Required]

        public int DonGia { get; set; }


        [Required]
        public int SoLuong { get; set; }

        [Required]
        public int TongTien { get; set; }

    }
}