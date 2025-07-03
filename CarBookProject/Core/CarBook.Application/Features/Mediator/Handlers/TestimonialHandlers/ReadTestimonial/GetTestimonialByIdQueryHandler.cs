using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook.Application.Features.Mediator.Results.TestimonialResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers.ReadTestimonial
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IRepository<Testimonial> _repository;
        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }
        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var findTestimonial = await _repository.GetValueByIdAsync(request.Id);
            return new GetTestimonialByIdQueryResult()
            {
                Comment=findTestimonial.Comment,
                ImageUrl=findTestimonial.ImageUrl,
                Name=findTestimonial.Name,
                TestimonialId=findTestimonial.TestimonialId,
                Title=findTestimonial.Title
            };
        }
    }
}
