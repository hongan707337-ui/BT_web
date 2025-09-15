using Microsoft.AspNetCore.Mvc;

namespace QuanLyDoanhThuBH.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
            {
                return View();
            }
        public IActionResult TrangChu()
        {
            return View();
        }
        

    }
}
