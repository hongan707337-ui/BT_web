using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyDoanhThuBH.Data;
using QuanLyDoanhThuBH.Models;


namespace QuanLyDoanhThuBH.Controllers
{
    public class DoanhThuController : Controller
    {
        private readonly QuanLyContext _context;

        public DoanhThuController(QuanLyContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {

            int currentYear = DateTime.Now.Year;

            var data = await _context.HoaDon
                .Where(h => h.NgayTao.Year == currentYear)
                .GroupBy(h => h.NgayTao.Month)
                .Select(g => new
                {
                    Thang = g.Key,
                    TongDoanhThu = g.Sum(x => x.TongTien)
                })
                .OrderBy(x => x.Thang)
                .ToListAsync();

            ViewBag.Year = currentYear;
            ViewBag.ChartLabels = data.Select(d => "Tháng " + d.Thang).ToArray();
            ViewBag.ChartData = data.Select(d => d.TongDoanhThu).ToArray();

            return View();
        }


        public async Task<IActionResult> BaoCao(int? year, int? month)
        {
            var availableYears = await _context.HoaDon
                .Select(h => h.NgayTao.Year)
                .Distinct()
                .OrderBy(y => y)
                .ToListAsync();

            ViewBag.AvailableYears = availableYears;
            ViewBag.AvailableMonths = Enumerable.Range(1, 12).ToList();
            ViewBag.SelectedYear = year;
            ViewBag.SelectedMonth = month;

            int nam = year ?? DateTime.Now.Year;

            var query = _context.HoaDon.AsQueryable();
            query = query.Where(h => h.NgayTao.Year == nam);

            if (month.HasValue)
            {
                query = query.Where(h => h.NgayTao.Month == month.Value);
            }

            var data = await query
                .GroupBy(h => new { h.NgayTao.Year, h.NgayTao.Month })
                .Select(g => new DoanhThu
                {
                    Nam = g.Key.Year,
                    Thang = g.Key.Month,
                    TongDoanhThu = g.Sum(x => x.TongTien)
                })
                .OrderBy(d => d.Thang)
                .ToListAsync();

            return View(data);
        }


       
    }
}

