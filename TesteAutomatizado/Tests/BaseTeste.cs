using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

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
            driver.Close();
            Console.WriteLine("Finalizando Teste");
        }

    }
}
