using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SelfService
{
    [TestFixture]
    public class BasicTests : TestBase
    {
        [Test]
        public void EmbedTest()
        {
            WorkSpavePageobj.SelectWorkSpace("IPTS Workspace");
            var Path = WorkSpavePageobj.OpenReport("reportName").ReportEmbededMode();
            driver.Navigate().GoToUrl(Path);
            SharePointPageobj.openReport();
        }
        
//TearDwon Step
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
