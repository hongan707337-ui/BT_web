using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QuanLyDoanhThuBH.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public int MaSP { get; set; }
        [Required]
        [StringLength(100)]
        public string TenSP { get; set; } = null!;
        [Column(TypeName = "decimal(18,2)")]
        public decimal DonGia { get; set; }
        public int SoLuongTon { get; set; }
        public ICollection<HoaDon> HoaDon { get; set; } = new List<HoaDon>();
    }
}