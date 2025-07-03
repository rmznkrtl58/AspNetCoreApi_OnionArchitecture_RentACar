using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers.WriteTestimonial
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;
        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var findTestimonial = await _repository.GetValueByIdAsync(request.TestimonialId);
            findTestimonial.Title= request.Title;
            findTestimonial.Comment= request.Comment;
            findTestimonial.Name= request.Name;
            findTestimonial.ImageUrl= request.ImageUrl;
            await _repository.UpdateAsync(findTestimonial);
        }
    }
}
