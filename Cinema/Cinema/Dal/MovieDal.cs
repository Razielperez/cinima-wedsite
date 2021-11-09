using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;// add d
using Cinema.Models; //add model


namespace Cinema.Dal
{
    public class MovieDal:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MovieDal>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().ToTable("MovieTable");// connect model to db
        }
        public DbSet<Movie> movies { get; set; }
    }
}