using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using MediatR;
using WebAPIMocoratti.Repository.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductServices
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IUnitOfWork uow, IMapper mapper, IMediator mediator)
        {
            _uow = uow;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            GetProductsQuery productsQuery = new GetProductsQuery();
            if (productsQuery is null)
                throw new ApplicationException("Error to get data about products");

            IEnumerable<Product> result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);

        }
        public async Task<ProductDTO> GetProductById(int id)
        {
            GetProductByIdQuery productIdQuery = new GetProductByIdQuery(id);
            if (productIdQuery is null)
                throw new ApplicationException("Error to get data about products");

            Product result = await _mediator.Send(productIdQuery);
            return _mapper.Map<ProductDTO>(result);

        }
        public async Task<ProductDTO> GetProductCategory(int id)
        {
            GetProductByIdQuery productIdQuery = new GetProductByIdQuery(id);
            if (productIdQuery is null)
                throw new ApplicationException("Error to get data about products");

            Product result = await _mediator.Send(productIdQuery);
            return _mapper.Map<ProductDTO>(result);

        }

        public async Task Add(ProductDTO productDTO)
        {
            ProductCreateCommand productCreateComand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateComand);
            await _uow.Comit();

        }

        public async Task Update(ProductDTO productDTO)
        {
            ProductUpdateCommand productUpdateComand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateComand);
            await _uow.Comit();
        }

        public async Task Remove(int id)
        {
            ProductRemoveCommand productRemoveCommand = new ProductRemoveCommand(id);
            if (productRemoveCommand is null)
                throw new ApplicationException("Error to get data about products");

            await _mediator.Send(productRemoveCommand);
            await _uow.Comit();


        }
    }
}
