using Microsoft.AspNetCore.Mvc;
using QuanLyDoanhThuBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyDoanhThuBH.Controllers
{
    public class HoaDonController : Controller
    {
        // Dữ liệu giả lập để test view (không cần DB)
        private static List<SanPham> sanPhams = new List<SanPham>
        {
            new SanPham { MaSP = 1, TenSP = "Thức ăn cho chó", DonGia = 200000, SoLuongTon = 10 },
            new SanPham { MaSP = 2, TenSP = "Ổ chó", DonGia = 400000, SoLuongTon = 5 }
        };

        private static List<KhachHang> khachHangs = new List<KhachHang>
        {
            new KhachHang { MaKH = 1, TenKH = "Chó lài sông Mã", SoDienThoai = "0901234567" },
            new KhachHang { MaKH = 2, TenKH = "Hmông Cộc đuôi", SoDienThoai = "0912345678" }
        };

        private static List<HoaDon> hoaDons = new List<HoaDon>
        {
            new HoaDon { MaHD = 1, NgayTao = DateTime.Now.AddDays(-2), MaSP = 1, MaKH = 1, DonGia = 200000, SoLuong = 2, TongTien = 400000 },
            new HoaDon { MaHD = 2, NgayTao = DateTime.Now.AddDays(-1), MaSP = 2, MaKH = 2, DonGia = 400000, SoLuong = 1, TongTien = 400000 }
        };

        // GET: HoaDon/Index
        public IActionResult Index()
        {
            foreach (var hd in hoaDons)
            {
                hd.SanPham = sanPhams.FirstOrDefault(sp => sp.MaSP == hd.MaSP);
                hd.KhachHang = khachHangs.FirstOrDefault(kh => kh.MaKH == hd.MaKH);
            }
            return View(hoaDons);
        }
    }
}
