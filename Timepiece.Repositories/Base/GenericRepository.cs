
using Microsoft.EntityFrameworkCore;
using Timepiece.Repositories.Models;

namespace Timepiece.Repositories.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly VintageWatchDbContext _context;
        public GenericRepository() => _context ??= new VintageWatchDbContext();

        public GenericRepository(VintageWatchDbContext context)
        {
            
            _context = context;
        }
        public void Create(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public async Task<int> CreateAsync(T entity)
        {
            _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public IQueryable<T> GetAllQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public T GetById(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public T GetById(string code)
        {
            var entity = _context.Set<T>().Find(code);
            if (entity == null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public T GetById(Guid code)
        {
            var entity = _context.Set<T>().Find(code);
            if (entity == null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public async Task<T> GetByIdAsync(string code)
        {
            var entity = await _context.Set<T>().FindAsync(code);
            if (entity == null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public async Task<T> GetByIdAsync(Guid code)
        {
            var entity = await _context.Set<T>().FindAsync(code);
            if (entity == null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        #region Separating asigned entity and save operators    
        public void PrepareCreate(T entity)
        {
            _context.Add(entity);
        }

        public void PrepareRemove(T entity)
        {
            _context.Remove(entity);
        }

        public void PrepareUpdate(T entity)
        {
            var tracker = _context.Attach(entity);
            tracker.State = EntityState.Modified;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        #endregion Separating asign entity and save operators

        public bool Remove(T entity)
        {
            _context.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        

        public void Update(T entity)
        {
            var tracker = _context.Attach(entity);
            tracker.State = EntityState.Modified;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            var tracker = _context.Attach(entity);
            tracker.State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
