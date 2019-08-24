﻿using System.Collections.Generic;

namespace TechAndTools.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public int MainCategoryId  { get; set; }
        public virtual MainCategory MainCategory { get; set; }
    }
}
