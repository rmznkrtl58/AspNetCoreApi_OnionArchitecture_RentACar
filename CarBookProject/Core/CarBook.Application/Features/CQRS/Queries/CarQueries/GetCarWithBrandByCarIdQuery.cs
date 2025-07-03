﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarWithBrandByCarIdQuery
    {
        public GetCarWithBrandByCarIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
