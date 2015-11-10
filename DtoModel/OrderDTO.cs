using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoModel
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
