using NUnit.Framework;
using TesteAutomatizado.Helpers;
using TesteAutomatizado.Pages;
using TesteAutomatizado.Pages.PagesCode;
using TesteAutomatizado.Testes;

namespace TesteAutomatizado.Tests
{
    public class WomenPageTest : BaseTeste
    {
        [Test]
        [Retry(2)]
        public void AdicionarItemNoCarrinho()
        {
            #region Arranje

            IndexPage index = new IndexPage(driver);
            AuthenticationPage login = new AuthenticationPage(driver);
            WomenPage womenPage = new WomenPage(driver);

            var User = ManipularArquivoHelper.LerDeUmArquivoQueEstaNoFormatoJson();

            #endregion Arranje

            #region Act

            index.NavegaParaPagina(Properties.Resource.UrlPrincipal);
            index.ClickBtnSign_in();
            login.PreencheCampoEmail(User.Email);
            login.PreencheCampoPassword(User.Password);
            login.ClickBtnSign_in();

            womenPage.NavegaParaAPaginaWomen();

            #endregion Act
        }
    }
}