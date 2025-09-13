using Microsoft.AspNetCore.Mvc;
using QuanLyDoanhThuBH.Models;
using System.Collections.Generic;

namespace QuanLyDoanhThuBH.Controllers
{
    public class KhachHangController : Controller
    {
        public IActionResult Index()
        {
            // Dữ liệu giả trong Controller
            var khachHangs = new List<KhachHang>
            {
                new KhachHang { MaKH = 1, TenKH = "Chó lài sông Mã", Email = "ahahaha@gmail.com", SoDienThoai = "09112232321" },
                new KhachHang { MaKH = 2, TenKH = "Hmông Cộc đuôi", Email = "leuleuleu@gmail.com", SoDienThoai = "0987654321" }
            };

            return View(khachHangs);
        }
    }
}
