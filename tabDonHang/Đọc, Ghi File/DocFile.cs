using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using tabDonHang.Sản_phẩm;

namespace tabDonHang.Đọc__Ghi_File
{
    class DocFile
    {
        
        public List<HoaDon> DocFile_TraVeListHoaDon1(string tenFile)
        {
            List<HoaDon> list = new List<HoaDon>();
            string line;
            string[] chuoiTrongLine;
            FileStream FileDonHang = File.Open(tenFile, FileMode.Open, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(FileDonHang);
            try
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    chuoiTrongLine = TachChuoi(line);
                    HoaDon hoaDon = new HoaDon();
                    hoaDon.STT = int.Parse(chuoiTrongLine[0]);
                    hoaDon.MaDH = chuoiTrongLine[1];
                    hoaDon.TenKhachHang = chuoiTrongLine[2];
                    hoaDon.SoDienThoai = chuoiTrongLine[3];
                    hoaDon.DiaChi = chuoiTrongLine[4];
                    hoaDon.ChietKhau = int.Parse(chuoiTrongLine[5]);
                    hoaDon.ChietKhauHien = hoaDon.ChietKhau + "%";
                    hoaDon.ThanhTien_HD = chuoiTrongLine[6];
                    hoaDon.NgayMua = chuoiTrongLine[7];
                    hoaDon.PhuongThucThanhToan = chuoiTrongLine[8];
                    list.Add(hoaDon);
                }
                reader.Close();
                FileDonHang.Close();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            return list;
        }


        public static string[] TachChuoi(string A)
        {
            string[] B = A.Split('*');
            return B;
        }

        
        public MangHoaDon DocFile_TraVeMangHoaDon1(string tenFile)
        {
            MangHoaDon mangHD = new MangHoaDon();
            string line;
            string[] chuoiTrongLine;
            FileStream FileDonHang = File.Open(tenFile, FileMode.Open, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(FileDonHang);
            try
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    chuoiTrongLine = TachChuoi(line);
                    HoaDon hoaDon = new HoaDon();
                    hoaDon.STT = int.Parse(chuoiTrongLine[0]);
                    hoaDon.MaDH = chuoiTrongLine[1];
                    hoaDon.TenKhachHang = chuoiTrongLine[2];
                    hoaDon.SoDienThoai = chuoiTrongLine[3];
                    hoaDon.DiaChi = chuoiTrongLine[4];
                    hoaDon.ChietKhau = int.Parse(chuoiTrongLine[5]);
                    hoaDon.ChietKhauHien = hoaDon.ChietKhau + "%";
                    hoaDon.ThanhTien_HD = chuoiTrongLine[6];
                    hoaDon.NgayMua = chuoiTrongLine[7];
                    hoaDon.PhuongThucThanhToan = chuoiTrongLine[8];
                    mangHD.NhapMangHoaDon(hoaDon);
                }
                reader.Close();
                FileDonHang.Close();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            return mangHD;
        }

        
        public MangTenSP DocFile_TraVeMangTenSP(string tenFile)
        {
            MangTenSP mangSP = new MangTenSP();
            string line;
            string[] chuoiTrongLine;
            FileStream FileSP = File.Open(tenFile, FileMode.Open, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(FileSP);
            try
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    chuoiTrongLine = TachChuoi(line);
                    SanPham sanpham = new SanPham();
                    sanpham.STT = int.Parse(chuoiTrongLine[0]);
                    sanpham.Hinh = chuoiTrongLine[1];
                    sanpham.TenSanPham = chuoiTrongLine[2];
                    sanpham.MaSanPham = chuoiTrongLine[3];
                    sanpham.TenNCC = chuoiTrongLine[4];
                    sanpham.GiaGoc = long.Parse(chuoiTrongLine[5]);
                    sanpham.GiaBan = long.Parse(chuoiTrongLine[6]);
                    sanpham.SoLuongNhap = long.Parse(chuoiTrongLine[7]);
                    sanpham.SoLuongBan = long.Parse(chuoiTrongLine[8]);
                    sanpham.SoLuongTon = long.Parse(chuoiTrongLine[9]);
                    mangSP.NhapMangSP(sanpham);
                }
                reader.Close();
                FileSP.Close();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            return mangSP;
        }
        public List<SanPham> DocFile_TraVeListSP(string tenFile)
        {
            List<SanPham> list = new List<SanPham>();
            string line;
            string[] chuoiTrongLine;
            FileStream FileSP = File.Open(tenFile, FileMode.Open, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(FileSP);
            try
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    chuoiTrongLine = TachChuoi(line);
                    SanPham sanpham = new SanPham();
                    sanpham.STT = int.Parse(chuoiTrongLine[0]);
                    sanpham.Hinh = chuoiTrongLine[1];
                    sanpham.TenSanPham = chuoiTrongLine[2];
                    sanpham.MaSanPham = chuoiTrongLine[3];
                    sanpham.TenNCC = chuoiTrongLine[4];
                    sanpham.GiaGoc = long.Parse(chuoiTrongLine[5]);
                    sanpham.GiaBan = long.Parse(chuoiTrongLine[6]);
                    sanpham.SoLuongNhap = long.Parse(chuoiTrongLine[7]);
                    sanpham.SoLuongBan = long.Parse(chuoiTrongLine[8]);
                    sanpham.SoLuongTon = long.Parse(chuoiTrongLine[9]);
                    list.Add(sanpham);
                }

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            reader.Close();
            FileSP.Close();
            return list;
        }


  
        
