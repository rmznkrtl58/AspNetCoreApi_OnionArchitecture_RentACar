using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers.ReadHandlers;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers.WriteHandlers;
using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GetCategoryByIdQueryHandler _getCategoryById;
        private readonly GetCategoryQueryHandler _getCategory;
        private readonly CreateCategoryCommandHandler _createCategory;
        private readonly UpdateCategoryCommandHandler _updateCategory;
        private readonly DeleteCategoryCommandHandler _deleteCategory;
        public CategoriesController(GetCategoryByIdQueryHandler getCategoryById, GetCategoryQueryHandler getCategory, CreateCategoryCommandHandler createCategory, UpdateCategoryCommandHandler updateCategory, DeleteCategoryCommandHandler deleteCategory)
        {
            _getCategoryById = getCategoryById;
            _getCategory = getCategory;
            _createCategory = createCategory;
            _updateCategory = updateCategory;
            _deleteCategory = deleteCategory;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            var values = await _getCategory.Handle();
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Kategori Listesi Bulunamadı!");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var value = await _getCategoryById.Handle(new GetCategoryByIdQuery(id));
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return NotFound("Kategori Bulunamadı!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand c)
        {
            await _createCategory.Handle(c);
            return Ok("Kategori Eklemesi Başarıyla Yapıldı!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand c)
        {
            await _updateCategory.Handle(c);
            return Ok("Kategori Güncellemesi Başarıyla Yapıldı!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _deleteCategory.Handle(new DeleteCategoryCommand(id));
            return Ok("Kategori Başarıyla Silindi!");
        }
    }
}
