using miltonProject.Client.Models;
using miltonProject.Client.Core.Static;
using Newtonsoft.Json;
using System.Text;
using miltonProject.Client.Interfaces;

namespace miltonProject.Client.Services
{
    public class RegistrationRepository : IRegistrationRepository
    {
        public HttpClient _client;
        public RegistrationRepository()
        {
            _client = new();
        }
        public async Task<bool> Create(Registration obj)
        {
            if (obj == null) return false;

            var request = new HttpRequestMessage(HttpMethod.Post, Endpoints.Reg);
            request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

    }
}
