using ChatbotIaJuridico.Domain.Models.JsonOpenAiModels;
using ChatbotIaJuridico.Infra.Storage.Interfaces;
using ChatbotIaJuridico.Services.Storage.Interface;

namespace ChatbotIaJuridico.Services.Storage.Service
{
    public class FileManagerServices : IFileManagerServices
    {
		protected readonly IFileManager _fileManager;

        public FileManagerServices(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public async Task<string> saveFileLocal(string fileName, byte[] fileContent, string fileExtensions)
        {
            try
            {
                return await _fileManager.saveFileLocal(fileName, fileContent, fileExtensions);
            }
            catch (Exception)
			{

				throw;
			}
        }

        public async Task<byte[]> GetFileLocal(string filePath)
        {
            try
            {
                return await _fileManager.GetFileLocal(filePath);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<string>> GeneratePeticao(GeneratePeticaoRecaive.Root Model)
        {
            try
            {
                return await _fileManager.GeneratePeticao(Model);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
