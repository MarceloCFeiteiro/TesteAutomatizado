using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TesteAutomatizado.Testes;


namespace TesteAutomatizado
{
    public class Program
    {
        public IWebDriver driver;


        [SetUp]
        public void Inicialize()
        {
            driver = new ChromeDriver();            
            Console.WriteLine("Abrindo url");
        }

        [Test]
        public void LoginComUsuarioEPasswordCorretos()
        {
            Console.WriteLine("Executando teste");

            LoginPage login = new LoginPage(driver);
            login.NavagaParaPagina();
            login.PreencheCampoNome("tomsmith");
            login.PreencheCampoPassword("SuperSecretPassword!");
            login.Click();

            #region Assert
            Assert.AreEqual(login.LoginEfetuadocomSucesso(),"You logged into a secure area!");
            Assert.AreNotEqual(login.LoginEfetuadocomSucesso(), "Your password is invalid!");
            Assert.AreNotEqual(login.LoginEfetuadocomSucesso(), "Your username is invalid!");
            #endregion
            Console.WriteLine("Executando teste");
        }

        [Test]
        public void LoginComUsuarioCorretoEPassordIncorreto()
        {
            Console.WriteLine("Executando teste");

            LoginPage login = new LoginPage(driver);
            login.NavagaParaPagina();
            login.PreencheCampoNome("tomsmith");
            login.PreencheCampoPassword("qualquercoisatest!");
            login.Click();

            #region Assert
            Assert.AreNotEqual(login.LoginEfetuadocomSucesso(), "You logged into a secure area!");
            Assert.AreEqual(login.LoginEfetuadocomSucesso(), "Your password is invalid!");
            Assert.AreNotEqual(login.LoginEfetuadocomSucesso(), "Your username is invalid!");
            #endregion
            Console.WriteLine("Executando teste");
        }

        [Test]
        public void LoginComUsuarioIncorretoEPassordCorreto()
        {
            Console.WriteLine("Executando teste");

            LoginPage login = new LoginPage(driver);
            login.NavagaParaPagina();
            login.PreencheCampoNome("Marcelo");
            login.PreencheCampoPassword("SuperSecretPassword!");
            login.Click();

            #region Assert
            Assert.AreNotEqual(login.LoginEfetuadocomSucesso(), "You logged into a secure area!");
            Assert.AreNotEqual(login.LoginEfetuadocomSucesso(), "Your password is invalid!");
            Assert.AreEqual(login.LoginEfetuadocomSucesso(), "Your username is invalid!");
            #endregion
            Console.WriteLine("Executando teste");
        }

        [TearDown]
        public void CleanUp()
        {

            driver.Close();
            Console.WriteLine("Finalizando Teste");
        }


    }
}
