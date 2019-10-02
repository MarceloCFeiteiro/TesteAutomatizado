using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TesteAutomatizado.Paginas
{
    public class FileUploaderPage : BasePage
    {
        public FileUploaderPage(IWebDriver driver) : base(driver) { }

        public void PreencheCampoDoArquivo(string nome)
        {
            IWebElement arquivo = driver.FindElement(By.Id("file-upload"));
            arquivo.SendKeys(nome);
        }

        public void ClickUpload()
        {
            IWebElement btnFileSubmit = driver.FindElement(By.Id("file-submit"));
            btnFileSubmit.Click();
        }

        public string UploadEfetuado()
        {
            IWebElement mensagem = driver.FindElement(By.XPath("//*[@id='content']/div/h3"));
            return mensagem.Text;
        }

        public string NomeArquivoPresente()
        {
            IWebElement nomeArquivo = driver.FindElement(By.Id("uploaded-files"));
            return nomeArquivo.Text;
        }

        public string UploadNaofetuado()
        {
            // wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            //IWebElement mensagem = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("body > h1")));
            // IWebElement mensagem = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("body > h1")));
            return "";
           // return mensagem.Text;
        }




    }
}
