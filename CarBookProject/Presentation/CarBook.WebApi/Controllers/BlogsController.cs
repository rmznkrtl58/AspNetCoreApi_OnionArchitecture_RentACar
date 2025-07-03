using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Blog Listesi Bulunamadı!");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return BadRequest("Blogun Bulunmasında Hata Vardır!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand c)
        {
            await _mediator.Send(c);
            return Ok("Blog Kaydedildi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand c)
        {
            await _mediator.Send(c);
            return Ok("Blog Güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            DeleteBlogCommand c = new DeleteBlogCommand(id);
            await _mediator.Send(c);
            return Ok("Blog Silindi!");
        }
        [HttpGet("GetLast3BlogWithAuthors")]
        public async Task<IActionResult> GetLast3BlogWithAuthors()
        {
            var values = await _mediator.Send(new GetLast3BlogWithAuthorsQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Yazar Bilgisi İle Blog Listesi Bulunamadı!");
            }
        }
        [HttpGet("GetBlogsWithCategoryAndAuthor")]
        public async Task<IActionResult> GetBlogsWithCategoryAndAuthor()
        {
            var values = await _mediator.Send(new GetBlogsWithCategoryAndAuthorQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Blog Listesi Bulunamadı!");
            }
        }
        [HttpGet("GetBlogByIdWithAuthor/{id}")]
        public async Task<IActionResult> GetBlogByIdWithAuthor(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdWithAuthorQuery(id));
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return NotFound("Blog Bulunamadı!");
            }
        }
        [HttpGet("GetLast5Blog")]
        public async Task<IActionResult> GetLast5Blog()
        {
            var value = await _mediator.Send(new GetLast5BlogQuery());
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return NotFound("Blog Bulunamadı!");
            }
        }
    }
}
