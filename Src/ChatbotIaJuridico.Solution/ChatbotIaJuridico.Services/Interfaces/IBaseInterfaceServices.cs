namespace ChatbotIaJuridico.Services.Interfaces
{
    public interface IBaseInterfaceServices<T>
    {
        public Task<List<T>> getAllAsync();
        public Task<T> getByIdAsync(int id);
        public Task<T> createAsync(T model);
        public Task<T> updateAsync(T model);
        public Task<T> deleteAsync(T model);
    }
}
