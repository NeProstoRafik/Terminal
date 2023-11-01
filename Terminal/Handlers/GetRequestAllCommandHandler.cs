using Newtonsoft.Json;
using Terminal.Models;

namespace Terminal.Handlers
{
    public class GetRequestAllCommandHandler
    {
        private IConfiguration _configuration;

        public GetRequestAllCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<AllCommand>> GetAllCommandsAsync()
        {
            string upload = _configuration["ApiCommandDirectory"];
            string token = _configuration["Token"];
            if (upload == null || token == null)
            {
                return null;
            }

            string url = upload + token;

            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url);
                var response = JsonConvert.DeserializeObject<Root>(result);
                return response.items;
            }
            catch (Exception x)
            {
                Console.WriteLine("ошибка" + x.ToString());
                return null;
            }

        }

    }
}
