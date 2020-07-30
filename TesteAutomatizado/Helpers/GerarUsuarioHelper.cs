using TesteAutomatizado.Data;

namespace TesteAutomatizado.Helpers
{
    /// <summary>
    /// Classe responsável por gerênciar a criação de dados para uso no sistema.
    /// </summary>
    public static class GerarUsuarioHelper
    {
        public static User GerarUsuario()
        {
            return new User().UsuarioPadrao();
        }
    }
}
