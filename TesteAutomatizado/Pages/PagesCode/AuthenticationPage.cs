using OpenQA.Selenium;
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
            SeleniumTools.EnviarTexto(driver, authenticationMap.InputEmail, nome);
        }

        /// <summary>
        /// Método responsável por preencher o Password
        /// </summary>
        /// <param name="password">Senha a ser preenchida.</param>
        public void PreencheCampoPassword(string password)
        {
            SeleniumTools.EnviarTexto(driver, authenticationMap.InputPassword, password);
        }

        /// <summary>
        /// Método responsável por clicar no botão de signin.
        /// </summary>
        public void ClickBtnSign_in()
        {
            SeleniumTools.Clicar(driver, authenticationMap.BtnSignIn);
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
