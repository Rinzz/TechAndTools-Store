﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly TechAndToolsDbContext context;

        public CategoryService(TechAndToolsDbContext context)
        {
            this.context = context;
        }

        public async Task<CategoryServiceModel> CreateCategoryAsync(CategoryServiceModel categoryServiceModel)
        {
            Category category = categoryServiceModel.To<Category>();

            await this.context.Categories.AddAsync(category);
            await this.context.SaveChangesAsync();

            return categoryServiceModel;
        }

        public async Task<CategoryServiceModel> EditCategoryAsync(CategoryServiceModel categoryServiceModel)
        {
            var category = categoryServiceModel.To<Category>();
            this.context.Update(category);
            await this.context.SaveChangesAsync();

            return categoryServiceModel;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Category category = await this.context.Categories.SingleOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            this.context.Categories.Remove(category);

            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public CategoryServiceModel GetCategoryById(int id)
        {
            return this.context.Categories.FirstOrDefault(x => x.Id == id).To<CategoryServiceModel>();
        }

        public IQueryable<CategoryServiceModel> GetAllCategoriesByMainCategoryIdAsync(int mainCategoryId)
        {
            return this.context.Categories.Where(category => category.MainCategoryId == mainCategoryId).To<CategoryServiceModel>();
        }

        public IQueryable<CategoryServiceModel> GetAllCategories()
        {
            return this.context.Categories.To<CategoryServiceModel>();
        }
    }
}