﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.PricingResults
{ 
    public class GetPricingByIdQueryResult:IRequest<GetPricingByIdQueryResult>
    {
    public int PricingId { get; set; }
    public string Name { get; set; }
    }
}
