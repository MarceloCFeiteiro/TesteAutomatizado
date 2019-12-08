using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using TesteAutomatizado.Helpers;

namespace TesteAutomatizado.Testes
{
    public class BaseTeste
    {
        public IWebDriver driver;
        protected ExtentReports _extent;
        protected ExtentTest _test;

        [OneTimeSetUp]
        public void InicializaClasse()
        {
            try
            {
                string nomeSuite = this.GetType().Name;

                _extent = new ExtentReports();
                var dir = "C:";
                DirectoryInfo di = Directory.CreateDirectory(dir + "\\Test_Execution_Reports\\" + DateTime.Now.ToString("MM-yy") + "\\" + nomeSuite);
                var htmlReport = new ExtentHtmlReporter(di.FullName + "\\Autorização" + ".html");
                htmlReport.Config.EnableTimeline = false;
                _extent.AddSystemInfo(".NET C#", "Projeto de teste automatizado");
                _extent.AddSystemInfo("Usuário", "Marcelo");
                _extent.AttachReporter(htmlReport);
            }
            catch (Exception e)
            {
                throw (e);
            }

            ChromeOptions opt = new ChromeOptions();
            // opt.AddArgument("--headless");
            driver = new ChromeDriver(opt);
        }

        [SetUp]
        public void Inicializar()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void Finalizar()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        string screenShotPath = CapturaImagensHelpers.Capture(driver, TestContext.CurrentContext.Test.Name);
                        _test.Log(logstatus, "Test ended with " + logstatus + " – " + errorMessage);
                        _test.Log(logstatus, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        _test.Log(logstatus, "Test ended with " + logstatus);
                        break;
                    default:
                        logstatus = Status.Pass;
                        _test.Log(logstatus, "Test ended with " + logstatus);
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }


            driver.FindElement(By.CssSelector("div#header_logo>a>img")).Click();
        }

        [OneTimeTearDown]
        public void FinalizaClasse()
        {
            try
            {
                _extent.Flush();
            }
            catch (Exception e)
            {
                throw (e);
            }
            driver.Quit();
        }
    }
}