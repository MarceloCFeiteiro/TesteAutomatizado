using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace TesteAutomatizado.SeleniumUtils
{
    /// <summary>
    /// Classe responsável por armazenar os métodos de comunicação com os elemenos da página.
    /// </summary>
    public static class SeleniumTools
    {
        private const int tempoDeEspera = 30;
        private static WebDriverWait espera = null;

        /// <summary>
        /// Método responsável por clicar em um elemento.
        /// </summary>
        /// <param name="driver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento a ser clicado.</param>
        public static void Clicar(IWebDriver driver, By referencia)
        {
            var elementoCarregado = EsperaElementoFicarClicavel(driver, referencia);
            elementoCarregado.Click();
        }

        /// <summary>
        /// Método responsável por clicar em um elemento através de um action.
        /// </summary>
        /// <param name="driver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento a ser clicado.</param>
        public static void ClicarAction(IWebDriver driver, By referencia)
        {
            var action = CriarAction(driver);
            var elementoCarregado = EsperaElementoFicarClicavel(driver, referencia);
            action.Click(elementoCarregado);
        }

        /// <summary>
        /// Método responsável por enviar um texto para o elemento.
        /// </summary>
        /// <param name="driver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento para onde o texto será enviado.</param>
        /// <param name="texto">Texto a ser inserido.</param>
        public static void EnviarTexto(IWebDriver driver, By referencia, string texto)
        {
            var elementoCarregado = EsperaElementoFicarClicavel(driver, referencia);
            elementoCarregado.SendKeys(texto);
        }

        /// <summary>
        /// Método responsável por enviar um texto para o elemento através de um action.
        /// </summary>
        /// <param name="driver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento para onde o texto será enviado.</param>
        /// <param name="texto">Texto a ser inserido.</param>
        public static void EnviarTextoAction(IWebDriver driver, By referencia, string texto)
        {
            var action = CriarAction(driver);
            var elementoCarregado = EsperaElementoFicarClicavel(driver, referencia);
            action.SendKeys(elementoCarregado, texto);
        }

        /// <summary>
        /// Método responsável por retornar o texto de um elemento.
        /// </summary>
        /// <param name="driver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento</param>
        /// <returns>Retorna o texto contido no atributo Text do elemento.</returns>
        public static string RetornaTexto(IWebDriver driver, By referencia)
        {
            var elementoCarregado = EsperaElementoExistir(driver, referencia);
            return elementoCarregado.Text;
        }

        /// <summary>
        /// Método responsável por selecinar um valor na combo.
        /// </summary>
        /// <param name="driver">Driver atual</param>
        /// <param name="referencia">Referência do elemento</param>
        /// <param name="valor">Valor a ser selecionado</param>
        public static void SelecionarValorCombo(IWebDriver driver, By referencia, string valor)
        {
            var elementoCarregado = EsperaElementoFicarClicavel(driver, referencia);
            var seletor = new SelectElement(elementoCarregado);
            seletor.SelectByValue(valor);
        }

        /// <summary>
        /// Método responsável por retornar uma lista de elementos.
        /// </summary>
        /// <param name="driver">Driver atual</param>
        /// <param name="referencia">Referência dos elementos</param>
        public static IEnumerable<IWebElement> CarregarListaElementos(IWebDriver driver, By referencia)
        {
            EsperaElementoFicarClicavel(driver, referencia);
            return driver.FindElements(referencia);
        }

        /// <summary>
        /// Método responsável por esperar elemento ficar clicável.
        /// </summary>
        /// <param name="driver">Driver atual.</param>
        /// <param name="referencia">Referência do elemento.</param>
        /// <returns>Retorna um elemento que pode ser clicado.</returns>
        private static IWebElement EsperaElementoFicarClicavel(IWebDriver driver, By referencia)
        {
            espera = new WebDriverWait(driver, TimeSpan.FromSeconds(tempoDeEspera));
            return espera.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(referencia));
        }

        /// <summary>
        /// Método responsávelpor esperar um elemento existir na página.
        /// </summary>
        /// <param name="driver">Diver atual.</param>
        /// <param name="referencia">Referência do elemento.</param>
        /// <returns>Retorna um elemento que já existe na página.</returns>
        private static IWebElement EsperaElementoExistir(IWebDriver driver, By referencia)
        {
            espera = new WebDriverWait(driver, TimeSpan.FromSeconds(tempoDeEspera));
            return espera.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(referencia));
        }

        /// <summary>
        /// Método responsável por criar uma nova Action
        /// </summary>
        /// <param name="driver">Driver atual</param>
        /// <returns>Retorna uma nova Actions</returns>
        private static Actions CriarAction(IWebDriver driver)
        {
            return new Actions(driver);
        }
    }
}
