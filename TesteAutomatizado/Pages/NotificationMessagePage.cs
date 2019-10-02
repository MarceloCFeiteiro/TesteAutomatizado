using OpenQA.Selenium;
using TesteAutomatizado.Pages.PagesMap;
using TesteAutomatizado.SeleniumUtils;
namespace TesteAutomatizado.Paginas
{
    public class NotificationMessagePage : BasePage
    {
        NotificationMessageMap massegeMap = new NotificationMessageMap();

        public NotificationMessagePage(IWebDriver driver) : base(driver) { }

        public object Properties { get; private set; }

        public void ClickNoLink()
        {
            Txt.ClicarNoTexto(driver, massegeMap.link);
        }

        public string PegaMensagem()
        {
            IWebElement mensagem = driver.FindElement(massegeMap.mensagem);
            return FormatString(mensagem.Text);
        }

        private string FormatString(string text)
        {
            return text = text.Replace("\r", "").Replace("\n", "").Replace("×", "");
        }
    }
}
