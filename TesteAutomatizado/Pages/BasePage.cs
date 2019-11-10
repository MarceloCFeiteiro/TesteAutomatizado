using OpenQA.Selenium;
using System;

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
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

    }
}
