using NUnit.Framework;
using System.Collections.Generic;
using TesteAutomatizado.Helpers;
using TesteAutomatizado.Pages;
using TesteAutomatizado.Testes;

namespace TesteAutomatizado
{
    public class AuthenticationTest : BaseTeste
    {
        [Test]
        [Retry(2)]
        public void LoginComUsuarioEPasswordCorretos()
        {
            #region Arranje
            IndexPage index = new IndexPage(driver);
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            AuthenticationPage login = new AuthenticationPage(driver);
            #endregion

            #region Act
            index.NavegaParaPagina(Properties.Resource.UrlPrincipal);
            index.ClickBtnSign_in();
            login.PreencheCampoEmail("automatizado@test.com.br");
            login.PreencheCampoPassword("aaa123");
            login.ClickBtnSign_in();
            #endregion

            #region Assert
            Assert.AreEqual(myAccountPage.RetornaTextoDaMensagem(), "MY ACCOUNT");
            #endregion

            #region Finalization
            index.ClickBtnSign_Out();
            #endregion

        }

        [Test]
        [Retry(2)]
        public void LoginComUsuarioEPasswordIncorretos()
        {
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
            Assert.AreEqual(login.RetornaTextoDaMensagem(), "Authentication failed.", "Mensagem com erro para simular uma falha");
            #endregion
        }

        [Test]
        [Retry(2)]
        public void ValidarMensagemNaoInformacaoDosCamposDeCadastro()
        {
            #region Arranje
            AuthenticationPage login = new AuthenticationPage(driver);
            var usuario = GeneratorHelper.GerarUsuario();
            var listaErros = new List<string> { "You must register at least one phone number.",
                                                "lastname is required.",
                                                "firstname is required.",
                                                "passwd is required.",
                                                "address1 is required.",
                                                "city is required.",
                                                "The Zip/Postal code you've entered is invalid. It must follow this format: 00000",
                                                "This country requires you to choose a State."};
            #endregion

            #region Act
            login.NavegaParaPagina(Properties.Resource.UrlAuthentication);
            login.PreencheCampoEmailCreateAccount(usuario.Email);
            login.ClickBtnCreateAccount();
            login.ClickBtnRegisterAnAccount();
            #endregion

            #region Assert
            Assert.AreEqual(login.RetornaMensagemCampoRequerido(), "*Required field", "A mensagem esta diferente do esperado.");
            var listaErrosPagina = login.RetornaListadeErros();
            for (int i = 0; i < listaErros.Count; i++)
            {
                listaErros[i].Equals(listaErrosPagina[i]);
            }
            #endregion
        }

        [Test]
        [Retry(1)]
        public void ValidarCadastroDeUsuario()
        {
            #region Arranje
            AuthenticationPage login = new AuthenticationPage(driver);
            MyAccountPage myAccount = new MyAccountPage(driver);
            var usuario = GeneratorHelper.GerarUsuario();
            #endregion

            #region Act
            login.NavegaParaPagina(Properties.Resource.UrlAuthentication);
            login.PreencheCampoEmailCreateAccount(usuario.Email);
            login.ClickBtnCreateAccount();
            login.PreecherDadosUsuario(usuario);
            login.ClickBtnRegisterAnAccount();
            #endregion

            #region Assert
            Assert.AreEqual(myAccount.RetornaTextoDaMensagem(), "MY ACCOUNT", "Não foi encontrado o texto referente a pagina My account");
            Assert.AreEqual(myAccount.RetornaNomeDoUsuarioDaPagina(), usuario.NomeCompleto, "O nome do usuário esta diferente do esperado");
            #endregion

        }
    }
}
