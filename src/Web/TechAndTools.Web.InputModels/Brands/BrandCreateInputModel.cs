﻿using System.ComponentModel.DataAnnotations;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.InputModels.Brands
{
    public class BrandCreateInputModel : IMapTo<BrandServiceModel>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LogoUrl { get; set; }

        [Required]
        public string OfficialSite { get; set; }
    }
}