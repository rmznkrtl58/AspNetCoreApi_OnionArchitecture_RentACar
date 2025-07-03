using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.AuthorResults
{
    public class GetAuthorQueryResult
    {
        public int AuthorId { get; set; }
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
