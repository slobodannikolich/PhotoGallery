using Microsoft.AspNetCore.Mvc;
using PhotoGallery.Models;
using PhotoGallery.Repositories.Interfaces;

namespace PhotoGallery.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetCategories();
            if (categories == null) return NotFound();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Category ctg = new Category();
            return PartialView("_AddCategoryModelPartial",ctg);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            _categoryRepository.Add(category);
            return PartialView("_AddCategoryModelPartial", category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category == null) return NotFound();
            return PartialView("_EditCategoryModelPartial", category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            _categoryRepository.Update(category);
            return PartialView("_EditCategoryModelPartial", category);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category == null) return NotFound();
            return PartialView("_DetailCategoryModelPartial", category);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category == null) return NotFound();
            return PartialView("_DeleteCategoryModelPartial", category);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category == null) return NotFound();
            _categoryRepository.Delete(category);
            return PartialView("_DeleteCategoryModelPartial", category);
        }
    }
}
