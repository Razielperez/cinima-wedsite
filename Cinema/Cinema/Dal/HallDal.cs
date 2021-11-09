using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;// add d
using Cinema.Models; //add model


namespace Cinema.Dal
{
    public class HallDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<HallDal>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hall>().ToTable("HallTable");// connect model to db
        }
        public DbSet<Hall> halls { get; set; }
    }
}