using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Intefaces
{
    public interface IProductRepository : IRepository<Product>
    {
        public Task<Product> GetProductCategoryAsync(int id);
    }
}
