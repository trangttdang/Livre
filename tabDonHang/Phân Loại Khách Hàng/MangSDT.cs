using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang
{
    class MangSDT
    {
        public string[] sdt = new string[1000];
        public int spt;
        public void TaoMangSDT(MangHoaDon A)
        {
            spt = 0;
            int i, j, count;
            for (i=0; i<A.LaySoPhanTu(); i++)
            {
                count = 0;
                if(spt==0)
                {
                    sdt[0] = A.HDon[i].SoDienThoai;
                    spt++;
                }
                else
                {
                    for(j=0;j<spt;j++)
                    {
                        if (A.HDon[i].SoDienThoai == sdt[j])
                            count++;
                    }
                    if (count == 0)
                    {
                        sdt[spt] = A.HDon[i].SoDienThoai;
                        spt++;
                    }
                }
            }
        }
        public KhachHang TimSoLanXuatHienSĐT(MangHoaDon A,string SDT)
        {
            KhachHang B = new KhachHang();
            int i;
            long a;
            for(i=0;i<A.LaySoPhanTu();i++)
            {
                if (SDT.Trim() == A.HDon[i].SoDienThoai.Trim())
                {
                    B.TenKhachHang = A.HDon[i].TenKhachHang;
                    B.SoDienThoai = A.HDon[i].SoDienThoai.Trim();
                    B.DiaChi = A.HDon[i].DiaChi;
                    B.SoLan++;
                    a = long.Parse(A.HDon[i].ThanhTien_HD);
                    B.TongTienDaMua += a;
                }
            }
            if (B.TongTienDaMua >= 10000000)
                B.PhanLoaiKH = "Gold";
            else if (B.TongTienDaMua >= 5000000)
                B.PhanLoaiKH = "Silver";
            else
                B.PhanLoaiKH = "Normal";
            return B;
        }
        
    }
}
