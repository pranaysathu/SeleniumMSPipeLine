using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SelfService
{
    public class MyWorkSpacePage : DriverContainer
    {

        public void SelectWorkSpace(string workspaceName)
        {
            this.MyWorkspaceDropDown.Click();

            this.WorkSpace(workspaceName).Click();

        }

        public ReportsPage OpenReport(string reportName)
        {
            this.SearchInput.SendKeys(reportName);
            Thread.Sleep(2000);
            this.ReportsTab(reportName).Click();
            return new ReportsPage();
        }

        #region PageObjects
        public IWebElement MyWorkspaceDropDown => driver.FindElement(By.XPath(""));

        public IWebElement WorkSpace(string workspaceName) => driver.FindElement(By.XPath(""));

        public IWebElement ReportsTab(string reportName) => driver.FindElement(By.XPath(""));

        public IWebElement SearchInput => driver.FindElement(By.XPath(""));

        #endregion
    }
}
