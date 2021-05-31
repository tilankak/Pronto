using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Pronto.Common.Data
{
    public class ExcelDataAcess : DataAccess
    {
        Excel.Workbook wkBook;
        Excel.Application xlApp;

        public ExcelDataAcess(string excelFile)
        {
            wkBook = OpenExcel(excelFile);
        }
        public override void CreateDb(string FilePath)
        {
            throw new NotImplementedException();
        }

        public override void CreateTable(string sql)
        {
            throw new NotImplementedException();
        }

        public override string LoadConnectionString()
        {
            throw new NotImplementedException();
        }

        public override List<T> LoadData<T>(string sql)
        {
            throw new NotImplementedException();
        }

        public override void RunScript(string sql)
        {
            throw new NotImplementedException();
        }

        public override int SaveData<T>(string sql, T data)
        {
            throw new NotImplementedException();
        }

        public List<string> ReadExcel(string SheetName)
        {
            int RowNumber = 0;
            //Excel.Workbook wkbk = OpenExcel(ExcelFile);
            Excel.Worksheet wksh = wkBook.Worksheets[SheetName];
            List<string> listA = new List<string>();
            string Value = "";


            do
            {
                RowNumber++;
                Value = wksh.Cells[RowNumber, 1].Value;
                if (!string.IsNullOrEmpty(Value))
                { listA.Add(Value); }
                else
                { listA.Add(""); }


            } while (!string.IsNullOrEmpty(Value));

            return (listA);

        }

        private Excel.Workbook OpenExcel(string ExcelFile)
        {

            xlApp = new Excel.Application();
            Excel.Workbook wktmpl = xlApp.Workbooks.Open(ExcelFile);
            //xlApp.Visible = true;
            //xlApp.WindowState = Excel.XlWindowState.xlMaximized;

            return wktmpl;

        }

        public void Close()
        {
            wkBook.Close(false);
            xlApp.Quit();
        }
    }
}
