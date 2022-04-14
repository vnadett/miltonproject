using miltonProject.Client.Interfaces;
using miltonProject.Client.Models;
using miltonProject.Client.Core.Static;
using Newtonsoft.Json;
using System.Text;

namespace miltonProject.Client.Services
{
    public class LoginRepository : ILoginRepository
    {
        private readonly HttpClient _client;
        public LoginRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task<Login> LoginUser(Login obj)
        {
            if (obj == null) return null;

            var request = new HttpRequestMessage(HttpMethod.Post, Endpoints.Login);
            request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);
            var result = JsonConvert.DeserializeObject<Login>(await response.Content.ReadAsStringAsync());
            return result;
        }
    }
}
