using System;
using System.Collections.Generic;

namespace MovieShopDTO.ModelDTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public CustomerDTO Customer { get; set; }

        public List<OrderlineDTO> Orderlines { get; set; }
    }
}
