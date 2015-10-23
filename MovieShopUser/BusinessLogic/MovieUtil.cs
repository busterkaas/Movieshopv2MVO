using MovieShopUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShopUser.BusinessLogic
{
    public class MovieUtil
    {
        public static decimal CalculateTotalPrice(IList<ShoppingCartItem> items)
        {
            return items.Sum(item => item.Quantity * item.UnitPrice);
        }
    }
}