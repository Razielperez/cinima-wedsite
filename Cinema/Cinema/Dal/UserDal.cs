using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;// add db 
using Cinema.Models; //add model
namespace Cinema.Dal
{
    public class UserDal: DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<UserDal>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("UserTable");// connect model to db
        }
        public DbSet<User> users { get; set; } // dbset - ef object - custing to student
    }
}