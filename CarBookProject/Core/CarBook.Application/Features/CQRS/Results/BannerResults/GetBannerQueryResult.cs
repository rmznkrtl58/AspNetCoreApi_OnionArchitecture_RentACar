﻿

namespace CarBook.Application.Features.CQRS.Results.BannerResults
{   //Result kısmında listeleme veya şartlı getirme işlemlerinin
    //proplarını tutuyorum
    public class GetBannerQueryResult
    {
        public int BannerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoUrl { get; set; }
    }
}
