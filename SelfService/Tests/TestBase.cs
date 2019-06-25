using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
<<<<<<< HEAD
{
    /// <summary>
    /// Basic Test for TestBase
    /// </summary>
=======
{    
>>>>>>> 4e253dfcbfa9f5e508a06f0b42b14ab46d39432a
    public class TestBase
    {
        public IWebDriver driver = DriverContainer.webDriver();
        private Pageclass pageClass;
        //Getewy for Pageclass
        public Pageclass pageclassobj
        {
            get
            {
                return new Pageclass();
            }
        }
    }
}
