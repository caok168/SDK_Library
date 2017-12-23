using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CommonTest
{
    public class excel
    {
        EXCELProcess.Process excelProcess = new EXCELProcess.Process();

        public void Test()
        {
            string path = @"H:\工作文件汇总\铁科院\程序\集成分析平台\data\test.xls";

            DataTable dt = getExcelData(path);

            string path_new = @"H:\工作文件汇总\铁科院\程序\集成分析平台\data\test_new.xls";

            excelProcess.WriteExcelData(path_new, "Sheet1", dt);
        }

        public DataTable getExcelData(string filePath)
        {
            DataTable dt = excelProcess.GetExcelData(filePath, "Sheet1", 0);

            return dt;
        }
    }
}
