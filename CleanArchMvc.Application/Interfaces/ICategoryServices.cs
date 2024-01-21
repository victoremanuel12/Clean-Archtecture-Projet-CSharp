using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ICategoryServices
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategories();
        Task<CategoryDTO> GetCategoryById(int id);
        Task Add(CategoryDTO categoryDTO);
        Task Update(CategoryDTO categoryDTO);
        Task Remove(int id);

    }
}
