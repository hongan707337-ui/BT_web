using Microsoft.AspNetCore.Mvc;
using QuanLyDoanhThuBH.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyDoanhThuBH.Controllers
{
    public class SanPhamController : Controller
    {
        // Dữ liệu giả
        private static List<SanPham> _listSanPham = new List<SanPham>
        {
            new SanPham { MaSP = 1, TenSP = "Thức ăn cho chó", DonGia = 100000, SoLuongTon = 10 },
            new SanPham { MaSP = 2, TenSP = "Ổ chó", DonGia = 200000, SoLuongTon = 5 },
            new SanPham { MaSP = 3, TenSP = "Cục xương", DonGia = 150000, SoLuongTon = 8 }
        };

        // GET: /SanPham/Index
        public IActionResult Index()
        {
            // Trả về view với list sản phẩm
            return View(_listSanPham);
        }

        // GET: /SanPham/Details/5
        public IActionResult Details(int id)
        {
            var sp = _listSanPham.FirstOrDefault(x => x.MaSP == id);
            if (sp == null)
            {
                return NotFound(); // Không tìm thấy
            }
            return View(sp);
        }

        // GET: /SanPham/Edit/5
        public IActionResult Edit(int id)
        {
            var sp = _listSanPham.FirstOrDefault(x => x.MaSP == id);
            if (sp == null) return NotFound();
            return View(sp);
        }

        // POST: /SanPham/Edit/5
        [HttpPost]
        public IActionResult Edit(SanPham model)
        {
            var sp = _listSanPham.FirstOrDefault(x => x.MaSP == model.MaSP);
            if (sp != null)
            {
                sp.TenSP = model.TenSP;
                sp.DonGia = model.DonGia;
                sp.SoLuongTon = model.SoLuongTon;
            }
            return RedirectToAction("Index");
        }

        // GET: /SanPham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /SanPham/Create
        [HttpPost]
        public IActionResult Create(SanPham model)
        {
            int newId = _listSanPham.Max(x => x.MaSP) + 1;
            model.MaSP = newId;
            _listSanPham.Add(model);
            return RedirectToAction("Index");
        }

        // GET: /SanPham/Delete/5
        public IActionResult Delete(int id)
        {
            var sp = _listSanPham.FirstOrDefault(x => x.MaSP == id);
            if (sp != null)
            {
                _listSanPham.Remove(sp);
            }
            return RedirectToAction("Index");
        }
    }
}
