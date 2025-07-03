﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CarPricingCommands
{
    public class CreateCarPricingCommand:IRequest
    {
        public int CarId { get; set; }
        public int PricingId { get; set; }
        public decimal Price { get; set; }
    }
}
