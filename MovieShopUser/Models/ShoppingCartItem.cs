using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShopUser.Models
{
    public class ShoppingCartItem
    {
        public string Title { get; set; }
        public int MovieId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}