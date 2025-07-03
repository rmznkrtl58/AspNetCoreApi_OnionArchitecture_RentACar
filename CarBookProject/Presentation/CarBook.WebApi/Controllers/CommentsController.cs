using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Features.RepositoryPattern.ICommentRepositories;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMediator _mediator;
        public CommentsController(ICommentRepository commentRepository, IMediator mediator)
        {
            _commentRepository = commentRepository;
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentRepository.GetListAll();
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Yorum listesi Bulunamadı!");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _commentRepository.GetValueById(id);
            if (value != null)
            {
                return Ok(value);
            }
            else
            {
                return NotFound("Yorum Bulunamadı!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand c)
        {
            await _mediator.Send(c);
            return Ok("Yorum Eklendi!");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            _commentRepository.Delete(id);
            return Ok("Yorum Silindi!");
        }
        [HttpGet("GetCommentByBlogId/{id}")]
        public IActionResult GetCommentByBlogId(int id)
        {
            var values = _commentRepository.GetListByCondition(x => x.BlogId == id).ToList();
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("Blog Id'ye göre listelenen yorumlar bulunamadı!");
            }
        }
    }
}
