using OpenQA.Selenium;
using System;
using System.IO;

namespace TesteAutomatizado.Helpers
{
    public static class CapturaImagensHelper
    {
        public static string Capture(IWebDriver driver, string screenShotName)
        {
            string localpath = "";
            try
            {
                ITakesScreenshot ts = (ITakesScreenshot)driver;
                Screenshot screenshot = ts.GetScreenshot();
                var dir = "C:";
                DirectoryInfo di = Directory.CreateDirectory(dir + "\\Imagens_capturadas\\" + DateTime.Now.ToString("MM-yy"));
                string finalpth = di.FullName + "\\" + screenShotName + DateTime.Now.ToString("hh-mm-ss") + ".png";
                localpath = new Uri(finalpth).LocalPath;
                screenshot.SaveAsFile(localpath);
            }
            catch (Exception e)
            {
                throw (e);
            }
            return localpath;
        }
    }

}
