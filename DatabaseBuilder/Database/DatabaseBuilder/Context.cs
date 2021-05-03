using Microsoft.EntityFrameworkCore;

namespace DatabaseBuilder
{
    public class Context : DbContext
    {
        public string _CONNECTIONSTRING { get; private set; }
        public Context(string _cs)
        {
            _CONNECTIONSTRING = _cs;
            System.Console.WriteLine(_CONNECTIONSTRING);
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
