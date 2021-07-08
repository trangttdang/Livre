using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Microsoft.Win32;
using System;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using tabDonHang.Nhà_Cung_Cấp.Thông_tin_chi_tiết;

namespace tabDonHang
{
    public class CmangNCC
    {
        public int spt;
        public List<CNhacungcap> ListNCC = new List<CNhacungcap>();

        public void nhapmangncc(CNhacungcap NCC)
        {
            spt++;
            ListNCC.Add(NCC);

        }

        public void nhapmang(List<CNhacungcap> a)
        {
            ListNCC = a;
        }
        public void docfile(string tenfile)
        {
            string s;
            string[] ttNCC;
            FileStream file = new FileStream(tenfile, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);
            while ((s = sr.ReadLine()) != null)
            {
                CNhacungcap NCC = new CNhacungcap();
                ttNCC = tach(s);
                NCC.MaNCC = ttNCC[0];
                NCC.TenNCC = ttNCC[1];
                NCC.NhomNCC = ttNCC[2];
                NCC.EmailNCC = ttNCC[3];
                NCC.SDTNCC = ttNCC[4];
                NCC.DiaChi = ttNCC[5];
                NCC.NhanVien = ttNCC[6];
                NCC.Website = ttNCC[7];
                NCC.ThueMD = ttNCC[8];
                NCC.GiaMD = ttNCC[9];
                NCC.HTTT = ttNCC[10];
                NCC.Trangthai = "Partner";
                nhapmangncc(NCC);
            }
            sr.Close();
            file.Close();
        }

        public void capnhatfile(string tenfile)
        {
            FileStream FileGhi = File.Create(tenfile);
            StreamWriter writer = new StreamWriter(FileGhi);
            int i;
            for (i = 0; i < spt; i++)
            {
                writer.WriteLine
                    (ListNCC[i].MaNCC + "_"
                    + ListNCC[i].TenNCC
                    + "_" + ListNCC[i].NhomNCC
                    + "_" + ListNCC[i].EmailNCC
                    + "_" + ListNCC[i].SDTNCC
                    + "_" + ListNCC[i].DiaChi
                    + "_" + ListNCC[i].NhanVien
                    + "_" + ListNCC[i].Website
                    + "_" + ListNCC[i].ThueMD
                    + "_" + ListNCC[i].GiaMD
                    + "_" + ListNCC[i].HTTT);
            }
            writer.Flush();
            writer.Close();
        }
        public static string[] tach(string tt)
        {
            string[] a = tt.Split('_');
            return a;
        }
        public int demSLNCC(string A)
        {
            int count = 0;
            int i;
            if(A=="NXB")
            {
                for(i=0;i<spt;i++)
                {
                    if (ListNCC[i].NhomNCC == A)
                        count++;
                }
            }
            if (A == "Book store")
            {
                for (i = 0; i < spt; i++)
                {
                    if (ListNCC[i].NhomNCC == A)
                        count++;
                }
            }
            if (A == "Other")
            {
                for (i = 0; i < spt; i++)
                {
                    if (ListNCC[i].NhomNCC == A)
                        count++;
                }
            }
            return count;
        }

        public bool timkiemtheoMa(string tim)
        {
            int i;
            int count = 0;
            List<CNhacungcap> Search = new List<CNhacungcap>();
            for (i = 0; i < spt; i++)
            {
                if (ListNCC[i].MaNCC == tim)
                {
                    Search.Add(ListNCC[i]);
                    count++;
                }
            }
            if (count == 0)
                return false;
            else
            {
                ListNCC = Search;
                return true;
            }
        }
        public void Loc(string loc)
        {
            int i;
            int count=0;
            List<CNhacungcap> LocNhom = new List<CNhacungcap>();
            for (i = 0; i < spt; i++)
            {
                if (ListNCC[i].NhomNCC == loc)
                {
                    LocNhom.Add(ListNCC[i]);
                    count++;
                }
            }
            if (count == 0)
                ListNCC = null;
            else
                ListNCC = LocNhom;
        }

        public void xuatfile()
        {
            string filePath = "";
            SaveFileDialog dialog = new SaveFileDialog();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
            if (dialog.ShowDialog() == true)
            {
                filePath = dialog.FileName;
            }
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Error link");
                return;
            }
            try
            {
                using (ExcelPackage p = new ExcelPackage())
                {
                    p.Workbook.Properties.Author = "Livre";
                    p.Workbook.Properties.Title = "List of suppliers report";
                    p.Workbook.Worksheets.Add("Sheet1");
                    ExcelWorksheet worksheet = p.Workbook.Worksheets["Sheet1"];
                    worksheet.Name = "Sheet1";
                    worksheet.Cells.Style.Font.Size = 12;
                    worksheet.Cells.Style.Font.Name = "Arial";
                    string[] columnHeader = { "Supplier name", "Supplier ID", "Supplier group", "Phone number", "Email", "Address", "Website", "Default tax", "Default price", "Payment method", "Staff in charge" };
                    var numberOfColumn = columnHeader.Count();
                    worksheet.Cells[1, 1].Value = "List of suppliers";
                    worksheet.Cells[1, 1, 1, numberOfColumn].Merge = true;
                    worksheet.Cells[1, 1, 1, numberOfColumn].Style.Font.Bold = true;
                    worksheet.Cells[1, 1, 1, numberOfColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    int columnIndex = 1, rowIndex = 2;
                    foreach (var item in columnHeader)
                    {
                        var cell = worksheet.Cells[rowIndex, columnIndex];
                        cell.Value = item;
                        columnIndex++;
                    }
                    foreach (var item in ListNCC)
                    {
                        columnIndex = 1;
                        rowIndex++;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.TenNCC;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.MaNCC;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.NhomNCC;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.SDTNCC;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.EmailNCC;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.DiaChi;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.Website;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.ThueMD;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.GiaMD;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.HTTT;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.NhanVien;
                    }
                    Byte[] bin = p.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                    MessageBox.Show("Successfully exported in excel!");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        //Liên kết với tab Sản Phẩm của Nữ
        //Cũng dùng để kiểm tra MaNCC bên tab nhà cung cấp
        public bool KiemtraMaNCC(string x)
        {
            int i;
            int kiem = 0;
            for (i = 0; i < spt; i++)
            {
                if (x == ListNCC[i].TenNCC)
                    kiem++;
            }
            if (kiem == 0)
                return false;
            else return true;

        }
        public void luulichsudonhang()
        {
            for(int i=0;i<spt;i++)
            {
                ListNCC[i].History.capnhatfile(ListNCC[i].TenNCC + "_lichsu.txt");
            }    
        }
        public void doclichsudonhang()
        {
            for (int i = 0; i < spt; i++)
            {
                ListNCC[i].History.docfile(ListNCC[i].TenNCC + "_lichsu.txt");
            }
        }
        public List<LichSuNhapHang> timkiemlichsu(string a)
        {
            List<LichSuNhapHang> tam = new List<LichSuNhapHang>();
            for(int i=0;i<spt;i++)
            {
                if(ListNCC[i].MaNCC==a)
                {
                    tam = ListNCC[i].History.ListHistory;
                }    
            }
            return tam;
            
        }
    }
}
