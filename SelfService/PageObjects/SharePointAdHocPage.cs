using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfService
{
    public class SharePointAdHocPage : DriverContainer
    {
        public void openReport()
        {
            this.Adhoc.Click();
        }

        #region PageObjects
        public IWebElement Adhoc => driver.FindElement(By.XPath(""));
        #endregion
    }
}
