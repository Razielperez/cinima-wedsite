using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;// add d
using Cinema.Models; //add model
namespace Cinema.Dal
{
    public class OrderDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<OrderDal>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>().ToTable("OrderTable");// connect model to db
        }
        public DbSet<Order> orders { get; set; }
    }
}