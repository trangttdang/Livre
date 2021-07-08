using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang
{
    class KhachHang
    {
        public int STT { get; set; }
        public string TenKhachHang { get; set; }

        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public int SoLan { get; set; }
        public long TongTienDaMua { get; set; }
        
        public string PhanLoaiKH { get; set; }
        
        public int CK { get; set; }
        public KhachHang()
        {
            SoLan = 0;
            TongTienDaMua = 0;
        }

        public int XetCK()
        {
            if (PhanLoaiKH == "Gold")
                CK = 30;
            else if (PhanLoaiKH == "Silver")
                CK = 20;
            else CK = 0;
            return CK;
        }



    }
}
