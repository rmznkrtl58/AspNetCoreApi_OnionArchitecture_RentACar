using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CarDescriptionResults
{
	public class GetCarDescriptionByCarIdQueryResult
	{
        public int CarId { get; set; }
        public string Description { get; set; }
    }
}
