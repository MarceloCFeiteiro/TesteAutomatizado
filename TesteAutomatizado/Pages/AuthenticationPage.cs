using OpenQA.Selenium;
using TesteAutomatizado.Pages.PagesMap;
using TesteAutomatizado.Paginas;

namespace TesteAutomatizado.Testes
{
    public class AuthenticationPage : BasePage
    {
        private readonly AuthenticationMap authenticationMap = new AuthenticationMap();

        public AuthenticationPage(IWebDriver driver) : base(driver) { }

        public void PreencheCampoEmail(string nome)
        {
            IWebElement Username = driver.FindElement(authenticationMap.InputEmail);
            Username.SendKeys(nome);
        }


        public void PreencheCampoPassword(string password)
        {
            IWebElement Password = driver.FindElement(authenticationMap.InputPassword);
            Password.SendKeys(password);
        }

        public void ClickBtnSingin()
        {
            IWebElement btnLogin = driver.FindElement(authenticationMap.BtnSignIn);
            btnLogin.Click();
        }

        public string ValidaMensagemDeFalha()
        {
            IWebElement texto = driver.FindElement(authenticationMap.Alerta);
            return texto.Text;
           // return FormatString(texto.Text);
        }

        private string FormatString(string text)
        {
            return text = text.Replace("\r", "").Replace("\n", "").Replace("×", "");
        }


    }
}
