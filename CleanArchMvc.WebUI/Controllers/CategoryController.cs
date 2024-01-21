using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryService;
        public CategoryController(ICategoryServices categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<CategoryDTO> categoriesDTOResult = await _categoryService.GetAllCategories();
            return View(categoriesDTOResult);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    await _categoryService.Add(categoryDto);
                    if (categoryDto is null) return NotFound();

                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDto);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            CategoryDTO categoriesDTOResult = await _categoryService.GetCategoryById(id);
            if (categoriesDTOResult is null) return NotFound();

            return View(categoriesDTOResult);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    await _categoryService.Update(categoryDto);
                    if (categoryDto is null) return NotFound();

                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDto);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return NotFound();
            CategoryDTO categoryDto = await _categoryService.GetCategoryById(id);
            if (categoryDto == null) return NotFound();
            return View(categoryDto);

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if(id == null ) return NotFound();
            CategoryDTO categoryDto = await _categoryService.GetCategoryById(id);
            if (categoryDto == null) return NotFound();
            return View(categoryDto);

        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> Deleted(int id)
        {
            await _categoryService.Remove(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
