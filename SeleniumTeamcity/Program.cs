using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;
using Framework;

namespace SeleniumTeamcity
{
    [TestFixture]
    public class Program
    {
        static IWebDriver dr = new ChromeDriver();
        //[Test]
        public static void Main(string[] args)
        {
            NavigateBrowser();
            Thread.Sleep(10000);
                       
            InputSimulator In = new InputSimulator();

            In.Keyboard.TextEntry("Username");
            In.Keyboard.KeyPress(VirtualKeyCode.TAB);
            In.Keyboard.TextEntry("Password");
            In.Keyboard.KeyPress(VirtualKeyCode.TAB);
            In.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            Thread.Sleep(2000);

            dr.Quit();
        }

        public static async Task NavigateBrowser()
        {
            await Task.Run(() =>
            {

                dr.Url = "https://tbs.neudesic.com/";
                dr.Manage().Window.Maximize();

            });
        }


        [Test]
        public void test()
        {

            IWebDriver driver = new ChromeDriver();


            driver.Navigate().GoToUrl("https://www.jetbrains.com/teamcity/");

            driver.Manage().Window.Maximize();

            Thread.Sleep(10000);

//            var r = driver.SessionId().ToString();

            driver.Quit();
        }

        [Test]
        public void RemoteWebDriverTest()
        {
           
            // var driverReUse = new ReuseRemoteWebDriver(new Uri("http://localhost:9515"), DriveInfo.SessionId.ToString());
            //driverReUse.Url = "http://tarunlalwani.com";
            // Console.WriteLine(driverReUse.Url);
        }


        [SetUp]
        public void MyTestInitialize()
        {
            IWebDriver WebDriver = null;
            if (ConfigurationManager.AppSettings["UseChromeDebugging"] == "true")
            {
                DesiredCapabilities des = new DesiredCapabilities();
                var pr = Process.GetProcessesByName("chromedriver");
                if (pr.Length > 0)
                {
                    CustomRemoteWebDriver.newSession = false;

                    var r =des.BrowserName;
                    var driver = new CustomRemoteWebDriver(new Uri("http://localhost:9515"),des);
                    WebDriver = driver;
                }

                else
                {
                    Process.Start(ConfigurationManager.AppSettings["ChromeDriverPath"]);
                    CustomRemoteWebDriver.newSession = true;
                    var driver = new CustomRemoteWebDriver(new Uri("http://localhost:9515"), des);
                    WebDriver = driver;

                }
            }

            else
            {
                //normal execution
                WebDriver = new ChromeDriver();
            }


        }


        public static Uri GetExecutorURLFromDriver(OpenQA.Selenium.Remote.RemoteWebDriver driver)
        {
            var executorField = typeof(OpenQA.Selenium.Remote.RemoteWebDriver)
                .GetField("executor",
                          System.Reflection.BindingFlags.NonPublic
                          | System.Reflection.BindingFlags.Instance);

            object executor = executorField.GetValue(driver);

            var internalExecutorField = executor.GetType()
                .GetField("internalExecutor",
                          System.Reflection.BindingFlags.NonPublic
                          | System.Reflection.BindingFlags.Instance);
            object internalExecutor = internalExecutorField.GetValue(executor);

            //executor.CommandInfoRepository
            var remoteServerUriField = internalExecutor.GetType()
                .GetField("remoteServerUri",
                          System.Reflection.BindingFlags.NonPublic
                          | System.Reflection.BindingFlags.Instance);
            var remoteServerUri = remoteServerUriField.GetValue(internalExecutor) as Uri;

            return remoteServerUri;
        }
    }


    public class FrameowrkTests
    {

    }
}


public class ReuseRemoteWebDriver : OpenQA.Selenium.Remote.RemoteWebDriver
{
    private String _sessionId;

    public ReuseRemoteWebDriver(Uri remoteAddress, String sessionId)
        : base(remoteAddress, new DesiredCapabilities())
    {
        this._sessionId = sessionId;
        var sessionIdBase = this.GetType()
            .BaseType
            .GetField("sessionId",
                      System.Reflection.BindingFlags.Instance |
                      System.Reflection.BindingFlags.NonPublic);
        sessionIdBase.SetValue(this, new OpenQA.Selenium.Remote.SessionId(sessionId));
    }

    protected override OpenQA.Selenium.Remote.Response
        Execute(string driverCommandToExecute, System.Collections.Generic.Dictionary<string, object> parameters)
    {
        if (driverCommandToExecute == OpenQA.Selenium.Remote.DriverCommand.NewSession)
        {
            var resp = new OpenQA.Selenium.Remote.Response();
            resp.Status = OpenQA.Selenium.WebDriverResult.Success;
            resp.SessionId = this._sessionId;
            resp.Value = new System.Collections.Generic.Dictionary<String, Object>();
            return resp;
        }
        var respBase = base.Execute(driverCommandToExecute, parameters);
        return respBase;
    }


}

public class CustomRemoteWebDriver : RemoteWebDriver
{
    public static bool newSession = false;
    public static string capPath = @"c:\automation\sessionCap";
    public static string sessiondIdPath = @"c:\automation\sessionid";

    public CustomRemoteWebDriver(Uri remoteAddress, DesiredCapabilities desiredCapabilities)
        : base(remoteAddress, desiredCapabilities)
    {


    }




    /// 

    /// Store for the name property.
    /// 
    /// A  value representing the command to execute.
    /// A  containing the names and values of the parameters of the command.
    /// 
    /// A  containing information about the success or failure of the command and any data returned by the command.
    /// 
    protected override Response Execute(string driverCommandToExecute, Dictionary<string, object> parameters)
    {
        if (driverCommandToExecute == DriverCommand.NewSession)
        {
            if (!newSession)
            {

                var sidText = File.ReadAllText(sessiondIdPath);


                return new Response
                {
                    SessionId = sidText,

                };
            }
            else
            {
                var response = base.Execute(driverCommandToExecute, parameters);

                File.WriteAllText(sessiondIdPath, response.SessionId);
                return response;
            }
        }
        else
        {
            var response = base.Execute(driverCommandToExecute, parameters);
            return response;
        }
    }
}

/*

static IWebDriver dr = new ChromeDriver(@"C:\Code\Teletracking_sprint18\");
static void Main(string[] args)
{

    AutoItX3 autoit = new AutoItX3();
    Console.WriteLine("csons1");
    NavigateBrowser();
    Thread.Sleep(3000);
    Console.WriteLine("After hitting URL");

    InputSimulator In = new InputSimulator();

    In.Keyboard.TextEntry("Pranay.sathu@neudesic.com");
    In.Keyboard.KeyPress(VirtualKeyCode.TAB);
    In.Keyboard.TextEntry("Uzumaki55$");
    In.Keyboard.KeyPress(VirtualKeyCode.TAB);
    In.Keyboard.KeyPress(VirtualKeyCode.RETURN);
    Thread.Sleep(2000);

    dr.Manage().Window.Maximize();


    //Hours entry

    dr.FindElement(By.Id("BodyPlaceHolder_txtEntryHours")).SendKeys("8");
    dr.FindElement(By.Id("BodyPlaceHolder_txtEntryProjectTaskName")).SendKeys("Microsoft Assignment");
    dr.FindElement(By.Id("BodyPlaceHolder_txtEntryDescription")).SendKeys("Microsoft Assignment (Project Activities)");
    Thread.Sleep(1000);
    In.Keyboard.KeyPress(VirtualKeyCode.TAB);
    In.Keyboard.KeyPress(VirtualKeyCode.RETURN);

    Thread.Sleep(5000);
    dr.Quit();
}

    */
