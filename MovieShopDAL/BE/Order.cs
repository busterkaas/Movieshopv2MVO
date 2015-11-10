using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieShopDAL.BE
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual List<Orderline> Orderlines { get; set; }
       
        //public virtual Movie Movie { get; set; }
        //public List<Orderline> Orderlines { get; set; }

    }
}
