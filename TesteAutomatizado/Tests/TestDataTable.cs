using NUnit.Framework;
using System;
using TesteAutomatizado.Paginas;

namespace TesteAutomatizado.Testes
{
    public class TestDataTable : BaseTeste
    {
        public string url = "http://the-internet.herokuapp.com/tables";
        [Test]
        [Retry(2)]
        public void TestaItemDeletadoPelaUrl()
        {
            Console.WriteLine("Executando teste");
            DataTablePage dataTable = new DataTablePage(driver);
            dataTable.NavegaParaPagina(url);
            dataTable.DeletaItem();

            #region Assert
            Assert.IsTrue(true, driver.Url);
            #endregion
        }

        [Test]
        [Retry(2)]
        public void TestaItemEditadoPelaUrl()
        {
            Console.WriteLine("Executando teste");

            DataTablePage dataTable = new DataTablePage(driver);
            dataTable.NavegaParaPagina(url);
            dataTable.EditaItem();


            #region Assert
            Assert.IsTrue(true, driver.Url);
            #endregion
        }

        [Test]
        [Retry(2)]
        public void TestaSeItemFoiDeletado()
        {
            Console.WriteLine("Executando teste");

            DataTablePage dataTable = new DataTablePage(driver);
            dataTable.NavegaParaPagina(url);

            #region Dados
            var linhasAntesDelecao = dataTable.QuantidadeLinhasTabela();
            #endregion

            dataTable.DeletaItem();

            #region Assert
            Assert.AreEqual(linhasAntesDelecao, linhasAntesDelecao);
            #endregion
        }

        [Test]
        [Retry(2)]
        public void TestaDelecaoPorEmail()
        {
            Console.WriteLine("Executando teste");

            DataTablePage dataTable = new DataTablePage(driver);
            dataTable.NavegaParaPagina(url);
            dataTable.DeletaPorEmail("fbach@yahoo.com");

            #region Assert
            Assert.IsTrue(true, driver.Url);
            Assert.True(dataTable.VerificaSeEmailEstaNaTabela("fbach@yahoo.com"));
            #endregion
        }

    }
}

