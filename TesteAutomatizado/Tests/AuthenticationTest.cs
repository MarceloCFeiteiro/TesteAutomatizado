﻿using NUnit.Framework;
using System;
using TesteAutomatizado.Testes;


namespace TesteAutomatizado
{
    public class AuthenticationTest : BaseTeste
    {
        [Test]
        [Retry(2)]
        public void LoginComUsuarioEPasswordIncorretos()
        {
            Console.WriteLine("Executando teste");

            #region Arranje
            AuthenticationPage login = new AuthenticationPage(driver);
            #endregion

            #region Act
            login.NavegaParaPagina(Properties.Resource.UrlAuthentication);
            login.PreencheCampoEmail("Email@Email.com.br");
            login.PreencheCampoPassword("SuperSecretPassword!");
            login.ClickBtnSign_in();
            #endregion

            #region Assert
            Assert.AreEqual(login.RetornaTextoDaMensagem(), "Authentication failed.");
            #endregion
        }

        [Test]
        [Retry(1)]
        public void LoginComUsuarioEPasswordIncorretosFail()
        {
            Console.WriteLine("Executando teste");

            #region Arranje
            AuthenticationPage login = new AuthenticationPage(driver);
            #endregion

            #region Act
            login.NavegaParaPagina(Properties.Resource.UrlAuthentication);
            login.PreencheCampoEmail("Email@Email.com.br");
            login.PreencheCampoPassword("SuperSecretPassword!");
            login.ClickBtnSign_in();
            #endregion

            #region Assert
            Assert.AreEqual(login.RetornaTextoDaMensagem(), "Authentication failedef.");
            #endregion
        }

    }
}
