using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Pronto.Common
{
  public  class ExcelImport
    {

        public static void ExportToPdf(Route route,string pdfFile)
        {
            Excel.Workbook wbk = ExportToExcel(route);
            Excel.Application app = wbk.Application;
            app.Visible = false;
            app.DisplayAlerts = false;
            wbk.Worksheets["Search"].Delete();
            wbk.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, pdfFile, XlFixedFormatQuality.xlQualityMinimum, false);
            wbk.Close(false);
            app.Quit();

        }


        public static void ExportToPdf(System.Data.DataTable dtTable, string pdfFile)
        {
            Excel.Workbook wbk = ExportToExcel(dtTable);
            Excel.Application app = wbk.Application;
            app.Visible = false;
            app.DisplayAlerts = false;
            wbk.Worksheets["Stops"].Delete();
            wbk.Worksheets["Route"].Delete();
            wbk.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, pdfFile, XlFixedFormatQuality.xlQualityMinimum, false);
            wbk.Close(false);
            app.Quit();

        }
        public static void ExportExcel(Route route)
        {
            Excel.Workbook wk = ExportToExcel(route);
            wk.Application.Visible = true;
            wk.Application.WindowState = XlWindowState.xlMaximized;
        }

        public static void ExportExcel(System.Data.DataTable dtTable)
        {
            Excel.Workbook wk = ExportToExcel( dtTable);
            wk.Application.Visible = true;
            wk.Worksheets["Search"].Select();
            wk.Application.WindowState = XlWindowState.xlMaximized;
        }
        private  static Excel.Workbook ExportToExcel(System.Data.DataTable dtTable)
        {
            Excel.Workbook wbk = OpenExcel();
            Excel.Worksheet wkSheet = wbk.Worksheets["Search"];
            for (int i = 0; i < dtTable.Columns.Count; i++)
            {
                wkSheet.Cells[1, i+1].Value = dtTable.Columns[i].ColumnName;
                for (int j = 0; j < dtTable.Rows.Count; j++)
                {
                    wkSheet.Cells[j+2, i+1].Value = dtTable.Rows[j][i].ToString();
                }
            }
            wkSheet.Columns.AutoFit();

            wkSheet.PageSetup.PrintArea = wkSheet.Range[wkSheet.Cells[1, 1], wkSheet.Cells[dtTable.Rows.Count + 1, dtTable.Columns.Count]].Address;

            return wbk;
        }

        
        private static Excel.Workbook ExportToExcel(Route route)
        {
            Excel.Workbook wbk = OpenExcel();

            foreach (Excel.Worksheet item in wbk.Worksheets)
            {
                item.PageSetup.LeftHeader = "Route ID: -" + route.RootNo.ToString();
                item.PageSetup.RightHeader = "Route Date:-" + route.RouteDate.ToString();
            }

            WritToExcel("RootNo", route.RootNo.ToString(), wbk);
            WritToExcel("RouteDate", route.RouteDate.ToString(), wbk);
            WritToExcel("DriverName", route.driver.DriverName.ToString(), wbk);

            WritToExcel("VehicleId", route.truck.VehicleID, wbk);
         
            WritToExcel("LicencePlateId", route.truck.LicencePlateId, wbk);
            WritToExcel("TruckId", route.truck.TruckId.ToString(), wbk);

            if (route.helpers != null)
            {
                for (int i = 0; i < route.helpers.Count; i++)
                {
                    WritToExcel("HelperName" + (i + 1).ToString(), route.helpers[i].HelperName.ToString(), wbk);
                }
            }

            WritToExcel("DepatureTime", route.DepatureTime.ToString(), wbk);
            WritToExcel("ArrivelTime", route.ArrivelTime.ToString(), wbk);
            WritToExcel("DepartureMilage", route.DepartureMilage.ToString(), wbk);
            WritToExcel("ArrivelMilage", route.ArrivelMilage.ToString(), wbk);
            WritToExcel("RouteMlg", route.RouteMlg.ToString(), wbk);

            WritToExcel("HotelInfo", route.HotelInfo.ToString(), wbk);
            WritToExcel("HotelReceipt", route.HotelReceipt.ToString(), wbk);

            WritToExcel("TotolCod", route.TotolCod.ToString(), wbk);
            WritToExcel("CodDecrepency", route.CodDecrepency.ToString(), wbk);

            WritToExcel("BreakAStart", route.BreakAStart.ToString(), wbk);
            WritToExcel("BreakAEnd", route.BreakAEnd.ToString(), wbk);

            WritToExcel("BreakBStart", route.BreakBStart.ToString(), wbk);
            WritToExcel("BreakBEnd", route.BreakBEnd.ToString(), wbk);

            WritToExcel("LunchStart", route.LunchStart.ToString(), wbk);
            WritToExcel("LunchEnd", route.LunchEnd.ToString(), wbk);

            WritToExcel("DinnerStart", route.DinnerStart.ToString(), wbk);
            WritToExcel("DinnerEnd", route.DinnerEnd.ToString(), wbk);

            WritToExcel("DriverComments", route.DriverComments.ToString(), wbk);
            WriteStopsToExcel(wbk, route.stops, route.RootNo, route.RouteDate);

            return wbk;
        }

        private static void WriteStopsToExcel(Excel.Workbook wk,List<Stop> stopList,int RootNo,DateTime routedate)
        {
            Excel.Worksheet wkSheet = wk.Worksheets["Stops"];
          
            //wkSheet.UsedRange.PageBreak = (int)Excel.XlPageBreak.xlPageBreakManual;
            int Offset = 31;
            int lastRow = stopList.Count * Offset;

            //wkSheet.Application.ActiveWindow.View = XlWindowView.xlPageBreakPreview;
            wkSheet.PageSetup.PrintArea = wkSheet.Range[wkSheet.Cells[1, 1], wkSheet.Cells[lastRow, 6]].Address;
            //wkSheet.HPageBreaks.Add(wkSheet.Range["A7"]);
            //wkSheet.VPageBreaks.Add(wkSheet.Cells[4,3]);

          

            for (int i = stopList.Count; i > 0 ;i--)
            {
                WritToExcel("StopNo", "Stop-" + i.ToString(), wk);
                WritToExcel("ClientName", stopList[i-1].ClientName, wk);

                if (stopList[i - 1].customer != null)
                {
                    WritToExcel("CustomerName", stopList[i - 1].customer.CustomerName, wk); 
                }

                WritToExcel("ClientAddr", stopList[i - 1].ClientAddr, wk);
                WritToExcel("ClientCity", stopList[i - 1].ClientCity, wk);
                WritToExcel("ClientState", stopList[i - 1].ClientState, wk);
                WritToExcel("ClientZipCode", stopList[i - 1].ClientZipCode, wk);

                if (stopList[i - 1].service != null)
                {
                    WritToExcel("ServiceType", stopList[i - 1].service.ServiceType, wk); 
                }

                WritToExcel("ClientPh", stopList[i - 1].ClientPh, wk);
                WritToExcel("PTSID", stopList[i - 1].PtsId, wk);
                WritToExcel("QBDocNo", stopList[i - 1].QbDocNo, wk);
                WritToExcel("PhoneID", stopList[i - 1].PhoneId, wk);
                WritToExcel("PADID", stopList[i - 1].PadId, wk);
                WritToExcel("StopArrivalTime", stopList[i - 1].StopArrivalTime.ToString(), wk);
                WritToExcel("ETA", stopList[i - 1].Eta, wk);
                WritToExcel("StopMlgMeterRead", stopList[i - 1].StopMlgMeterRead.ToString(), wk);
                WritToExcel("StopDepartTime", stopList[i - 1].StopDepartTime.ToString(), wk);
                WritToExcel("StopCodAmount", stopList[i - 1].StopCodAmount.ToString(), wk);
                WritToExcel("StopTimeAllot", stopList[i - 1].StopTimeAllot.ToString(), wk);
                WritToExcel("StopNote", stopList[i - 1].StopNote, wk);

                if (i > 1)
                {
                    wk.Names.Item("StopArea").RefersToRange.EntireRow.Copy();
                    wkSheet.Cells[Offset * (i - 1) + 1, 1].PasteSpecial(XlPasteType.xlPasteAll, XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);

                    //wkSheet.Cells[Offset * (i - 1) + 1, 1].PasteSpecial(XlPasteType.xlPasteFormats, XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
                    var tt = wkSheet.Cells[Offset * (i - 1) + 1, 1].Address;
                    wkSheet.HPageBreaks.Add(wkSheet.Cells[Offset * (i - 1) + 1, 1]);

                   
                }

                
            }

            //if (stopList.Count > 1)
            //{
            //    wkSheet.HPageBreaks[1].DragOff(XlDirection.xlDown, 1);

            //}
            Clipboard.Clear();
            //wkSheet.Columns.AutoFit();
            
        }

        private static void WritToExcel(string PropName,string value,Excel.Workbook wk)
        {
            try
            {
                wk.Names.Item(PropName).RefersToRange.Value = value;
            }
            catch (Exception ex)
            {

                throw new Exception("Cannot write value to excel " + PropName, ex);
            }
        }

        private static Excel.Workbook OpenExcel()
        {
            string TemplatePath = Path.Combine(Utility.ProjectPaths.InstallationPath, "Template.xltx");
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook wktmpl = xlApp.Workbooks.Open(TemplatePath);

            //xlApp.Visible = true;
            //xlApp.WindowState = Excel.XlWindowState.xlMaximized;

            return wktmpl;
            
        }
    }
}
