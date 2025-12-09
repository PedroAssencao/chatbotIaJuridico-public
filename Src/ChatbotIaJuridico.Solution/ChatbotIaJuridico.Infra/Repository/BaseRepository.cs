using ChatbotIaJuridico.Infra.DAL;
using Microsoft.EntityFrameworkCore;

namespace ChatbotIaJuridico.Infra.Repository
{
    public class BaseRepository<T> where T : class
    {
        protected readonly ChatbotIaJuridicoContext _context;

        public BaseRepository(ChatbotIaJuridicoContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            IQueryable<T> query = _context.Set<T>();

            var navigationProperties = _context.Model.FindEntityType(typeof(T))
                .GetNavigations()
                .Select(n => n.Name);

            foreach (var property in navigationProperties)
            {
                query = query.Include(property);
            }

            return await query.ToListAsync();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            IQueryable<T> query = _context.Set<T>();

            var navigationProperties = _context.Model.FindEntityType(typeof(T))
                .GetNavigations()
                .Select(n => n.Name);

            foreach (var property in navigationProperties)
            {
                query = query.Include(property);
            }

            var primaryKeyName = _context?.Model?.FindEntityType(typeof(T))
                ?.FindPrimaryKey()
                ?.Properties
                ?.Select(p => p.Name)
                ?.FirstOrDefault();

            if (primaryKeyName == null)
            {
                throw new InvalidOperationException($"A entidade {typeof(T).Name} não possui uma chave primária definida.");
            }

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, primaryKeyName) == id);
        }
        public async Task<T> CreateAsync(T model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            await _context.Entry(model).ReloadAsync();
            return model;
        }
        public async Task<T> UpdateAsync(T model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
            await _context.Entry(model).ReloadAsync();
            return model;
        }
        public async Task<T> DeleteAsync(T model)
        {
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
