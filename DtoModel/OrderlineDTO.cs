using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoModel
{
    public class OrderlineDTO
    {
        public int Id { get; set; }
        private int amount { get; set; }
        public int Amount {get; set; }
        public int MovieId { get; set; }
        public int OrderId { get; set; }
        public  MovieDTO Movie { get; set; }
        public  OrderDTO Order { get; set; }
    }




}
