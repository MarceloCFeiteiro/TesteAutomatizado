using NUnit.Framework;
using System;
using TesteAutomatizado.Testes;


namespace TesteAutomatizado
{
    public class AuthenticationTest : BaseTeste
    {

        [Test]
        [Retry(2)]
        public void LoginComUsuarioEPasswordCorretos()
        {
            Console.WriteLine("Executando teste");

            AuthenticationPage login = new AuthenticationPage(driver);
            login.NavegaParaPagina(Properties.Resource.URL);
            login.PreencheCampoNome("tomsmith");
            login.PreencheCampoPassword("SuperSecretPassword!");
            login.Click();

            #region Assert
            Assert.AreEqual(login.LoginEfetuadocomSucesso(), "You logged into a secure area!");
            #endregion
        }

    }
}
