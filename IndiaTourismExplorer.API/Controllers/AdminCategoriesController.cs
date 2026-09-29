using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndiaTourismExplorer.API.Controllers
{
    [ApiController]
    [Route("api/admin/categories")]
    [Authorize(Roles = "Admin")]
    public class AdminCategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        public AdminCategoriesController(
            ICategoryService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Create(
            AdminCategoryDto dto)
        {
            var result = await _service.CreateAsync(dto);
            if (!result)
            {
                return BadRequest(new
                {
                    message = "Failed to create category."
                });
            }
            return Ok(new
            {
                message = "Category created successfully."
            });
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            AdminCategoryDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            if (!result)
            {
                return NotFound(new
                {
                    message = "Category not found."
                });
            }
            return Ok(new
            {
                message = "Category updated successfully."
            });
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result)
            {
                return NotFound(new
                {
                    message = "Category not found."
                });
            }
            return Ok(new
            {
                message = "Category deleted successfully."
            });
        }
    }
}
