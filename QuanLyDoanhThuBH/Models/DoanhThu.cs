using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QuanLyDoanhThuBH.Models
{
    [Table("DoanhThu")]
    public class DoanhThu
    {
        [Key]
        public int Id { get; set; }


        [Range(1, 12)]
        public int Thang { get; set; }


        public int Nam { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal TongDoanhThu { get; set; }
    }
}