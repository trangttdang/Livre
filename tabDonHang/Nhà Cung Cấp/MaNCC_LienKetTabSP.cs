using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang.Nhà_Cung_Cấp
{
    class MaNCC_LienKetTabSP
    {
        //Trang + Nữ
        public CmangNCC mangnhacungcap = new CmangNCC();
        public List<CNhacungcap> ListNhaCC = new List<CNhacungcap>();

        public bool KiemtraMaNCC(string x)
        {
            int i;
            int kiem = 0;
            for (i = 0; i < mangnhacungcap.spt; i++ )
            {
                if (x == ListNhaCC[i].MaNCC)
                    kiem++;
            }
            if (kiem == 0)
                return false;
            else return true;

        }
    }
}
