﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Services
{
    public class ArticleService : IArticleService
    {
        private readonly TechAndToolsDbContext context;
        private readonly IUserService userService;

        public ArticleService(TechAndToolsDbContext context,

            IUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }

        public IQueryable<ArticleServiceModel> GetAllArticles()
        {
            return this.context.Articles.To<ArticleServiceModel>();
        }

        public IQueryable<ArticleServiceModel> GetAllByUserIdAsync(string userId)
        {
            return this.context.Articles
                .Where(x => x.AuthorId == userId)
                .To<ArticleServiceModel>();
        }

        public IQueryable<ArticleServiceModel> GetLastThreeArticles(int articleId)
        {
            return this.context.Articles
                .Where(x => x.Id != articleId)
                .OrderByDescending(x => x.CreatedOn)
                .Include(x => x.Images)
                .Take(3)
                .To<ArticleServiceModel>();
        }

        public async Task<ArticleServiceModel> CreateArticleAsync(ArticleServiceModel articleServiceModel, string authorId)
        {
            Article article = articleServiceModel.To<Article>();
            article.AuthorId = authorId;
            article.CreatedOn = DateTime.UtcNow;

            await this.context.Articles.AddAsync(article);
            await this.context.SaveChangesAsync();

            return article.To<ArticleServiceModel>();
        }

        public async Task<ArticleServiceModel> GetArticleByIdAsync(int articleId)
        {
            Article articleFromDb = await this.context.Articles.SingleOrDefaultAsync(x => x.Id == articleId);

            if (articleFromDb == null)
            {
                throw new ArgumentNullException("articleId didnt exist");
            }

            return articleFromDb.To<ArticleServiceModel>();
        }

        public async Task<bool> DeleteArticleByIdAsync(int articleId)
        {
            Article articleFromDb = await this.context.Articles.SingleOrDefaultAsync(x => x.Id == articleId);

            if (articleFromDb == null)
            {
                throw new ArgumentNullException("articleId didnt exist");
            }

            this.context.Articles.Remove(articleFromDb);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<ArticleServiceModel> GetArticleAsync(int articleId)
        {
            Article articleFromDb = this.context.Articles.Include(x => x.Images).SingleOrDefault(x => x.Id == articleId);

            if (articleFromDb == null)
            {
                throw new ArgumentNullException("articleId didnt exist");
            }

            this.IncrementTimesRead(articleFromDb);

            this.context.Articles.Update(articleFromDb);
            await this.context.SaveChangesAsync();

            return articleFromDb.To<ArticleServiceModel>();
        }

        private Article IncrementTimesRead(Article article)
        {
            article.TimesRead++;

            return article;
        }
    }
}