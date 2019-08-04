﻿using System.Collections.Generic;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;

namespace TechAndTools.Services.Models
{
    public class CategoryServiceModel : IMapTo<Category>, IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

        public int MainCategoryId  { get; set; }
        public MainCategory MainCategory { get; set; }
    }
}
