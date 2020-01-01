using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWorldAutomation.Helper
{
    public static class ExcelHelper
    {
        public static DataTable ReadTestData(string filePath, string sheetName)
        {
            FileInfo testdatafile = new FileInfo(filePath);
            ExcelPackage package = new ExcelPackage(testdatafile);
            var ws = package.Workbook.Worksheets[sheetName];
            DataTable dt = new DataTable();

            bool hasHeader = true;
            foreach(var firstRowCell in ws.Cells[1,1,1,ws.Dimension.End.Column])
            {
                dt.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
            }

            var startRow = hasHeader ? 2 : 1;
            for(var rowNum = startRow; rowNum<=ws.Dimension.End.Row; rowNum++)
            {
                var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                var row = dt.NewRow();
                foreach(var cell in wsRow)
                {
                    row[cell.Start.Column - 1] = cell.Text;
                }
                dt.Rows.Add(row);
            }
            package.Dispose();
            return dt;
        }
    }
}
