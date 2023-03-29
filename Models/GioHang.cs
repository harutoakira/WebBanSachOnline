using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanSachOnline.Models
{
    public class GioHang
    {
        MVCBanSachOnlineEntities db = new MVCBanSachOnlineEntities();
        public int iMaSach { get; set; }
        public string sTenSach { get; set; }
        public string sHinhAnh { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien { get { return iSoLuong * dDonGia; } }


        public GioHang(int MaSach)
        {
            this.iMaSach = MaSach;
            Sach sach = db.Sach.Single(n => n.MaSach == MaSach);
            sTenSach = sach.TenSach;
            sHinhAnh = sach.AnhBia;
            dDonGia = double.Parse(sach.GiaBan.ToString());
            iSoLuong = 1;
        }

    }
    
}