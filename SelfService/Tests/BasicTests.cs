using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework
{
    [TestFixture]
    public class BasicTests : TestBase
    {
        [Test]
        public void FrameworkTest()
        {
            var driver = this.driver;
            //int a = 5 + 9;
            //Thread.Sleep(5000);
            //pageclassobj.element.Click();
            //Thread.Sleep(10000);
        }

        

        [TearDown]
        public void TearDwo()
        {
            driver.Quit();
        }
    }
}
