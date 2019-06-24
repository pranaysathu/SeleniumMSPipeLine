using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class TestBase
    {
        public IWebDriver driver = DriverContainer.webDriver();
        private Pageclass pageClass;
        public Pageclass pageclassobj
        {
            get
            {
                return new Pageclass();
            }
        }
    }
}
