using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.ExternalService.Generic
{
    public class GenericRequest
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public GenericRequest(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<T>?> GetListAsync<T>()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("");

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();

            if (content != null)
            {
                return JsonSerializer.Deserialize<List<T>>(content, _options);
            }

            return null;
        }
    }
}
