using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang.Nhà_Cung_Cấp.Thông_tin_chi_tiết
{
    public class LichSuNhapHang
    {
        public string MaDonNhap { get; set; }
        public string TongGiaTri { get; set; }
        public string NgayTaoDonNhap { get; set; }

        public void CapNhatLichSu(string madon, string tongtien, DateTime thoigian)
        {
            MaDonNhap = madon;
            TongGiaTri = tongtien;
            NgayTaoDonNhap = thoigian.ToString();
        }
    }
}
