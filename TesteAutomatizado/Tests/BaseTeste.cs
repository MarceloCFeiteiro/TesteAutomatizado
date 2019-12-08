using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TesteAutomatizado.Helpers;

namespace TesteAutomatizado.Testes
{
    public class BaseTeste
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void InicializaClasse()
        {
            CriaRelatorioHelper.CriaRelatorio(this.GetType().Name);

            ChromeOptions opt = new ChromeOptions();
            opt.AddArgument("--headless");
            driver = new ChromeDriver(opt);
        }

        [SetUp]
        public void Inicializar()
        {
            CriaRelatorioHelper.CriaTeste();
        }

        [TearDown]
        public void Finalizar()
        {
            CriaRelatorioHelper.FinalizaRelatorio(driver);
            driver.FindElement(By.CssSelector("div#header_logo>a>img")).Click();
        }

        [OneTimeTearDown]
        public void FinalizaClasse()
        {
            CriaRelatorioHelper.GravaNoArquivo();
            driver.Quit();
        }
    }
}