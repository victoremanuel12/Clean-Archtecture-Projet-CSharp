using CleanArchMvc.Domain.Intefaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<T>> GetAllAsync()
        {
            var result = await _context.Set<T>().ToListAsync();
            return result.AsQueryable();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public  T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
            return entity;
        }

        public T Delete(T entity)
        {
            _context.Remove(entity);
            return entity;
        }

    }
}
