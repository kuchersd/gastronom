using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace gastronom.Models
{
    public class DatabaseContext : DbContext
    {
        

        public DbSet<Account> Accounts {get;set;}

        public DatabaseContext(DbContextOptions options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Account>().OwnsOne(a => a.UserName);

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
