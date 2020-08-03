using System.IO;
using TesteAutomatizado.Data;

namespace TesteAutomatizado.Helpers
{
    public static class ManipularArquivoHelper
    {
        /// <summary>
        /// Representa o caminho para o arquivo;
        /// </summary>
        private static readonly string Caminho = @"C:\Users\Eshi\OneDrive\C#\TesteAutomatizado\TesteAutomatizado\Data\Files";

        /// <summary>
        /// Representa o nome do arquivo
        /// </summary>
        private static readonly string NomeArquivo = @"\Usuario";

        /// <summary>
        /// Método responsável por salvar um registro no arquivo em formato json.
        /// </summary>
        /// <param name="obj">Entidade a ser salva</param>
        public static void SalvarNoArquivoEmFormatoJson(User obj)
        {
            string texto = ConversorJsonHelper.EntidadeParaJson(obj);

            File.WriteAllText(string.Concat(Caminho, NomeArquivo), texto);
        }

        /// <summary>
        /// Métoro responsável por retornar um objeto dinâmico com os dados do arquivo.
        /// </summary>
        /// <returns>Retorna um tipo dinâmico com os valores de um json</returns>
        public static User LerDeUmArquivoQueEstaNoFormatoJson()
        {
            string texto = File.ReadAllText(string.Concat(Caminho, NomeArquivo));

            return ConversorJsonHelper.JsonParaEntidade(texto);
        }
    }
}