using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang.Sản_phẩm
{
    class MangMSP
    {

        public string[] msp = new string[1000];
        public int spt;
        public void TaoMangMSP_TuMangTenSP(MangTenSP A)
        {
            spt = 0;
            int i, j, count;
            for (i = 0; i < A.LaySoPhanTu(); i++)
            {
                count = 0;
                if (spt == 0)
                {
                    msp[0] = A.spham[i].MaSanPham;
                    spt++;
                }
                else
                {
                    for (j = 0; j < spt; j++)
                    {
                        if (A.spham[i].MaSanPham == msp[j])
                            count++;
                    }
                    if (count == 0)
                    {
                        msp[spt] = A.spham[i].MaSanPham;
                        spt++;
                    }
                }
            }
        }
       



        public void TaoMangMSP_TuMangHoaDon(MangHoaDon A)
        {
            spt = 0;
            int i, j, count;
            for (i = 0; i < A.LaySoPhanTu(); i++)
            {
                count = 0;
                if (spt == 0)
                {
                    msp[0] = A.HDon[i].MaSanPham;
                    spt++;
                }
                else
                {
                    for (j = 0; j < spt; j++)
                    {
                        if (A.HDon[i].MaSanPham == msp[j])
                            count++;
                    }
                    if (count == 0)
                    {
                        msp[spt] = A.HDon[i].MaSanPham;
                        spt++;
                    }
                }
            }
        }


        


    }
}
