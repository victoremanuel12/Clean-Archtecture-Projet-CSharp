using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Intefaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Product> GetProductCategoryAsync(int id)
        {
            IQueryable<Product> products = await GetAllAsync();
            return await products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
