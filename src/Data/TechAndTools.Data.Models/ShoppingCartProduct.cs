﻿namespace TechAndTools.Data.Models
{
    public class ShoppingCartProduct
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public int ShoppingCardId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}