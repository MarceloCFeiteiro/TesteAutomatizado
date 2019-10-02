using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace TesteAutomatizado.Paginas
{
    public class DataTablePage : BasePage
    {
        public DataTablePage(IWebDriver driver) : base(driver) { }

        public void DeletaItem()
        {
            IWebElement delete = driver.FindElement(By.XPath("//*[@id='table1']/tbody/tr[1]/td[6]/a[2]"));
            delete.Click();
        }

        public void EditaItem()
        {
            IWebElement delete = driver.FindElement(By.XPath("//*[@id='table1']/tbody/tr[1]/td[6]/a[1]"));
            delete.Click();
        }

        public void DeletaPorEmail(string email)
        {
            var linhas = driver.FindElements(By.CssSelector("table#table1 > tbody > tr"));

            for (int i = 0; i < linhas.Count; i++)
            {
                if (linhas[i].Text.Contains(email))
                {
                    IWebElement delete = driver.FindElement(By.XPath("//*[@id='table1']/tbody/tr[" + (i + 1) + "]/td[6]/a[2]"));
                    delete.Click();
                    break;
                }
            }
        }

        public bool VerificaSeEmailEstaNaTabela(string email)
        {
            var linhas = driver.FindElements(By.CssSelector("table#table1 > tbody > tr"));

            for (int i = 0; i < linhas.Count; i++)
            {
                if (linhas[i].Text.Contains(email))
                    return true;
            }
            return false;
        }

        public int QuantidadeLinhasTabela()
        {
            var linhas = driver.FindElements(By.CssSelector("table#table1 > tbody > tr"));

            var u = linhas[0].Text;

            return linhas.Count;
        }


    }
}
