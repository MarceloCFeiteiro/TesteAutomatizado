using OpenQA.Selenium;
using TesteAutomatizado.Paginas;

namespace TesteAutomatizado.Testes
{
    public class AuthenticationPage : BasePage
    {
        public AuthenticationPage(IWebDriver driver) : base(driver) { }

        public void PreencheCampoNome(string nome)
        {
            IWebElement Username = driver.FindElement(By.Id("username"));
            Username.SendKeys(nome);
        }

        public void PreencheCampoPassword(string password)
        {
            IWebElement Password = driver.FindElement(By.Id("password"));
            Password.SendKeys(password);
        }

        public void Click()
        {
            IWebElement btnLogin = driver.FindElement(By.ClassName("radius"));
            btnLogin.Click();
        }

        public string LoginEfetuadocomSucesso()
        {
            IWebElement texto = driver.FindElement(By.Id("flash"));
            return FormatString(texto.Text);
        }

        private string FormatString(string text)
        {
            return text = text.Replace("\r", "").Replace("\n", "").Replace("×", "");
        }


    }
}
