using miltonProject.Client.Interfaces;
using miltonProject.Client.Models;
using miltonProject.Client.Core.Static;
using Newtonsoft.Json;
using System.Text;

namespace miltonProject.Client.Services
{
    public class UserDetailRepository : IUserDetailRepository
    {
        public HttpClient _client;
        public UserDetailRepository()
        {
            _client = new();
        }
        public async Task<bool> Create(Details obj, int id)
        {
            if (obj == null || id == 0) return false;

            obj.UserId = id;
            var request = new HttpRequestMessage(HttpMethod.Post, Endpoints.Details);
            request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
        public async Task<Details> Get(int id)
        {
            if (id == 0) return null;
            var request = new HttpRequestMessage(HttpMethod.Get, Endpoints.GetDetails + "?id=" + id);

            HttpResponseMessage response = await _client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Details>(content);
            }

            return null;
        }
        public async Task<List<UserDetailsAll>> GetAllUserInfo()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Endpoints.GetAllDetailsOfUsers);

            HttpResponseMessage response = await _client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<UserDetailsAll>>(content);
            }

            return null;
        }
    }
}
