using Application.DTOs.Categories;
using Application.DTOs.Movements;
using Application.Interfaces.UseCases.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fintor.api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : Controller
    {
        private readonly ICreateCategory _createCategory;
        public CategoryController(ICreateCategory createCategory)
        {
            _createCategory = createCategory;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            CategoryDTO categoryDTO = await _createCategory.ExecuteAsync(createCategoryDTO, userId);
            return Ok(categoryDTO);
        }
    }
}
