using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Intefaces;
using MediatR;
using WebAPIMocoratti.Repository.Interfaces;

namespace CleanArchMvc.Application.Products.Handlers.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductsQueryHandler( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Product> products = await _unitOfWork.ProductRepository.GetAllAsync();
            if(products is null)
            {
                throw new ApplicationException("There are't products registered");
            }
            return products;
        }
    }
}
