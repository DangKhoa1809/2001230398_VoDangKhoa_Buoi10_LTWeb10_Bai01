using LTWeb10_Bai01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb10_Bai01.Controllers
{
    public class DatHangController : Controller
    {
        QL_SachEntities data = new QL_SachEntities();

        public ActionResult ThemMatHang(int msp)
        {
            GioHang gh = Session["GioHang"] as GioHang;
            if (gh == null)
            {
                gh = new GioHang();
                Session["GioHang"] = gh;
            }

            gh.Them(msp);
            return RedirectToAction("XemGioHang");
        }

        public ActionResult XemGioHang()
        {
            GioHang gh = Session["GioHang"] as GioHang;
            if (gh == null || gh.lst.Count == 0)
            {
                ViewBag.ThongBao = "Giỏ hàng của bạn đang trống.";
                return View(new GioHang());
            }

            return View(gh);
        }

        public ActionResult DatHang()
        {
            var kh = Session["KhachHang"] as tblKhachHang;
            if (kh == null)
            {
                Session["ReturnUrl"] = Url.Action("DatHang", "DatHang");
                return RedirectToAction("DangNhap", "KhachHang");
            }

            var gio = Session["GioHang"] as GioHang;
            if (gio == null || gio.lst.Count == 0)
            {
                ViewBag.ThongBao = "Giỏ hàng của bạn đang trống.";
                return View("XemGioHang", new GioHang());
            }

            ViewBag.KhachHang = kh;
            return RedirectToAction("TaoDonDatHang");
        }

        [HttpGet]
        public ActionResult TaoDonDatHang()
        {
            var kh = Session["KhachHang"] as tblKhachHang;
            if (kh == null)
                return RedirectToAction("DangNhap", "KhachHang");

            ViewBag.KhachHang = kh;
            return View();
        }

        [HttpPost]
        public ActionResult TaoDonDatHang(DateTime txtDate)
        {
            var kh = Session["KhachHang"] as tblKhachHang;
            if (kh == null)
                return RedirectToAction("DangNhap", "KhachHang");

            var gio = Session["GioHang"] as GioHang;
            if (gio == null || gio.lst.Count == 0)
                return RedirectToAction("XemGioHang");

            tblHoaDon hd = new tblHoaDon
            {
                NgayHoaDon = DateTime.Now,
                NgayGiao = txtDate,
                MaKhachHang = kh.MaKhachHang
            };

            data.tblHoaDons.Add(hd);
            data.SaveChanges();

            foreach (var item in gio.lst)
            {
                tblChiTiet ct = new tblChiTiet
                {
                    MaHoaDon = hd.MaHoaDon,
                    MaSanPham = item.iMaSach,
                    SoLuong = item.iSoLuong
                };
                data.tblChiTiets.Add(ct);

                var sp = data.tblSanPhams.FirstOrDefault(s => s.MaSanPham == item.iMaSach);
                if (sp != null)
                {
                    sp.SoLuongTon -= item.iSoLuong;
                }
            }

            data.SaveChanges();

            Session["GioHang"] = null;

            ViewBag.ThongBao = "Đơn hàng của quý khách đã được ghi nhận. " + "Chúng tôi sẽ liên hệ quý khách trong thời gian sớm nhất và giao hàng đúng hẹn.";

            return View("ThongBao");
        }
    }
}