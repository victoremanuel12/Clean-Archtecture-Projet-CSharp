using CleanArchMvc.Domain.Intefaces;
using CleanArchMvc.Infra.Data.Context;
using WebAPIMocoratti.Repository.Interfaces;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;
        public ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository = _productRepository ?? new ProductRepository(_context);
            }
        }

        public ICategoryRepository CategoryRepository
        {

            get
            {
                return _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);
            }
        }
        public async Task Comit()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
