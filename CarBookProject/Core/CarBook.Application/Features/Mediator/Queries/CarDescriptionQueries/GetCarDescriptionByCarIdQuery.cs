﻿using CarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries
{
	public class GetCarDescriptionByCarIdQuery:IRequest<GetCarDescriptionByCarIdQueryResult>
	{
		public GetCarDescriptionByCarIdQuery(int id)
		{
			Id = id;
		}
		public int Id { get; set; }
    }
}