        public void ghiVaoFileHoaDon(string file, MangHoaDon mangHoaDon)
        {
            FileStream FileGhi = File.Create(file);
            StreamWriter writer = new StreamWriter(FileGhi, Encoding.Unicode);
            int i;
            for (i = 0; i < mangHoaDon.LaySoPhanTu(); i++)
            {

                writer.WriteLine
                        (mangHoaDon.HDon[i].STT + "*"
                        + mangHoaDon.HDon[i].MaDH
                        + "*" + mangHoaDon.HDon[i].TenKhachHang
                        + "*" + mangHoaDon.HDon[i].SoDienThoai
                        + "*" + mangHoaDon.HDon[i].DiaChi
                        + "*" + mangHoaDon.HDon[i].ChietKhau
                        + "*" + mangHoaDon.HDon[i].ThanhTien_HD
                        + "*" + mangHoaDon.HDon[i].NgayMua
                        + "*" + mangHoaDon.HDon[i].PhuongThucThanhToan);
            }
            writer.Flush();
            writer.Close();

        }



        
   
        public void ghiVaoFileSanPham(string file, MangTenSP mangsp)
        {
            FileStream FileGhi = File.Create(file);
            StreamWriter writer = new StreamWriter(FileGhi, Encoding.Unicode);
            int i;
            for (i = 0; i < mangsp.LaySoPhanTu(); i++)
            {
                writer.WriteLine
                    (mangsp.spham[i].STT + "*"
                            + mangsp.spham[i].Hinh + "*"
                            + mangsp.spham[i].TenSanPham
                            + "*" + mangsp.spham[i].MaSanPham
                            + "*" + mangsp.spham[i].TenNCC
                            + "*" + mangsp.spham[i].GiaGoc
                            + "*" + mangsp.spham[i].GiaBan
                            + "*" + mangsp.spham[i].SoLuongNhap
                            + "*" + mangsp.spham[i].SoLuongBan
                            + "*" + mangsp.spham[i].SoLuongTon);
            }
            writer.Flush();
            writer.Close();

        }

        
        public void docfilebaocao(string file, List<CbaocaoDT> a, CmangBCDT b)
        {
            FileStream filebaocao = new FileStream(file, FileMode.Open, FileAccess.Read);

            StreamReader sr = new StreamReader(file);

            string s;
            try
            {
                while ((s = sr.ReadLine()) != null)
                {
                    CbaocaoDT BCDT = new CbaocaoDT();
                    BCDT.SKU = s.Split('/')[0];
                    BCDT.Tensp = s.Split('/')[1];
                    BCDT.SL = int.Parse(s.Split('/')[2]);
                    BCDT.DT = long.Parse(s.Split('/')[3]);
                    BCDT.TV = long.Parse(s.Split('/')[4]);
                    BCDT.GT = int.Parse(s.Split('/')[5]);
                    BCDT.LN = long.Parse(s.Split('/')[6]);
                    b.them1dongBCDT(BCDT);
                    a.Add(BCDT);
                }
            }
            catch(Exception ee)
            {

            }
            sr.Close();
            filebaocao.Close();


        }
    }
}
