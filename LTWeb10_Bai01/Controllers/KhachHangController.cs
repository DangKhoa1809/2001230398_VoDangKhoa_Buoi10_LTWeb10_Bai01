using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb10_Bai01.Models;

namespace LTWeb10_Bai01.Controllers
{
    public class KhachHangController : Controller
    {
        QL_SachEntities data = new QL_SachEntities();

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(string TaiKhoan, string MatKhau)
        {
            var kh = data.tblKhachHangs.FirstOrDefault(k => k.TaiKhoan == TaiKhoan && k.MatKhau == MatKhau);

            if (kh != null)
            {
                Session["KhachHang"] = kh;
                Session["TenKhachHang"] = kh.TenKhachHang;
                Session["MaKhachHang"] = kh.MaKhachHang;

                if (Session["ReturnUrl"] != null)
                {
                    string returnUrl = Session["ReturnUrl"].ToString();
                    Session["ReturnUrl"] = null;
                    return Redirect(returnUrl);
                }

                return RedirectToAction("TrangChu", "Sach");
            }
            else
            {
                ViewBag.ThongBao = "Tài khoản hoặc mật khẩu không đúng!";
                return View();
            }
        }
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("DangNhap");
        }
    }
}