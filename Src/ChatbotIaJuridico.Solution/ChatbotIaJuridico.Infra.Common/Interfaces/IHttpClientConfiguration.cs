namespace ChatbotIaJuridico.Infra.Common.Interfaces
{
    public interface IHttpClientConfiguration
    {
        void InitialVerification(string url);
        Task FinaleVerification(HttpResponseMessage response);
        public void InstanceClient();
        public void InstanceClient(string name);
        public void AddHeaders(Dictionary<string, string> headers);
        public Task<string> PostAsync(string url, HttpContent? request);
        public Task<string> GetAsync(string url);
    }
}
