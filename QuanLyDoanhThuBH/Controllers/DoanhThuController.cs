using Microsoft.AspNetCore.Mvc;
using QuanLyDoanhThuBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyDoanhThuBH.Controllers
{
    public class DoanhThuController : Controller
    {
        // GET: /DoanhThu/Index
        public IActionResult Index()
        {
            // Dữ liệu giả lập, sau này sẽ lấy từ database
            var data = new List<DoanhThu>
            {
                new DoanhThu { Id = 1, Thang = 1, Nam = 2025, TongDoanhThu = 1000000 },
                new DoanhThu { Id = 2, Thang = 2, Nam = 2025, TongDoanhThu = 2200000 },
                new DoanhThu { Id = 3, Thang = 3, Nam = 2025, TongDoanhThu = 1400000 }
            };

            return View(data);
        }

        // GET: /DoanhThu/BaoCao
        public IActionResult BaoCao(int? year)
        {
            int nam = year ?? DateTime.Now.Year;

            // Dữ liệu giả lập
            var data = new List<DoanhThu>
            {
                new DoanhThu { Id = 1, Thang = 1, Nam = nam, TongDoanhThu = 5000000 },
                new DoanhThu { Id = 2, Thang = 2, Nam = nam, TongDoanhThu = 7200000 },
                new DoanhThu { Id = 3, Thang = 3, Nam = nam, TongDoanhThu = 4500000 }
            };

            ViewBag.Year = nam;
            ViewBag.Mode = "month"; // demo: tháng, quý, năm

            return View(data);
        }
    }
}
