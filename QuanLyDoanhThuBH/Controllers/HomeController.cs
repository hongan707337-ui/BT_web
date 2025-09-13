using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuanLyDoanhThuBH.Models;

namespace QuanLyDoanhThuBH.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Trang chủ → / hoặc /Home/Index
        public IActionResult Index()
        {
            return View(); // Mặc định sẽ tìm Views/Home/Index.cshtml
        }

        // Trang Privacy → /Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        // Trang Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
