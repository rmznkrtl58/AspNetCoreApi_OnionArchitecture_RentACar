﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.ReviewResults
{
	public class GetReviewByCarIdQueryResult
	{
		public string CustomerName { get; set; }
		public string CustomerImg { get; set; }
		public string Comment { get; set; }
		public int RaytingValue { get; set; }
		public DateTime ReviewDate { get; set; }
	}
}
