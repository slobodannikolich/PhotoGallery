using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoGallery.Data;
using PhotoGallery.Models;
using PhotoGallery.Repositories.Interfaces;

namespace PhotoGallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APICategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryService;

        public APICategoryController(ICategoryRepository categoryService)
        {
            _categoryService = categoryService;
        }


        [Route("Categories")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetCategories();
            return Ok(categories);
        }



        [Route("Category/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var category = await _categoryService.GetCategory(id);
            if (category == null) return BadRequest("Category doesn't exists");
            return Ok(category);
        }



        [Route("AddCategory")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name) || category.Name.Length > 50) return BadRequest("Wrong Category Name");
            if (string.IsNullOrWhiteSpace(category.Description) || category.Description.Length > 200) return BadRequest("Wrong Category Description");

            try
            {
                _categoryService.Add(category);
                return Ok("Category has been added!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




        [Route("EditCategory")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name) || category.Name.Length > 50) return BadRequest("Wrong Category Name");
            if (string.IsNullOrWhiteSpace(category.Description) || category.Description.Length > 200) return BadRequest("Wrong Category Description");

            try
            {
                var dbCategory = await _categoryService.GetCategory(category.CategoryID);
                if (dbCategory == null) return BadRequest("The Category doesn't exists");
                dbCategory.Name = category.Name;
                dbCategory.Description = category.Description;

                _categoryService.Save();
                return Ok("Category has been updated");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [Route("DeleteCategory/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var category = await _categoryService.GetCategory(id);
                if (category == null) return BadRequest("The Category doesn't exists");
                else
                {
                    _categoryService.Delete(category);
                }
                return Ok("Category has been deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
