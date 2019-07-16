﻿namespace TechAndTools.Data.Models
{
    using System;
    using System.Collections.Generic;
    using TechAndTools.Data.Models.Enums;

    public class Order
    {
        public int Id { get; set; }

        public OrderStatus Status { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public DateTime? DispatchDate { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal DeliveryPrice { get; set; }

        public string Recipient { get; set; }

        public string RecipientPhoneNumber { get; set; }

        public string InvoiceNumber { get; set; }

        public PaymentType PaymentType { get; set; }

        public string UserId { get; set; }
        public virtual TechAndToolsUser User { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

        public int DeliveryAddressId { get; set; }
        public virtual DeliveryAddress DeliveryAddress { get; set; }
    }
}