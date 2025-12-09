using ChatbotIaJuridico.Domain.Models.JsonOpenAiModels;

namespace ChatbotIaJuridico.Infra.Storage.Interfaces
{
    public interface IFileManager
    {
        public Task<string> saveFileLocal(string fileName, byte[] fileContent, string fileExtensions);
        public Task<byte[]> GetFileLocal(string filePath);
        public Task<List<string>> GeneratePeticao(GeneratePeticaoRecaive.Root Model);
    }
}
