using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;// add d
using Cinema.Models; //add model
namespace Cinema.Dal
{
    public class TimeDal:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TimeDal>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Time>().ToTable("TimeTable");// connect model to db
        }
        public DbSet<Time> times { get; set; }
    }
}