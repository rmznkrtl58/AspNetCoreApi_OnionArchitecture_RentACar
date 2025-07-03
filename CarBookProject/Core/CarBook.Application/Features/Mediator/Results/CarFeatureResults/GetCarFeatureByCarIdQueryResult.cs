﻿

namespace CarBook.Application.Features.Mediator.Results.CarFeatureResults
{
    public class GetCarFeatureByCarIdQueryResult
    {
        public int CarFeatureId { get; set; }
        public int FeatureId { get; set; }
        public bool Available { get; set; }
        public string BrandModel { get; set; }
        public string FeatureName { get; set; }
        public int CarId { get; set; }
    }
}
