using MovieShopDAL.BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieShopDAL
{
    public class MovieShopDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MovieShopDBContext() : base("MovieShopDB")
        {
        }

        public System.Data.Entity.DbSet<MovieShopDAL.BE.Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<MovieShopDAL.BE.Genre> Genres { get; set; }

        public System.Data.Entity.DbSet<MovieShopDAL.BE.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<MovieShopDAL.BE.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<MovieShopDAL.BE.Orderline> Orderlines { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    var movieConfig = modelBuilder.Entity<Movie>();
        //    movieConfig.HasMany(movie => movie.Orders).WithRequired(order => order.Movie).HasForeignKey(order => order.Movie.MovieId);
        //    movieConfig.ToTable("Movie");
        //    var orderConfig = modelBuilder.Entity<Order>();
        //    orderConfig.ToTable("Order");
        //    var customerConfig = modelBuilder.Entity<Customer>();
        //    customerConfig.HasMany(customer => customer.Orders).WithRequired(order => order.Customer).HasForeignKey(order => order.Customer.CustomerId);
        //    customerConfig.ToTable("Customer");
        //}



    }
}
