using TesteAutomatizado.Data;

namespace TesteAutomatizado.Helpers
{
    /// <summary>
    /// Classe responsável por gerênciar a criação de daados para uso no sistema.
    /// </summary>
    public static class GeneratorHelper
    {
        public static User GerarUsuario()
        {
            return new User().UsuarioPadrao();
        }
    }
}
