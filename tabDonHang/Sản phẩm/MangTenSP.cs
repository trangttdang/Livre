using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang.Sản_phẩm
{
    class MangTenSP
    {

        public SanPham[] spham = new SanPham[1000];
        public List<SanPham> ListSPham = new List<SanPham>();
        public int spt;
        public void NhapMangSP(SanPham A)
        {
            spham[spt] = A;
            spt++;
            spham[spt - 1].STT = spt;
            ListSPham.Add(A);
        }
        public int LaySTT()
        {

            int STT;
            STT = spt;
            return STT;
        }
        public int LaySoPhanTu()
        {
            return spt;
        }
        public void ChonSP(string x)
        {
            int i;
            List<SanPham> ChonNhomSP = new List<SanPham>();
            for (i = 0; i < spt; i++)
            {
                if (ListSPham[i].TenSanPham == x)
                {
                    ChonNhomSP.Add(ListSPham[i]);
                }
            }
            ListSPham = ChonNhomSP;
        }

        public void capnhatmang()
        {
            for (int i = 0; i < spt; i++)
            {
                spham[i] = ListSPham[i];
            }
        }
    }
}
