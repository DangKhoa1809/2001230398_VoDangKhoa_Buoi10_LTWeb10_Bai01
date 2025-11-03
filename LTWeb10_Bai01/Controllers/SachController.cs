using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb10_Bai01.Models;

namespace LTWeb10_Bai01.Controllers
{
    public class SachController : Controller
    {
        // GET: Sach
        QL_SachEntities data = new QL_SachEntities();

        public ActionResult TrangChu()
        {
            var kh = Session["KhachHang"] as tblKhachHang;
            if (kh != null)
            {
                return View(kh);
            }

            return RedirectToAction("DangNhap", "KhachHang");
        }

        public ActionResult HienThiSanPham()
        {
            var dsSach = data.tblSanPhams.ToList();
            return View(dsSach);
        }

    }
}