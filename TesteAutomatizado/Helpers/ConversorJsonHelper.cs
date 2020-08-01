using Newtonsoft.Json;
using TesteAutomatizado.Data;

namespace TesteAutomatizado.Helpers
{
    public static class ConversorJsonHelper
    {
        public static User JsonParaEntidade(string json)
        {
            var obj = JsonConvert.DeserializeObject<User>(json);

            return obj;
        }

        public static string EntidadeParaJson(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);

            return json;
        }
    }
}