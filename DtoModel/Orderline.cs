using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoModel
{
    public class Orderline
    {
        public int Id { get; set; }
        private int amount { get; set; }

        public int Amount
        {
            get { return amount; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Amount must be above 0");
                }
                amount = value;
            }
        }

        public int MovieId { get; set; }
        public int OrderId { get; set; }


    }
}
