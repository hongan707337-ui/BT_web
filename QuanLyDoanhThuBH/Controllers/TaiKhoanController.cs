using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using QuanLyDoanhThuBH.Data;
using QuanLyDoanhThuBH.Models;
using Microsoft.AspNetCore.Identity;

namespace QuanLyDoanhThuBH.Controllers
{
    public class TaiKhoanController : Controller
    {
        private readonly QuanLyContext _context;

        public TaiKhoanController(QuanLyContext context)
        {
            _context = context;
        }

        // GET: TaiKhoan/DangKy
        public IActionResult DangKy()
        {
            return View();
        }

        // POST: TaiKhoan/DangKy
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DangKy([Bind("TenDN,MatKhau")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taiKhoan);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Đăng ký thành công! Bạn có thể đăng nhập bây giờ.";
                return RedirectToAction("DangNhap","TaiKhoan"); // Chuyển hướng đến trang đăng nhập sau khi đăng ký thành công
            }
            return View(taiKhoan);
        }
        // GET: TaiKhoan/DangNhap
        public IActionResult DangNhap()
        {
            return View();
        }

        // POST: TaiKhoan/DangNhap
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DangNhap(string TenDN, string MatKhau)
        {
            // 1. Tìm tài khoản trong cơ sở dữ liệu
            var taiKhoan = await _context.TaiKhoan.FirstOrDefaultAsync(tk => tk.TenDN == TenDN && tk.MatKhau == MatKhau);

            // 2. Kiểm tra tài khoản có tồn tại không
            if (taiKhoan == null)
            {
                // Trả về thông báo lỗi nếu không tìm thấy
                ViewData["ErrorMessage"] = "Tên đăng nhập hoặc mật khẩu không đúng.";
                return View();
            }

            // 4. Chuyển hướng đến trang chính
            return RedirectToAction("TrangChu", "Home");
        }

        // GET: TaiKhoan/DangXuat
        [HttpPost]
        public IActionResult DangXuat()
        {
            // 2. Chuyển hướng người dùng về trang chủ sau khi đã đăng xuất
            return RedirectToAction("Index", "Home");
        }

    }
}

