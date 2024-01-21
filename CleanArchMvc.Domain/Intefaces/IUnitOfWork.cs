using CleanArchMvc.Domain.Intefaces;

namespace WebAPIMocoratti.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        Task Comit();
    }
}
