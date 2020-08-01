using OpenQA.Selenium;

namespace TesteAutomatizado.Pages.PagesMap
{
    /// <summary>
    /// Classe responsável por armazenar os elementos da página Women.
    /// </summary>
    public class WomenMap
    {
        /// <summary>Define o campo linkWomen.</summary>
        public readonly By LinkWomen = By.CssSelector("li>a[title='Women']");

        /// <summary>Define o campo listCloths que guarda uma lista de roupas.</summary>
        public readonly By ListClothes = By.CssSelector("ul.product_list>li");

        /// <summary>Define o campo do botão para adicionar no carinho.</summary>
        public readonly By ButtonAddToCart = By.CssSelector("a[title='Add to cart']>span");
    }
}