using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class Pageclass : DriverContainer
    {
        //IWebDriver driver = webDriver();


        public IWebElement element => driver.FindElement(By.XPath("//*[@class='header-secondary__title']"));
    }
}
