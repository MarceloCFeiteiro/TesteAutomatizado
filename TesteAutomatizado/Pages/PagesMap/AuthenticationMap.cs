using OpenQA.Selenium;

namespace TesteAutomatizado.Pages.PagesMap
{
    /// <summary>
    /// Classe responsável por armazenar os elementos da página de login.
    /// </summary>
   public  class AuthenticationMap
    {
        /// <summary>Define o campo Email</summary>
        public readonly By InputEmail = By.Id("email");

        /// <summary>Define o campo Password</summary>
        public readonly By InputPassword = By.Id("passwd");

        /// <summary>Define o botão Sign in</summary>
        public readonly By BtnSignIn = By.Id("SubmitLogin");

    }
}
