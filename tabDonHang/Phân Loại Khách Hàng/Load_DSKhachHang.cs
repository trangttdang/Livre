using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang.Phân_Loại_Khách_Hàng
{
    class Load_DSKhachHang
    {
        public List<KhachHang> LoadDSKH_TraVeItemSource(MangHoaDon A)
        {
            MangSDT mangsdt = new MangSDT();
            mangsdt.TaoMangSDT(A);
            KhachHang B = new KhachHang();
            MangKhachHang mangKH = new MangKhachHang();
            List<KhachHang> listKH = new List<KhachHang>();
            int i;
            for(i=0;i<mangsdt.spt;i++)
            {
                 B = mangsdt.TimSoLanXuatHienSĐT(A, mangsdt.sdt[i]);
                B.STT = i + 1;
                 listKH.Add(B);
            }
            return listKH;
        }
        public MangKhachHang LoadDSKH_TraVeMangKH(MangHoaDon A)
        {
            MangSDT mangsdt = new MangSDT();
            mangsdt.TaoMangSDT(A);
            KhachHang B = new KhachHang();
            MangKhachHang mangKH = new MangKhachHang();
            int i;
            for (i = 0; i < mangsdt.spt; i++)
            {
                B = mangsdt.TimSoLanXuatHienSĐT(A, mangsdt.sdt[i]);
                mangKH.ThemKhachHang(B);
            }
            return mangKH;
        }

    }
}
