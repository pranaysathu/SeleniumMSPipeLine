using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using WindowsInput;
using WindowsInput.Native;

namespace Framework
{
    public class DriverContainer
    {

        public static IWebDriver driver;
      // public static IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),new ChromeOptions().AddArguments("headless"));

        public static IWebDriver webDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");
             driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),options);

           

            driver.Navigate().GoToUrl("https://sdcountycagov.sharepoint.com/sites/ipts-dev/SitePages/Home.aspx");


            //emain .send 90

            //    next.clcik90;


            //driver.Manage().Window.Maximize();
            //Thread.Sleep(2000);
            //NavigateBrowser();
            //Thread.Sleep(10000);

            #region SelfServiceIntialize
            InputSimulator In = new InputSimulator();

            In.Keyboard.TextEntry("Username");
            In.Keyboard.KeyPress(VirtualKeyCode.TAB);
            In.Keyboard.TextEntry("Password");
            In.Keyboard.KeyPress(VirtualKeyCode.TAB);
            In.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(2000);
            #endregion

            return driver;
        }

        public static async Task NavigateBrowser()
        {
            await Task.Run(() =>
            {

               // driver.Url = "https://tbs.neudesic.com/";
               // driver.Manage().Window.Maximize();

            });
        }
    }
}
