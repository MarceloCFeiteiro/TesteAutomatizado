using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TesteAutomatizado.SeleniumUtils
{
    /// <summary>
    /// Classe responsável por armazenar os métodos de comunicação com oa elemenos da página
    /// </summary>
    public static class SeleniumTools

    {
        private static WebDriverWait espera = null;

        /// <summary>
        /// Método responsável por clicar em um elemento.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="referencia"></param>
        public static void Clicar(IWebDriver driver, By referencia)
        {
            var elementoCarregado = EsperaElementoFicarClicavel(driver, referencia);
            elementoCarregado.Click();
        }

        /// <summary>
        /// Método responsável por enviar um texto para o elemento.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="referencia"></param>
        /// <param name="texto"></param>
        public static void EnviarTexto(IWebDriver driver, By referencia, string texto)
        {
            var elementoCarregado = EsperaElementoFicarClicavel(driver, referencia);
            elementoCarregado.SendKeys(texto);
        }

        /// <summary>
        /// Método responsável por esperar elemento ficar clicavél.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="referencia"></param>
        /// <returns></returns>
        private static IWebElement EsperaElementoFicarClicavel(IWebDriver driver, By referencia)
        {
            espera = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var elemento = driver.FindElement(referencia);
            return espera.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elemento));
        }
    }
}
