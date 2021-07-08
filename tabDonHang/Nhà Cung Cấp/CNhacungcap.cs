using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabDonHang.Nhà_Cung_Cấp.Thông_tin_chi_tiết;

namespace tabDonHang
{
    public class CNhacungcap
    {
        public string TenNCC { get; set; }
        public string NhomNCC { get; set; }
        public string MaNCC { get; set; }
        public string EmailNCC { get; set; }
        public string SDTNCC { get; set; }
        public string Trangthai { get; set; }

        public string DiaChi, NhanVien, Website, ThueMD, GiaMD, HTTT;
        public MangLichSuNhapHang History = new MangLichSuNhapHang();
        

        public void NhapNCC (string mancc, string tenncc, string nhomncc, string emailncc, string sdtncc, string trangthai)
        {
            TenNCC = tenncc;
            NhomNCC = nhomncc;
            MaNCC = mancc;
            EmailNCC = emailncc;
            SDTNCC = sdtncc;
            Trangthai = trangthai;

            
        }

        public void xuatlv ()
        {
            TenNCC = this.TenNCC;
            NhomNCC = this.NhomNCC;
            MaNCC = this.MaNCC;
            EmailNCC = this.EmailNCC;
            SDTNCC = this.SDTNCC;
        }
    }
}
