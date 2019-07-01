using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfService
{
    /// <summary>
    /// Basic Test for TestBase
    /// </summary>
    
    public class TestBase
    {
        public IWebDriver driver = DriverContainer.webDriver();      

        private MyWorkSpacePage workSpacePageClass;

        public MyWorkSpacePage WorkSpavePageobj
        {
            get
            {
                return new MyWorkSpacePage();
            }
        }

        private SharePointAdHocPage sharePointPage;

        public SharePointAdHocPage SharePointPageobj
        {
            get
            {
                return new SharePointAdHocPage();
            }
        }
    }
}
