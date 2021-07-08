using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang
{
    class MangHoaDon
    {
        public HoaDon[] HDon = new HoaDon[1000];
        int spt = 0;
        public void NhapMangHoaDon(HoaDon A)
        {
            HDon[spt] = A;
            spt++;
            HDon[spt - 1].STT = spt;
        }
        public int LaySoPhanTu()
        {
            return spt;
        }
        public int LaySTT()
        {
            int STT;
            STT = spt;
            return STT;
        }

        
    }
}
