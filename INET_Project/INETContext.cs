using INET_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INET_Project
{
    public class INETContext : DbContext
    {
        public DbSet<Product> Product { get; set; }

        string connectionString = "Server=DENNPC\\SQLEXPRESS;Database=INET;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
