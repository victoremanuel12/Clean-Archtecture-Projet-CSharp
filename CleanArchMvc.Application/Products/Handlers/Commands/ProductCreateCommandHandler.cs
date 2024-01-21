using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using MediatR;
using WebAPIMocoratti.Repository.Interfaces;

namespace CleanArchMvc.Application.Products.Handlers.Commands
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image);

            if (product == null)
            {
                throw new ApplicationException("Error Creating Entity");
            };
            product.CategoryId = request.CategoryId;
            return await _unitOfWork.ProductRepository.CreateAsync(product);
        }
    }
}
