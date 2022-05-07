using miltonProject.Client.Core.Static;
using miltonProject.Client.Interfaces;
using miltonProject.Client.Models;
using Newtonsoft.Json;
using System.Text;

namespace miltonProject.Client.Services
{
    public class BillingRepository : IBillingRepository
    {
        private readonly HttpClient _client;
        public BillingRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task<bool> UploadRequest(BillingRequest obj)
        {
            if (obj == null) return false;

            var request = new HttpRequestMessage(HttpMethod.Post, Endpoints.UploadBillRequest);
            request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
        public async Task<List<BillingRequest>> GetBillsByUserId(int id)
        {

            if (id == 0) return null;
            var request = new HttpRequestMessage(HttpMethod.Get, Endpoints.GetBillsById + "?id=" + id);

            HttpResponseMessage response = await _client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<BillingRequest>>(content);
            }

            return null;

        }
        public async Task<List<BillingRequest>> GetBills()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, Endpoints.GetBills);

            HttpResponseMessage response = await _client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<BillingRequest>>(content);
            }

            return null;

        }
    }
}
