using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopUser.Models
{
    public interface IShoppingCartModel
    {
        IList<ShoppingCartItem> Items { get; set; }
        void Add(int id);
        int NoOfItems { get; }
        decimal TotalPrice { get; }
    }
}
