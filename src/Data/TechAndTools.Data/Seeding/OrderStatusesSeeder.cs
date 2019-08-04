﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TechAndTools.Data.Models;

namespace TechAndTools.Data.Seeding
{
    public class OrderStatusesSeeder : ISeeder
    {
        public async Task SeedAsync(TechAndToolsDbContext dbContext, IServiceProvider serviceProvider)
        {           
            bool hasOrderStatuses = await dbContext.OrderStatuses.AnyAsync();

            if (!hasOrderStatuses)
            {
                await SeedOrderStatusAsync("Unprocessed", dbContext);
                await SeedOrderStatusAsync("Processed", dbContext);
                await SeedOrderStatusAsync("Delivered", dbContext);

                await dbContext.SaveChangesAsync();
            }
        }
        
        private static async Task SeedOrderStatusAsync(string orderStatusName, TechAndToolsDbContext dbContext)
        {
            var orderStatus = new OrderStatus { Name = orderStatusName };

            await dbContext.OrderStatuses.AddAsync(orderStatus);
        }
    }
}