using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace tabDonHang
{
    class XuatExcelBaocaoDT
    {
        public void luuexcel(List<CbaocaoDT> tapBCDT)
        {
            string filePath = "";
            SaveFileDialog dialog = new SaveFileDialog();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
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
                    p.Workbook.Properties.Title = "SALES REPORT";
                    p.Workbook.Worksheets.Add("Sheet1");
                    ExcelWorksheet worksheet = p.Workbook.Worksheets["Sheet1"];
                    worksheet.Name = "Sheet1";
                    worksheet.Cells.Style.Font.Size = 12;
                    worksheet.Cells.Style.Font.Name = "Arial";
                    string[] columnHeader = { "#", "Product ID", "Product name", "Quantity", "Revenue", "Discount", "Profit" };
                    var numberOfColumn = columnHeader.Count();
                    worksheet.Cells[1, 1].Value = "SALES REPORT";
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

                    long a = 0, b = 0, c = 0, d = 0;
                    foreach (var item in tapBCDT)
                    {
                        columnIndex = 1;
                        rowIndex++;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.STT;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.SKU;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.Tensp;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.SL; a += item.SL;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.DT; b += item.DT;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.GT; d += item.GT;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.LN; c += item.LN;
                    }

                    rowIndex++;
                    worksheet.Cells[rowIndex, 3].Value = "Total";
                    worksheet.Cells[rowIndex, 3].Style.Font.Bold = true;
                    worksheet.Cells[rowIndex, 4].Value = a.ToString();
                    worksheet.Cells[rowIndex, 5].Value = b.ToString();
                    worksheet.Cells[rowIndex, 6].Value = d.ToString();
                    worksheet.Cells[rowIndex, 7].Value = c.ToString();
                    Byte[] bin = p.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                    MessageBox.Show("Successfully exported in excel!");
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

    }
}
