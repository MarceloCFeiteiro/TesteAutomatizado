using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace TesteAutomatizado.Pages.PagesMap
{
    public class NotificationMessageMap //tem que herdar de alguma classe
    {
        public readonly By link = By.CssSelector("p>a");

        public readonly By mensagem = By.Id("flash");
    }
}
