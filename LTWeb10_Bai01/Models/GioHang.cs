using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWeb10_Bai01.Models
{
	public class GioHang
	{
        public List<CartItem> lst { get; set; }

        public GioHang()
        {
            lst = new List<CartItem>();
        }

        public GioHang(List<CartItem> lstGH)
        {
            lst = lstGH;
        }
        public int SoMatHang()
        {
            return lst.Count;
        }

        public int TongSLHang()
        {
            return lst.Sum(n => n.iSoLuong);
        }

        public decimal TongThanhTien()
        {
            return lst.Sum(n => n.ThanhTien);
        }

        public int Them(int maSach)
        {
            CartItem sanpham = lst.Find(n => n.iMaSach == maSach);
            if (sanpham == null)
            {
                CartItem sach = new CartItem(maSach);
                lst.Add(sach);
                return 1;
            }
            else
            {
                sanpham.iSoLuong++;
                return 1;
            }
        }
    }
}