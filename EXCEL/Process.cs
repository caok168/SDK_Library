using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace EXCELProcess
{
    public class Process
    {
        /// <summary>
        /// 读取Excel中的数据到DataTable
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <param name="sheetName"></param>
        /// <param name="headerRowIndex"></param>
        /// <returns></returns>
        public DataTable GetExcelData(string excelFilePath, string sheetName, int headerRowIndex)
        {
            using (FileStream stream = System.IO.File.OpenRead(excelFilePath))
            {
                HSSFWorkbook workbook = new HSSFWorkbook(stream);
                ISheet sheet = workbook.GetSheet(sheetName);
                DataTable table = new DataTable();
                IRow headerRow = sheet.GetRow(headerRowIndex);
                int cellCount = headerRow.LastCellNum;

                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    DataColumn column = new DataColumn(headerRow.GetCell(i).ToString());
                    table.Columns.Add(column);
                }

                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    DataRow dataRow = table.NewRow();

                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        dataRow[j] = row.GetCell(j).ToString();
                    }

                    table.Rows.Add(dataRow);
                }

                stream.Close();
                workbook = null;
                sheet = null;
                return table;
            }
        }

        /// <summary>
        /// 将DataTable中的数据导入到Excel文件中
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <param name="sheetName"></param>
        /// <param name="dt"></param>
        public void WriteExcelData(string excelFilePath, string sheetName, DataTable dt)
        {
            try
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                ISheet sheet = workbook.CreateSheet(sheetName);

                IRow rowHeader = sheet.CreateRow(0);
                ICellStyle style = workbook.CreateCellStyle();
                style.Alignment = HorizontalAlignment.Center;
                style.VerticalAlignment = VerticalAlignment.Center;

                if (dt.Rows.Count > 0)
                {

                    int columnCount = dt.Columns.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IRow row = sheet.CreateRow(i + 1);

                        for (int j = 0; j < columnCount; j++)
                        {
                            ICell cell = row.CreateCell(j);
                            cell.SetCellValue(dt.Rows[i][j].ToString());
                            cell.CellStyle = style;
                        }

                    }
                }

                FileStream fs = new FileStream(excelFilePath, FileMode.Create);
                workbook.Write(fs);
                fs.Close();
                workbook = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
