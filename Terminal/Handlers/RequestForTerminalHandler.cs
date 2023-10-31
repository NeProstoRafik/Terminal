using System.Text;

namespace Terminal.Handlers
{
    public class RequestForTerminalHandler
    {
        private IConfiguration _configuration;

        public RequestForTerminalHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task PostCommand(int id, int idCommand)
        {
            string upload = _configuration["ApiRequestDirectory"].Replace("{id}", id.ToString());
            string token = _configuration["Token"];
            if (upload != null || token != null)
            {
                string url = upload + token;

                using (var httpClient = new HttpClient())
                {
                    var json = $"{{\"command_id\": {idCommand}}}";
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(url, content);
                    var result = await response.Content.ReadAsStringAsync();

                }
            }

        }
    }
}
