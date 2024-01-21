using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using MediatR;
using WebAPIMocoratti.Repository.Interfaces;

namespace CleanArchMvc.Application.Products.Handlers.Commands
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductUpdateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            Product product = _unitOfWork.ProductRepository.GetByIdAsync(request.Id).Result;
            if (product == null)
            {
                throw new ApplicationException("Entity could not be found");
            }
            product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
            return _unitOfWork.ProductRepository.Update(product);
        }
    }
}
