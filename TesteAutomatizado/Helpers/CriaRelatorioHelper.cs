using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;

namespace TesteAutomatizado.Helpers
{
    public static class CriaRelatorioHelper
    {
        public static ExtentReports _extent;
        public static ExtentTest _test;

        public static  void CriaRelatorio(string nomeSuite)
        {
            try
            {
                _extent = new ExtentReports();
                var dir = "C:";
                DirectoryInfo di = Directory.CreateDirectory(dir + "\\Test_Execution_Reports\\" + DateTime.Now.ToString("MM-yy") + "\\" + nomeSuite);
                var htmlReport = new ExtentHtmlReporter(di.FullName + "\\Autorização" + ".html");
                htmlReport.Config.EnableTimeline = false;
                _extent.AddSystemInfo(".NET C#", "Projeto de teste automatizado");
                _extent.AddSystemInfo("Usuário", "Marcelo");
                _extent.AttachReporter(htmlReport);
            }
            catch(Exception )
            {
                throw new Exception($"Não foi possível criar o relatorio da suite {nomeSuite}");
            }
        }

        public static void FinalizaRelatorio(IWebDriver driver)
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
                        string screenShotPath = CapturaImagensHelper.Capture(driver, TestContext.CurrentContext.Test.Name);
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
            catch (Exception)
            {
                throw new Exception("Não foi possível finalizar o relatótio");
            }
        }

        public static void CriaTeste()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        public static void GravaNoArquivo()
        {
            try
            {
                _extent.Flush();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível gravar no arquivo");
            }
           
        }
    }
}
