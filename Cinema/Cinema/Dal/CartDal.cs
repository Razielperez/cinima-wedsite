using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;// add d
using Cinema.Models; //add model


namespace Cinema.Dal
{
    public class CartDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<CartDal>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cart>().ToTable("CartTable");// connect model to db
        }
        public DbSet<Cart> carts { get; set; }
    }
}