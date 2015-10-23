using MovieShopDAL.BE;
using MovieShopUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShopUser.ViewModels
{
    public class CustomerCart
    {

        public Customer Customer { get; set; }

        public Customer getCustomer()
        {
            return Customer;
        }
        public void setCustomer(Customer cus)
        {
            Customer = cus;
        }

        public List<ShoppingCartItem> CartItems { get; set; }
        public List<ShoppingCartItem> getCartList()
        {
            return CartItems;
        }
        public void setCartItems(List<ShoppingCartItem> list)
        {
            CartItems = list;
        }

       

        public CustomerCart()
        {

        }
    }
}