using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyDoanhThuBH.Data;
using QuanLyDoanhThuBH.Models;
using System.Threading.Tasks;


namespace QuanLyDoanhThuBH.Controllers
{
   
    public class HoaDonController : Controller
    {
        private readonly QuanLyContext _context;

        public HoaDonController(QuanLyContext context)
        {
            _context = context;
        }
       
        // GET: HoaDon
        public async Task<IActionResult> Index()
        {
            var hoaDon = await _context.HoaDon
                .Include(h => h.SanPham)
                .Include(h => h.KhachHang)
                .ToListAsync();
            return View(hoaDon);
        }



        // GET: HoaDons/Create
        public IActionResult Create()
        {
            ViewData["MaKH"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.KhachHang, "MaKH", "TenKH");
            ViewData["MaSP"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.SanPham, "MaSP", "TenSP");
            return View();
        }

        // POST: HoaDons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHD,MaSP,MaKH,DonGia,SoLuong,TongTien")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                hoaDon.NgayTao = DateTime.Now;
                hoaDon.TongTien = hoaDon.SoLuong * hoaDon.DonGia;
                _context.Add(hoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["MaKH"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.KhachHang, "MaKH", "TenKH", hoaDon.MaKH);
            ViewData["MaSP"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.SanPham, "MaSP", "TenSP", hoaDon.MaSP);
            return View(hoaDon);
        }

        // GET: HoaDons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var hoaDon = await _context.HoaDon.FindAsync(id);
            if (hoaDon == null) return NotFound();


            ViewBag.KhachHangList = new SelectList(_context.KhachHang, "MaKH", "TenKH", hoaDon.MaKH);
            ViewBag.SanPhamList = new SelectList(_context.SanPham, "MaSP", "TenSP", hoaDon.MaSP);

            return View(hoaDon);
        }

        // POST: HoaDons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHD,MaSP,MaKH,DonGia,SoLuong,TongTien")] HoaDon hoaDon)
        {
            if (id != hoaDon.MaHD) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var existingHoaDon = await _context.HoaDon.AsNoTracking().FirstOrDefaultAsync(h => h.MaHD == id);
                    if (existingHoaDon == null) return NotFound();


                    hoaDon.NgayTao = existingHoaDon.NgayTao;
                    hoaDon.TongTien = hoaDon.SoLuong * hoaDon.DonGia;

                    _context.Update(hoaDon);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.HoaDon.Any(e => e.MaHD == hoaDon.MaHD))
                        return NotFound();
                    else
                        throw;
                }
            }

            ViewBag.KhachHangList = new SelectList(_context.KhachHang, "MaKH", "TenKH", hoaDon.MaKH);
            ViewBag.SanPhamList = new SelectList(_context.SanPham, "MaSP", "TenSP", hoaDon.MaSP);
            return View(hoaDon);
        }

        // GET: HoaDons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var hoaDon = await _context.HoaDon
                .Include(h => h.SanPham)
                .Include(h => h.KhachHang)
                .FirstOrDefaultAsync(m => m.MaHD == id);

            if (hoaDon == null) return NotFound();

            return View(hoaDon);
        }

        //GET: HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoaDon = await _context.HoaDon.FindAsync(id);
            if (hoaDon != null)
            {
                _context.HoaDon.Remove(hoaDon);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}