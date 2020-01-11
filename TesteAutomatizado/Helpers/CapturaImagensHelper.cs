using OpenQA.Selenium;
using System;
using System.IO;

namespace TesteAutomatizado.Helpers
{
    /// <summary>
    /// Classe estática responsável por manipular eventos de captura de prints. 
    /// </summary>
    public static class CapturaImagensHelper
    {
        /// <summary>
        /// Método responsável por captturar um print da tela atual.
        /// </summary>
        /// <param name="driver">Driver atual</param>
        /// <param name="screenShotName">Nome do screenshot</param>
        /// <returns>Retorna uma string com o caminho da pasta onde sera salva a captura</returns>
        public static string CapturaPrintTela(IWebDriver driver, string screenShotName)
        {
            string localpath;
            try
            {
                Screenshot screenshot = Captura(driver);
                var dir = "C:";
                DirectoryInfo di = Directory.CreateDirectory(dir + "\\Imagens_capturadas\\" + DateTime.Now.ToString("MM-yy"));
                string finalpth = di.FullName + "\\" + screenShotName + DateTime.Now.ToString("hh-mm-ss") + ".png";
                localpath = new Uri(finalpth).LocalPath;
                screenshot.SaveAsFile(localpath);
            }
            catch (Exception e)
            {
                throw (e);
            }
            return localpath;
        }

        /// <summary>
        /// Método que captura a tela.
        /// </summary>
        /// <param name="driver"></param>
        /// <returns>Retorna uma instancia da captura da tela</returns>
        private static Screenshot Captura(IWebDriver driver)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            return screenshot;
        }
    }

}
