using System.Collections.Generic;
using MovieShopDAL.BE;
using MovieShopDTO.ModelDTO;

namespace MovieShopDTO.Converter
{
    class OrderConverter : AbstractDtoConverter<Order, OrderDTO>
    {
        public override OrderDTO Convert(Order item)
        {
            var orderDTO = new OrderDTO()
            {
                OrderId = item.OrderId,
                CustomerId = item.CustomerId,
                Date = item.Date,

            };
            if (item.Orderlines != null)
            {
                orderDTO.Orderlines = new List<OrderlineDTO>();
                foreach (var orderline in item.Orderlines)
                {
                    orderDTO.Orderlines.Add(new OrderlineDTO()
                    {
                        Id = orderline.Id,
                        Amount = orderline.Amount,
                        OrderId = orderline.OrderId,
                         MovieId = orderline.MovieId
                    });

                }
            }
            return orderDTO;
        }
    }
}

