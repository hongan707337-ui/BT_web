using Microsoft.AspNetCore.Mvc;

namespace QuanLyDoanhThuBH.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // TODO: kiểm tra thông tin đăng nhập
            // Đây là dữ liệu giả để test view
            if (username == "admin" && password == "123")
            {
                // Redirect về trang chủ nếu đăng nhập đúng
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Tên đăng nhập hoặc mật khẩu sai!";
            return View();
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public IActionResult Register(string username, string password, string email)
        {
            // TODO: lưu thông tin user mới (dữ liệu giả)
            ViewBag.Message = $"Đăng ký thành công cho user: {username}";
            return View();
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            // TODO: xóa session hoặc cookie
            return RedirectToAction("Index", "Home");
        }
    }
}
