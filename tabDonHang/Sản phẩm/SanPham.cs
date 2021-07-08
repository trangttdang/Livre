using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace tabDonHang.Sản_phẩm
{
    class SanPham
    {
        public string TenSanPham { get; set; }
        public string MaSanPham { get; set; }
        public long SoLuongTon { get; set; }
        public long SoLuongBan { get; set; }
        public long SoLuongNhap { get; set; }
        public long GiaGoc { get; set; }
        public long GiaBan { get; set; }
        public string TenNCC { get; set; }
        public int STT { get; set; }

        //tab Nhap Hang
        public long SLNhap { get; set; }
        public long ThanhTien { get; set; }
        //tab đơn hàng
        public long SLBan { get; set; }
        public long ThanhTien_Ban { get; set; }
        public string Hinh { get; set; }



        public void NhapSanPham(string tenSanPham, string maSanPham, string giaGoc, string giaBan, string tenncc, string hinhanh)
        {
            TenSanPham = tenSanPham;
            MaSanPham = maSanPham;
            SoLuongBan = 0;
            SoLuongNhap = 0;
            SoLuongTon = 0;
            GiaBan = long.Parse(giaBan);
            GiaGoc = long.Parse(giaGoc);
            TenNCC = tenncc ;
            Hinh = hinhanh;
        }
        public bool kiemtrasp(string a)
        {
            if (a == TenNCC)
                return true;
            else
                return false;
        }
        

    }
}
