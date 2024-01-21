using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using MediatR;
using WebAPIMocoratti.Repository.Interfaces;

namespace CleanArchMvc.Application.Products.Handlers.Commands
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductRemoveCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            Product product = _unitOfWork.ProductRepository.GetByIdAsync(request.Id).Result;
            if (product == null)
            {
                throw new ApplicationException("Entity could not be found");
            }
            Product productDeleted = _unitOfWork.ProductRepository.Delete(product);
            return productDeleted;
        }
    }
}
