﻿using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models.Brands;

namespace TechAndTools.Web.InputModels.Administration.Brands
{
    public class BrandInputModel : IMapTo<BrandServiceModel>
    {
        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public string OfficialSite { get; set; }
    }
}
