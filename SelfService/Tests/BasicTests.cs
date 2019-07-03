using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace SelfService
{
    [TestFixture]
    public class BasicTests : TestBase
    {
        [Test]
        public void EmbedTest()
        {
            //WorkSpacePageobj.SelectWorkSpace("IPTS Workspace");
            //var Path = WorkSpacePageobj.OpenReport("reportName").ReportEmbededMode();
            //driver.Navigate().GoToUrl("Url");
            //SharePointPageobj.openReport();
            //SharePointPageobj.LinkInput.SendKeys(Path);
            //SharePointPageobj.Save.Click();
        }
        
       

        [TearDown]
        public void TearDown()
        {
            driver.Quit();            
        }
    }

    [TestFixture]
    public class ExcelTestClass
    {
        [Test]
        public void ExcelTest()
        {

            DataSet SeleniumElementSet = new DataSet();
            var excelApp = new Excel.Application();
            var datatable = new System.Data.DataTable();
            string[] strrow = new string[2];

            int rCnt = 0;
            int cCnt = 0;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            xlApp = new Excel.Application();
            //xlWorkBook = xlApp.Workbooks.Open((AppDomain.CurrentDomain.BaseDirectory + "\\" + Workbook), 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, false, 1, 0);
            xlWorkBook = xlApp.Workbooks.Open(@"E:\Sujay\SeleniumTeamcity\SelfService\TestData\SelfService.xlsx");
            int worksheetcount = xlWorkBook.Worksheets.Count;

            xlWorkSheet = xlWorkBook.Sheets[1];



            String datatablename = xlWorkSheet.Name;
            range = xlWorkSheet.UsedRange;
            //Console.WriteLine(wks);

            var dt = new System.Data.DataTable(datatablename);

            int rowCount = range.Rows.Count;
            int colCount = range.Columns.Count;
            //int colCount = 3;
            string[] headers = new string[colCount];
            for (cCnt = 1; cCnt <= colCount; cCnt++)
            {

                headers[cCnt - 1] = (Convert.ToString((range.Cells[1, cCnt] as Excel.Range).Value2));
                dt.Columns.Add(headers[cCnt - 1]);
                //Console.WriteLine(headers[cCnt - 1]);
            }
            for (rCnt = 2; rCnt <= rowCount; rCnt++)
            {
                var array = new object[colCount];

                for (cCnt = 1; cCnt <= colCount; cCnt++)
                {
                    var r = (range.Cells[rCnt, cCnt] as Excel.Range ).Value;
                    array[cCnt - 1] = (Convert.ToString((range.Cells[rCnt, cCnt] as Excel.Range).Value2));

                }

                dt.Rows.Add(array);
            }
            SeleniumElementSet.Tables.Add(dt);


            foreach (DataRow row in dt.Rows)
            {
                string name = row["Tax Year"].ToString();
                string description = row["Asmt Roll Type"].ToString();
                string icoFileName = row["iconFile"].ToString();
                string installScript = row["installScript"].ToString();
            }

            xlApp.Quit();
        }


    }
}
