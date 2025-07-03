

namespace CarBook.Application.Features.Mediator.Results.CarPricingResults
{
    public class GetCarPricingWithCarAndBrandByCarIdQueryResult
    {
        public int CarPricingId { get; set; }
        public int CarId { get; set; }
        public decimal Price { get; set; }//fiyat
        public string PriceName { get; set; }//günlük haftalık aylık
        public string BrandName { get; set; }
        public string CoverImageUrl { get; set; }
        public string Model { get; set; }
    }
}
