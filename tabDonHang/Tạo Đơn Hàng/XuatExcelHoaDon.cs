using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Microsoft.Win32;
using System.Windows;
using System.IO;

namespace tabDonHang
{
    class XuatExcelHoaDon
    {
        public void xuatExcelHoaDon(List<HoaDon> ListHoaDon)
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
                if (filePath != "")
                    MessageBox.Show("Error link");
                return;
            }
            try
            {
                using (ExcelPackage p = new ExcelPackage())
                {
                    p.Workbook.Properties.Author = "Livre";
                    p.Workbook.Properties.Title = "List of invoices report";
                    p.Workbook.Worksheets.Add("Sheet1");
                    ExcelWorksheet worksheet = p.Workbook.Worksheets["Sheet1"];
                    worksheet.Name = "Sheet1";
                    worksheet.Cells.Style.Font.Size = 12;
                    worksheet.Cells.Style.Font.Name = "Arial";
                    string[] columnHeader = { "#", "Customer name", "Phone number", "Address", "Product name", "Product ID", "Quantity", "Price","Discount", "Total", "Date", "Payment method" };
                    var numberOfColumn = columnHeader.Count();
                    worksheet.Cells[1, 1].Value = "List of invoices report";
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
                    foreach (var item in ListHoaDon)
                    {
                        columnIndex = 1;
                        rowIndex++;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.STT;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.TenKhachHang;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.SoDienThoai;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.DiaChi;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.TenSanPham;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.MaSanPham;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.SoLuong;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.GiaBan;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.ChietKhau;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.ThanhTien;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.NgayMua;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.PhuongThucThanhToan;
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
    }
}
