using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang
{
    class MangKhachHang
    {
        public KhachHang[] khachHang = new KhachHang[1000];
        public int spt = 0;
        public int STT;
        public void ThemKhachHang(KhachHang A)
        {
            khachHang[spt] = A;
            spt++;
            khachHang[spt - 1].STT = spt;
        }

        
    }
}
