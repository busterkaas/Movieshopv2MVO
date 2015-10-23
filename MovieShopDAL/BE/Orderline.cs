using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShopDAL.BE
{
    public class Orderline
    {
        public int Id { get; set; }
        private int amount { get; set; }

        public int Amount {
            get { return amount; }
            set {
                if (value < 1)
                {
                    throw new ArgumentException("Amount must be above 0");
                }
                    amount = value;
                }
                }

        public int MovieId { get; set; }
        public int OrderId { get; set; }
        public virtual Movie Movie { get; set; }

        public virtual Order Order { get; set; }
        

        public Orderline()
        {
            
        }

    }
}