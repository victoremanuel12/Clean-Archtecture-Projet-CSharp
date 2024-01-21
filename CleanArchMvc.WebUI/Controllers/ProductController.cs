using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IWebHostEnvironment _environment;
        public ProductController(IProductServices productServices, ICategoryServices categoryServices, IWebHostEnvironment environment)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
            _environment = environment;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductDTO> products = await _productServices.GetAllProducts();
            return View(products);
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _categoryServices.GetAllCategories(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDto)
        {
            if (ModelState.IsValid)
            {
                await _productServices.Add(productDto);
                return RedirectToAction(nameof(Index));
            }
            return View(productDto);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null) return NotFound();
            ProductDTO productDto = await _productServices.GetProductById(id);

            if (productDto == null) return NotFound();

            IEnumerable<CategoryDTO> categories = await _categoryServices.GetAllCategories();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", productDto.CategoryId);

            return View(productDto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO productDto)
        {
            if (ModelState.IsValid)
            {
                await _productServices.Update(productDto);
                return RedirectToAction(nameof(Index));
            }
            return View(productDto);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return NotFound();
            ProductDTO productDto = await _productServices.GetProductById(id);
            if (productDto == null) return NotFound();
            return View(productDto);
        }
        [HttpGet()]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null) return NotFound();
            var productDto = await _productServices.GetProductById(id);
            if (productDto == null) return NotFound();
            return View(productDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productServices.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
