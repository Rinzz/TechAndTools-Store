﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services.Models;

namespace TechAndTools.Services.Contracts
{
    public interface IOrderService
    {
        OrderServiceModel Create(OrderServiceModel orderServiceModel, string username, decimal deliveryPrice);

        OrderServiceModel GetOrderById(int orderId);

        Task<bool> ProcessOrderAsync(int id);

        Task<bool> DeliverOrderAsync(int id);

        IEnumerable<OrderServiceModel> GetAllOrdersByUserId(string username);

        IQueryable<OrderServiceModel> GetUnprocessedOrders();

        IQueryable<OrderServiceModel> GetProcessedOrders();

        IQueryable<OrderServiceModel> GetDeliveredOrders();
    }
}
