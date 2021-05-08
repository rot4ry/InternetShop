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

        //Entities
        public DbSet<Category> Category { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Parameter> Parameter { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductParameter> ProductParameter { get; set; }
        public DbSet<ProductPicture> ProductPicture { get; set; }
        public DbSet<VAT> VAT { get; set; }

        
        public MyContext(string _cs)
        {
            _CONNECTIONSTRING = _cs;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_CONNECTIONSTRING);
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
            //Category
            mb.Entity<Category>().HasKey(x => x.CategoryID);

            mb.Entity<Category>().Property(x => x.CategoryID)
                .UseIdentityColumn(1, 1).HasColumnType("int").IsRequired();
            
            mb.Entity<Category>().Property(x => x.CategoryName)
                .HasColumnType("varchar(64)").IsRequired();
            
            mb.Entity<Category>().Property(x => x.CategoryDescription)
                .HasColumnType("text");

            //Client
            mb.Entity<Client>().HasKey(x => x.ClientID);
            mb.Entity<Client>().Property(x => x.ClientID)
                .UseIdentityColumn(1, 1).HasColumnType("int").IsRequired();
            
            mb.Entity<Client>().Property(x => x.FirstName)
                .HasColumnType("varchar(30)").IsRequired();
            
            mb.Entity<Client>().Property(x => x.SecondName)
                .HasColumnType("varchar(30)").IsRequired();
            
            mb.Entity<Client>().Property(x => x.EmailAddress)
                .HasColumnType("varchar(255)").IsRequired();
            
            mb.Entity<Client>().Property(x => x.Country)
                .HasColumnType("varchar(50)").IsRequired();
            
            mb.Entity<Client>().Property(x => x.City)
                .HasColumnType("varchar(255)").IsRequired();
            
            mb.Entity<Client>().Property(x => x.Street)
                .HasColumnType("varchar(255)").IsRequired();
            
            mb.Entity<Client>().Property(x => x.BuildingNumber)
                .HasColumnType("varchar(20)").IsRequired();
            
            mb.Entity<Client>().Property(x => x.FlatNumber)
                .HasColumnType("int");

            mb.Entity<Client>().Property(x => x.IsConstClient)
                .HasColumnType("bit").IsRequired();

            mb.Entity<Client>().Property(x => x.Login)
                .HasColumnType("varchar(20)").IsRequired();

            mb.Entity<Client>().Property(x => x.Password)
                .HasColumnType("varchar(32)").IsRequired();

            //Order
            mb.Entity<Order>().HasKey(x => x.OrderID);
            mb.Entity<Order>().Property(x => x.OrderID)
                .UseIdentityColumn(1, 1).HasColumnType("int").IsRequired();

            mb.Entity<Order>().Property(x => x.ClientID)
                .HasColumnType("int").IsRequired();

            mb.Entity<Order>().Property(x => x.ReceivedDate)
                .HasColumnType("datetime").IsRequired();

            mb.Entity<Order>().Property(x => x.PreparedDate)
                .HasColumnType("date");

            mb.Entity<Order>().Property(x => x.SentDate)
                .HasColumnType("date");

            mb.Entity<Order>().Property(x => x.SentToAddress)
                .HasColumnType("text").IsRequired();

            mb.Entity<Order>().Property(x => x.IsInvoiced)
                .HasColumnType("bit").IsRequired();

            mb.Entity<Order>().Property(x => x.Invoice)
                .HasColumnType("varbinary(max)");

            mb.Entity<Order>().Property(x => x.InvoiceCopy)
                .HasColumnType("varbinary(max)");

            //OrderDetail
            mb.Entity<OrderDetail>().HasKey("OrderID", "ProductID");

            mb.Entity<OrderDetail>().Property(x => x.OrderID)
                .HasColumnType("int").IsRequired();

            mb.Entity<OrderDetail>().Property(x => x.ProductID)
                .HasColumnType("int").IsRequired();

            mb.Entity<OrderDetail>().Property(x => x.Quantity)
                .HasColumnType("int").IsRequired();

            mb.Entity<OrderDetail>().Property(x => x.UnitPrice)
                .HasColumnType("money").IsRequired();


            //Parameter

            //Product

            //ProductParameter

            //ProductPicture

            //VAT

        }
    }
}
