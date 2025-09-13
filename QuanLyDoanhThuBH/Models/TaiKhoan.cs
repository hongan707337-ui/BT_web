using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QuanLyDoanhThuBH.Models
{
    [Table("TaiKhoan")]
    public class TaiKhoan
    {
        [Key]
        public int UserID { get; set; }


        [Required]
        [StringLength(100)]
        public string? TenDN { get; set; }


        [Required]
        [StringLength(200)]
        public string? MatKhau { get; set; }
    }
}