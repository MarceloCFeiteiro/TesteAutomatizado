using NUnit.Framework;
using System;
using TesteAutomatizado.Paginas;
using TesteAutomatizado.Testes;

namespace TesteAutomatizado
{
    public class TestUploadArquivo : BaseTeste
    {
        public string url = "http://the-internet.herokuapp.com/upload";



        [Test, Retry(2)]

        public void CarregaOArquivoCorretamente()
        {
            Console.WriteLine("Executando teste");

            FileUploaderPage fileUploaderPage = new FileUploaderPage(driver);
            fileUploaderPage.NavegaParaPagina(url);
            fileUploaderPage.PreencheCampoDoArquivo(@"C:\Users\Eshi\Desktop\teste.txt");
            fileUploaderPage.ClickUpload();

            #region Asserts
            Assert.AreEqual(fileUploaderPage.UploadEfetuado(), "File Uploaded!");
            Assert.AreEqual(fileUploaderPage.NomeArquivoPresente(), "teste.txt");
            #endregion

        }


        [Test]
        [Retry(2)]
        public void ClickEmSubmitSemEscolharArquivo()
        {
            Console.WriteLine("Executando teste");

            FileUploaderPage fileUploaderPage = new FileUploaderPage(driver);
            fileUploaderPage.NavegaParaPagina(url);
            fileUploaderPage.ClickUpload();

            #region Assert 
            Assert.AreEqual(fileUploaderPage.UploadNaofetuado(), "Internal Server Error");
            #endregion
        }

    }
}
