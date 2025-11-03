using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWeb10_Bai01.Models
{
	public class CartItem
	{
		public int iMaSach { get; set; }
		public string sTenSach { get; set; }
		public string sAnhBia { get; set; }
		public decimal dDonGia { get; set; }
		public int iSoLuong { get; set; }
		public decimal ThanhTien 
		{ 
			get { return iSoLuong * dDonGia; }
		}

        QL_SachEntities data = new QL_SachEntities();

		public CartItem (int maSach)
		{
            tblSanPham sp = data.tblSanPhams.Find(maSach);
            if (sp != null)
            {
                iMaSach = sp.MaSanPham;
                sTenSach = sp.TenSanPham;
                sAnhBia = sp.HinhAnh;
                dDonGia = sp.DonGia ?? 0; 
                iSoLuong = 1;
            }
        }
    }
}