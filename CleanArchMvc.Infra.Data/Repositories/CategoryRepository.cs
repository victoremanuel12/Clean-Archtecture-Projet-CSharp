using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Intefaces;
using CleanArchMvc.Infra.Data.Context;

namespace CleanArchMvc.Infra.Data.Repositories
{
    internal class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
