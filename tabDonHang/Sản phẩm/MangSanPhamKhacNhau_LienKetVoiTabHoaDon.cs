using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang.Sản_phẩm
{
    class MangSanPhamKhacNhau_LienKetVoiTabHoaDon
    {

        //Phương thức phụ
        public MangTenSP TaoMangSanPhamKhacNhau_TuMangTenSP(MangTenSP A)
        {
            MangTenSP B = new MangTenSP();
            B.spt = 0;
            int i, j, count;
            for (i = 0; i < A.LaySoPhanTu(); i++)
            {
                count = 0;
                if (B.spt == 0)
                {
                    B.spham[i] = A.spham[0];
                    B.spt++;
                }
                else
                {
                    for (j = 0; j < B.spt; j++)
                    {
                        if (A.spham[i] == B.spham[j])
                            count++;
                    }
                    if (count == 0)
                    {
                        B.spham[B.spt] = A.spham[i];
                        B.spt++;
                    }
                }
            }
            return B;
        }
        //------------------------   



         //Phương thức chính
        public long XetMSP_TraVeGia(MangTenSP A, string msp)
        {
            long giaTraVe=-1;
            MangTenSP B = TaoMangSanPhamKhacNhau_TuMangTenSP(A);
            int i;
            for(i=0;i<B.spt;i++)
            {
                if(msp == B.spham[i].MaSanPham)
                {
                    giaTraVe = B.spham[i].GiaBan;
                    break;
                }
            }
            return giaTraVe;
        }
        public string XetMSP_TraVeTen(MangTenSP A, string msp)
        {
            string tenTraVe = "-1";
            MangTenSP B = TaoMangSanPhamKhacNhau_TuMangTenSP(A);
            int i;
            for (i = 0; i < B.spt; i++)
            {
                if (msp == B.spham[i].MaSanPham)
                {
                    tenTraVe = B.spham[i].TenSanPham;
                    break;
                }
            }
            return tenTraVe;
        }
    }
}
