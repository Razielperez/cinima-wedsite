using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;// add d
using Cinema.Models; //add model


namespace Cinema.Dal
{
    public class PayDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Payment>().ToTable("PaymentTable");// connect model to db
        }
        public DbSet<Payment> payments { get; set; }
    }
}