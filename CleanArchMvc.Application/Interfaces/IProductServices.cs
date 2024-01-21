using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetProductById(int id);
        Task<ProductDTO> GetProductCategory(int id);
        Task Add(ProductDTO productDTO);
        Task Update(ProductDTO productDTO);
        Task Remove(int id);
    }
}
