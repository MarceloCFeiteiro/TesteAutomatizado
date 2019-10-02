using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

namespace TesteAutomatizado.SeleniumUtils
{
    public static class SeleniumTools

    {
        public static WebDriverWait wait = null;
        public static void ClicarNoTexto(IWebDriver driver, By referencia)
        {
            var elementoCarregado = Waiter(driver, referencia);
            elementoCarregado.Click();
        }


        private static IWebElement Waiter(IWebDriver driver, By referencia)
        { 
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var elemento = driver.FindElement(referencia);
            return  wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elemento));
        }
    }
}
