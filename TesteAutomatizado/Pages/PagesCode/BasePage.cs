using OpenQA.Selenium;
using System;

namespace TesteAutomatizado.Paginas
{
    /// <summary>
    /// Classe base para todas as páginas
    /// </summary>
    public class BasePage
    {
        public IWebDriver driver;
        private const int tempoDeEspera = 30;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Método responsável por maximixar a tela e navegar para a url especificada.
        /// </summary>
        /// <param name="url">URL que será aberta</param>
        public void NavegaParaPagina(string url)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(tempoDeEspera);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }
    }
}