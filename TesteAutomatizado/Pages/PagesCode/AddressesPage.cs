﻿using OpenQA.Selenium;
using TesteAutomatizado.Pages.PagesMap;
using TesteAutomatizado.Paginas;
using TesteAutomatizado.SeleniumUtils;

namespace TesteAutomatizado.Pages.PagesCode
{
    /// <summary>
    /// Classe responsável por armazenar os métodos da página AddressesPage.
    /// </summary>
    public class AddressesPage : BasePage
    {
        /// <summary>
        /// Atributo responsável por armazenar uma referência para a classe AddressesMap.
        /// </summary>
        private readonly AddressesMap addressesMap = new AddressesMap();

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="driver"></param>
        public AddressesPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Método responsável por continuar para o checkout
        /// </summary>
        /// <param name="webDriver"></param>
        public void ContinuarCheckout()
        {
            SeleniumTools.Clicar(driver, addressesMap.ButtonProceedToCheckout);
        }
    }
}