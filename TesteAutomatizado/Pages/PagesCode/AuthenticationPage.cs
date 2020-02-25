using OpenQA.Selenium;
using System.Collections.Generic;
using TesteAutomatizado.Pages.PagesMap;
using TesteAutomatizado.Paginas;
using TesteAutomatizado.SeleniumUtils;

namespace TesteAutomatizado.Testes
{
    /// <summary>
    /// Classe responsável por armazenar os métodos da pagina de login.
    /// </summary>
    public class AuthenticationPage : BasePage
    {
        /// <summary>
        /// Atributo responsável por armazenar uma referência para a classe AuthenticationMap.
        /// </summary>
        private readonly AuthenticationMap authenticationMap = new AuthenticationMap();

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="driver">Driver atual.</param>
        public AuthenticationPage(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Método responsável por preencher o campo email.
        /// </summary>
        /// <param name="nome">Nome a ser preenchido</param>
        public void PreencheCampoEmail(string nome)
        {
            SeleniumTools.EnviarTexto(driver, authenticationMap.TxtEmail, nome);
        }

        /// <summary>
        /// Método responsável por preencher o campo email create account.
        /// </summary>
        /// <param name="nome">Nome a ser preenchido</param>
        public void PreencheCampoEmailCreateAccount(string nome)
        {
            SeleniumTools.EnviarTexto(driver, authenticationMap.TxtEmailCreateAccount, nome);
        }

        /// <summary>
        /// Método responsável por preencher o Password
        /// </summary>
        /// <param name="password">Senha a ser preenchida.</param>
        public void PreencheCampoPassword(string password)
        {
            SeleniumTools.EnviarTexto(driver, authenticationMap.TxtPassword, password);
        }

        /// <summary>
        /// Método responsável por clicar no botão de signin.
        /// </summary>
        public void ClickBtnSign_in()
        {
            SeleniumTools.Clicar(driver, authenticationMap.BtnSignIn);
        }

        /// <summary>
        /// Método responsável por clicar no botão de Create an account.
        /// </summary>
        public void ClickBtnCreateAccount()
        {
            SeleniumTools.Clicar(driver, authenticationMap.BtnCreateAnAccount);
        }

        /// <summary>
        /// Método responsável por clicar no botão de register an account.
        /// </summary>
        public void ClickBtnRegisterAnAccount()
        {
            SeleniumTools.Clicar(driver, authenticationMap.BtnRegister);
        }

        /// <summary>
        /// Método responsável por retornar texto da mensagem.
        /// </summary>
        /// <returns>Retorna a mensagem contida no alerta.</returns>
        public string RetornaTextoDaMensagem()
        {
            return SeleniumTools.RetornaTexto(driver, authenticationMap.Alert);
        }

        /// <summary>
        /// Método responsável por retornar mesagem de campo requirido.
        /// </summary>
        /// <returns>Retorna a mensagem de campo requerido.</returns>
        public string RetornaMensagemCampoRequerido()
        {
            return SeleniumTools.RetornaTexto(driver, authenticationMap.MsnRequiredFild);
        }

        /// <summary>
        /// Método responsável por retornar toda a lista de erros.
        /// </summary>
        /// <returns>Retorna a lista de erros</returns>
        public IList<string> RetornaListadeErros()
        {
            IList<string> listaErros = new List<string>();

            var listaElementos = SeleniumTools.CarregarListaElementos(driver, authenticationMap.Alert);
            foreach (var elemento in listaElementos)
            {
                listaErros.Add(elemento.Text);
            }

            return listaErros;
        }

        /// <summary>
        /// Método responsavél por formatar um texto.
        /// </summary>
        /// <param name="text">Texto a ser formatado.</param>
        /// <returns>Retorna um texto formatado.</returns>
        private string FormatString(string text)
        {
            return text.Replace("\r", "").Replace("\n", "").Replace("×", "");
        }
    }
}
