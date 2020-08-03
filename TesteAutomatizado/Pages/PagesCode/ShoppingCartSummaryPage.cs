﻿using OpenQA.Selenium;
using TesteAutomatizado.Pages.PagesMap;
using TesteAutomatizado.Paginas;
using TesteAutomatizado.SeleniumUtils;

namespace TesteAutomatizado.Pages.PagesCode
{
    /// <summary>
    /// Classe responsável por armazenar os métodos da página ShoppingCartSummary.
    /// </summary>
    public class ShoppingCartSummaryPage : BasePage
    {
        /// <summary>
        /// Atributo responsável por armazenar uma referência para a classe ShoppingCartSummaryMap.
        /// </summary>
        private readonly ShoppingCartSummaryMap shoppingCartSummaryMap = new ShoppingCartSummaryMap();

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="driver">Driver atual.</param>
        public ShoppingCartSummaryPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Método responsável por continuar para o checkout
        /// </summary>
        /// <param name="webDriver"></param>
        public void ContinuarCheckout(IWebDriver webDriver)
        {
            SeleniumTools.Clicar(webDriver, shoppingCartSummaryMap.ButtonProceedToCheckout);
        }
    }
}