﻿using CarBook.Application.Features.Mediator.Results.FeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.FeatureQueries
{
    //IRequest mediatR kullanımı için gereklidir burdaki olay 
    //her bir yapıyı tek bir merkezde toplamaktır 
    public class GetFeatureQuery:IRequest<List<GetFeatureQueryResult>>
    {
    }
}
