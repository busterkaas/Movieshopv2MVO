using MovieShopDAL.BE;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopUITest
{
    [TestFixture]
    public class OrderlineTest
    {
        [Test]
        public void Orderline_properties_set_ok_test()
        {
            Orderline orderline = new Orderline();
            Movie movie = new Movie() { MovieId = 1, Title = "Smurfs" };
            orderline.Movie = movie;
            orderline.Amount = 10;

            Assert.AreEqual(movie, orderline.Movie);
            Assert.AreEqual(10, orderline.Amount);

        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Orderline_amount_less_than_one_fails_test()
        {
            Orderline orderline = new Orderline();
            orderline.Amount = -1;
        }
    }
}
