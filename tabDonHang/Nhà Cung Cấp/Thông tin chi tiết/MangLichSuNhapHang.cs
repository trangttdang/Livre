using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabDonHang.Nhà_Cung_Cấp.Thông_tin_chi_tiết
{
    public class MangLichSuNhapHang
    {
        public int spt=0;
        public List<LichSuNhapHang> ListHistory = new List<LichSuNhapHang>();

        public void nhapmangLichSu(LichSuNhapHang lsu)
        {
            spt++;
            ListHistory.Add(lsu);
        }

        public void nhapmang(List<LichSuNhapHang> a)
        {
            ListHistory = a;
        }
        public void docfile(string tenfile)
        {
            string s;
            string[] ttLS;
            FileStream file = new FileStream(tenfile, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);
            try
            {
                while ((s = sr.ReadLine()) != null)
                {
                    LichSuNhapHang tam = new LichSuNhapHang();
                    ttLS = tach(s);
                    tam.MaDonNhap = ttLS[0];
                    tam.TongGiaTri = ttLS[1];
                    tam.NgayTaoDonNhap = ttLS[2];
                    nhapmangLichSu(tam);
                }
            }
            catch(Exception ee)
            {

            }
            sr.Close();
            file.Close();
        }
        public static string[] tach(string tt)
        {
            string[] a = tt.Split('_');
            return a;
        }
        public void capnhatfile(string tenfile)
        {
            try
            {
                FileStream file = new FileStream(tenfile, FileMode.Truncate, FileAccess.Write);
                StreamWriter sr = new StreamWriter(file);

                // Read contents of file into a string
                for (int i = 0; i < spt; i++)
                {
                    sr.WriteLine
                        (ListHistory[i].MaDonNhap
                        + "_" + ListHistory[i].TongGiaTri
                        + "_" + ListHistory[i].NgayTaoDonNhap);
                }

                // Close StreamReader
                sr.Close();

                // Close file
                file.Close();

            }
            catch
            {
                FileStream file = new FileStream(tenfile, FileMode.Create, FileAccess.Write);
                StreamWriter sr = new StreamWriter(file);

                // Read contents of file into a string
                for (int i = 0; i < spt; i++)
                {
                    sr.WriteLine
                        (ListHistory[i].MaDonNhap
                        + "_" + ListHistory[i].TongGiaTri
                        + "_" + ListHistory[i].TongGiaTri);
                }

                // Close StreamReader
                sr.Close();

                // Close file
                file.Close();

            }


        }

    }
}
