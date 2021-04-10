using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace gastronom.Models
{
    // https://www.youtube.com/watch?v=7pkmqrrjAAQ&list=PLA8ZIAm2I03jSfo18F7Y65XusYzDusYu5&index=2
    public class DbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>();
            options.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=Database;Trusted_Connection=True;");

            return new DatabaseContext(options.Options);
        }
    }
}
