using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using MediatR;
using WebAPIMocoratti.Repository.Interfaces;

namespace CleanArchMvc.Application.Products.Handlers.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Product product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new ApplicationException("Entity could not be found");
            }
            return product;
        }
    }
}
