using Microsoft.EntityFrameworkCore;
using DatabaseBuilder.Entities;

namespace DatabaseBuilder
{
    /// <summary>
    /// Connects to the SQL Server based on the connection string
    /// given in the constructor
    /// Creates DB model
    /// </summary>
    public class MyContext : DbContext
    {
        public string _CONNECTIONSTRING { get; private set; }
        public MyContext(string _cs)
        {
            _CONNECTIONSTRING = _cs;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_CONNECTIONSTRING);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
