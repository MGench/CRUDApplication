using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApplication
{
    public class DataSession:DbContext
    {
        // configures context class
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // connection string to database
            optionsBuilder.UseSqlite("Data Source = UserData.db");
        }


        // defining tables by setting properties named 'Users'
        public DbSet<User> Users { get; set; }

    }
}
