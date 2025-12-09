using ChatbotIaJuridico.Infra.Common.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChatbotIaJuridico.Infra.Common.client
{
    public class HttpClientConfiguration : IHttpClientConfiguration
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientConfiguration(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient? _client;

        public void AddHeaders(Dictionary<string, string> headers)
        {
            foreach (var header in headers)
                _client?.DefaultRequestHeaders.Add(header.Key, header.Value);
        }

        public async Task FinaleVerification(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var status = response.StatusCode;
                var defaultMessage = $"{status}, erro ({(int)status}):";
                var message = await response.Content.ReadAsStringAsync();
                if (String.IsNullOrWhiteSpace(message))
                    throw new Exception($"{defaultMessage} Falha na requisição");
            }
        }

        public void InitialVerification(string url)
        {
            if (_client is null) throw new Exception("O cliente não foi instanciado");
            if (string.IsNullOrWhiteSpace(url)) throw new Exception("O url está vazio");
        }

        public void InstanceClient() => _client = _httpClientFactory.CreateClient();
        public void InstanceClient(string name) => _client = _httpClientFactory.CreateClient(name);

        public async Task<string> PostAsync(string url, HttpContent? request)
        {
            this.InitialVerification(url);
            using var response = await _client!.PostAsync(url, request);
            await FinaleVerification(response);
            var jsonResponse = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
            return jsonResponse.ToString();
        }

        public async Task<string> GetAsync(string url)
        {
            try
            {
                this.InitialVerification(url);
                using var response = await _client!.GetAsync(url);
                await FinaleVerification(response);
                var jsonResponse = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());
                return jsonResponse.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
