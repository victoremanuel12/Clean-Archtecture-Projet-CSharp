using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using WebAPIMocoratti.Repository.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryServices
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _uow = UnitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            IEnumerable<Category> categoriesEntity = await _uow.CategoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }
        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            Category categoryEntity = await _uow.CategoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }
        public async Task Add(CategoryDTO categoryDTO)
        {
            Category categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _uow.CategoryRepository.CreateAsync(categoryEntity);
            await _uow.Comit();

        }
        public async Task Update(CategoryDTO categoryDTO)
        {
            Category categoryEntity = _mapper.Map<Category>(categoryDTO);
            _uow.CategoryRepository.Update(categoryEntity);
            await _uow.Comit();
        }

        public async Task Remove(int id)
        {
            Category categoryEntity = await _uow.CategoryRepository.GetByIdAsync(id);
            _uow.CategoryRepository.Delete(categoryEntity);
            await _uow.Comit();
        }
    }
}
