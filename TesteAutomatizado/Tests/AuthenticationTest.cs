using NUnit.Framework;
using TesteAutomatizado.Pages;
using TesteAutomatizado.Testes;
using Faker.Extensions;

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


            Faker.Name.FullName
            


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
            Assert.AreEqual(login.RetornaTextoDaMensagem(), "Authentication failedef.", "Mensagem com erro para simular uma falha");
            #endregion
        }

    }
}
