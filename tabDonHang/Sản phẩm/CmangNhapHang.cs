using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang.Sản_phẩm
{
    class CmangNhapHang
    {
        public int spt;
        public List<SanPham> ListNhapHang = new List<SanPham>();

        public void nhapmangNhapHang(SanPham sp)
        {
            spt++;
            ListNhapHang.Add(sp);
        }

        public void nhapmang(List<SanPham> a)
        {
            ListNhapHang = a;
        }

        public void ChonSP(string loc)
        {
        }
    }
}
