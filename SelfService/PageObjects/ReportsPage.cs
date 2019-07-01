using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfService
{
    public class ReportsPage : DriverContainer
    {
        public string ReportEmbededMode()
        {
            this.Embeded.Click();
            var path=this.EmbededCodePath.Text;
            this.CloseEmbededPopUp.Click();
            return path;
        }

        #region PageObjects
        public IWebElement FileDropDown => driver.FindElement(By.XPath(""));

        public IWebElement ViewDropDown => driver.FindElement(By.XPath(""));

        public IWebElement EditReport => driver.FindElement(By.XPath(""));

        public IWebElement Save => driver.FindElement(By.XPath(""));

        public IWebElement SaveAs => driver.FindElement(By.XPath(""));

        public IWebElement Print => driver.FindElement(By.XPath(""));

        public IWebElement Embeded => driver.FindElement(By.XPath(""));

        public IWebElement ExportToPowerPoint => driver.FindElement(By.XPath(""));

        public IWebElement ExportToPDF => driver.FindElement(By.XPath(""));

        public IWebElement DownloadReport => driver.FindElement(By.XPath(""));

        public IWebElement EmbededCodePath => driver.FindElement(By.XPath(""));

        public IWebElement CloseEmbededPopUp => driver.FindElement(By.XPath(""));
        #endregion

    }
}
