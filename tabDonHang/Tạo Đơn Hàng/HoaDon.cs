using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang
{
    class HoaDon
    {
        public int STT { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string TenSanPham { get; set; }
        public string MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public long GiaBan { get; set; }
        public int ChietKhau { get; set; }
       
        public long ThanhTien { get; set; }
        public string NgayMua { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public string ChietKhauHien { get; set; }

        public string MaDH { get; set; }
        public string ThanhTien_HD { get; set; }



        public void NhapHoaDon1(string madonhang, string tenKhachHang, string soDienThoai, string diaChi, string thanhtien_hoadon, DateTime thoigian , string phuongThucThanhToan, MangKhachHang mangKhachHang)
        {
            int i, count = 0; ;
            for (i = 0; i < mangKhachHang.spt; i++)
            {
                if (soDienThoai == mangKhachHang.khachHang[i].SoDienThoai)
                {
                    if (mangKhachHang.khachHang[i].PhanLoaiKH == "Gold")
                    {
                        ChietKhau = 30;
                    }
                    else if (mangKhachHang.khachHang[i].PhanLoaiKH == "Silver")
                    {
                        ChietKhau = 20;
                    }
                    else
                    {
                        ChietKhau = 0;
                    }
                    count++;
                    break;
                }
            }
            if (count == 0)
                ChietKhau = 0;

            MaDH = madonhang;
            TenKhachHang = tenKhachHang;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
            ThanhTien_HD = thanhtien_hoadon;
            ThanhTien = SoLuong * GiaBan * (100 - ChietKhau) / 100;
            NgayMua = thoigian.ToShortDateString();
            PhuongThucThanhToan = phuongThucThanhToan;
            ChietKhauHien = ChietKhau + "%";
        }

        public void SPTrongHD(string tensp, string masp, int sl, long giaban)
        {
            TenSanPham = tensp;
            SoLuong = sl;
            MaSanPham = masp;
            GiaBan = giaban;
        }

        public string randomMaHoaDon()
        {
            string tam;
            Random rd = new Random();
            tam = Convert.ToString((char)(rd).Next(65, 90)) + Convert.ToString((char)(rd).Next(65, 90)) + Convert.ToString((char)(rd).Next(65, 90)) + rd.Next(1000, 9999).ToString();
            return tam;
        }
    }
}
