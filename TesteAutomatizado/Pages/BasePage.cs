using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing.Imaging;

namespace TesteAutomatizado.Paginas
{
    public class BasePage
    {
        public IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavegaParaPagina(string url)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        public void PegarEvidencia()
        {
            Screenshot imagem = ((ITakesScreenshot)driver).GetScreenshot();
            imagem.SaveAsFile("C:/Screenshot.png", ScreenshotImageFormat.Png);
        }
    }
}
