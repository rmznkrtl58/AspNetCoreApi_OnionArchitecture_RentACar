using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers.ReadHandlers
{
    public class GetAboutQueryHandler
    {
        private readonly IRepository<About> _repository;
        public GetAboutQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAboutQueryResult>> Handle()
        {
            var values=await _repository.GetListAllAsync();
            return values.Select(x => new GetAboutQueryResult()
            {
                AboutId = x.AboutId,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Title= x.Title
            }).ToList();
        }
    }
}
