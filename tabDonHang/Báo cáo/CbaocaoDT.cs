using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang
{
    class CbaocaoDT
    {
        public int STT { get; set; }
        public string SKU { get; set; }
        public string Tensp { get; set; }
        public long SL { get; set; }
        public long DT { get; set; }
        public long LN { get; set; }
        public long TV { get; set; }
        public long GT { get; set; }
        public string luuBCDT()
        {
            return SKU + "/" + Tensp + "/" + SL.ToString() + "/" + DT.ToString() + "/" + TV.ToString() + "/" + GT.ToString() + "/" + LN.ToString();
        }

    }
}
