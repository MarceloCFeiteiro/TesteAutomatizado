using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace TesteAutomatizado.Testes
{
    public class BaseTeste
    {
        public IWebDriver driver;

        [SetUp]
        public void Inicializar()
        {
            ChromeOptions opt = new ChromeOptions();
           // opt.AddArgument("--headless");
            driver = new ChromeDriver(opt);
            Console.WriteLine("Abrindo url");
        }

        [TearDown]
        public void CleanUp()
        {                     
            PegarEvidencia();
            Console.WriteLine("Finalizando Teste depois de salvar a imagem");
            Console.WriteLine("teste de merge");
            driver.Close();
        }


        public void PegarEvidencia()
        {
            string pastaParaSalvar = @"C:\imagens";


            Screenshot imagem = ((ITakesScreenshot)driver).GetScreenshot();

            if (!Directory.Exists(pastaParaSalvar))
            {
                Directory.CreateDirectory(pastaParaSalvar);
            }

            imagem.SaveAsFile(@"C:\imagens\Screenshot.png", ScreenshotImageFormat.Png);
        }

    }
}
