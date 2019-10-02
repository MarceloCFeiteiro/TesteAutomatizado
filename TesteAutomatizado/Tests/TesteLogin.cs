using NUnit.Framework;
using System;
using TesteAutomatizado.Testes;


namespace TesteAutomatizado
{
    public class TesteLogin : BaseTeste
    {
        public string url = "http://the-internet.herokuapp.com/login";

        [Test]
        [Retry(2)]
        public void LoginComUsuarioEPasswordCorretos()
        {
            Console.WriteLine("Executando teste");

            LoginPage login = new LoginPage(driver);
            login.NavegaParaPagina(url);
            login.PreencheCampoNome("tomsmith");
            login.PreencheCampoPassword("SuperSecretPassword!");
            login.Click();

            #region Assert
            Assert.AreEqual(login.LoginEfetuadocomSucesso(), "You logged into a secure area!");
            #endregion
        }

        [Test]
        [Retry(2)]
        public void LoginComUsuarioCorretoEPassordIncorreto()
        {
            Console.WriteLine("Executando teste");

            LoginPage login = new LoginPage(driver);
            login.NavegaParaPagina(url);
            login.PreencheCampoNome("tomsmith");
            login.PreencheCampoPassword("qualquercoisatest!");
            login.Click();

            #region Assert
            Assert.AreEqual(login.LoginEfetuadocomSucesso(), "Your password is invalid!");
            #endregion
        }

        [Test]
        [Retry(2)]
        public void LoginComUsuarioIncorretoEPassordCorreto()
        {
            Console.WriteLine("Executando teste");

            LoginPage login = new LoginPage(driver);
            login.NavegaParaPagina(url);
            login.PreencheCampoNome("Marcelo");
            login.PreencheCampoPassword("SuperSecretPassword!");
            login.Click();

            #region Assert
            Assert.AreEqual(login.LoginEfetuadocomSucesso(), "Your username is invalid!");
            #endregion
        }

        [Test]
        [Retry(2)]
        public void LoginUsuarioComCaractereEspecial()
        {
            Console.WriteLine("Executando teste");

            LoginPage login = new LoginPage(driver);
            login.NavegaParaPagina(url);
            login.PreencheCampoNome("tomsmit@");
            login.PreencheCampoPassword("SuperSecretPassword!");
            login.Click();

            #region Assert
            Assert.AreEqual(login.LoginEfetuadocomSucesso(), "Your username is invalid!");
            #endregion
        }

        [Test]
        [Retry(2)]
        public void LoginComUsuarioEmBranco()
        {
            Console.WriteLine("Executando teste");

            LoginPage login = new LoginPage(driver);
            login.NavegaParaPagina(url);
            login.PreencheCampoPassword("SuperSecretPassword!");
            login.Click();

            #region Assert
            Assert.AreEqual(login.LoginEfetuadocomSucesso(), "Your username is invalid!");
            #endregion
        }

        [Test]
        [Retry(2)]
        public void LoginComPasswordEmBranco()
        {
            Console.WriteLine("Executando teste");

            LoginPage login = new LoginPage(driver);
            login.NavegaParaPagina(url);
            login.PreencheCampoNome("tomsmith");
            login.Click();

            #region Assert
            Assert.AreEqual(login.LoginEfetuadocomSucesso(), "Your password is invalid!");
            #endregion
        }

    }
}
