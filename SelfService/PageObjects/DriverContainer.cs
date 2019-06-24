using System;
using System.Collections.Generic;
using System.Linq;
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
       public static IWebDriver driver = new ChromeDriver();

        public static IWebDriver webDriver()
        {
            driver.Navigate().GoToUrl("https://www.jetbrains.com/teamcity/");

            driver.Manage().Window.Maximize();

            //#region SelfServiceIntialize
            //InputSimulator In = new InputSimulator();

            //In.Keyboard.TextEntry("Username");
            //In.Keyboard.KeyPress(VirtualKeyCode.TAB);
            //In.Keyboard.TextEntry("Password");
            //In.Keyboard.KeyPress(VirtualKeyCode.TAB);
            //In.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            //Thread.Sleep(2000);
            //#endregion

            return driver;
        }

        public static async Task NavigateBrowser()
        {
            await Task.Run(() =>
            {

                driver.Url = "https://tbs.neudesic.com/";
                driver.Manage().Window.Maximize();

            });
        }
    }
}
