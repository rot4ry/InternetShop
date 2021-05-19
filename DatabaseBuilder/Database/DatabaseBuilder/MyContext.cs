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
            mb.Entity<Parameter>().HasKey(x => x.ParameterID);
            mb.Entity<Parameter>().Property(x => x.ParameterID)
                .UseIdentityColumn(1, 1).HasColumnType("int").IsRequired();

            mb.Entity<Parameter>().Property(x => x.ParameterName)
                .HasColumnType("varchar(64)").IsRequired();

            mb.Entity<Parameter>().Property(x => x.ParameterDescription)
                .HasColumnType("text");

            //Product
            mb.Entity<Product>().HasAnnotation("SET IDENTITY_INSERT", "ON");
            mb.Entity<Product>().HasKey(x => x.ProductID);
            mb.Entity<Product>().Property(x => x.ProductID)
                .HasColumnType("int").IsRequired();

            mb.Entity<Product>().Property(x => x.CategoryID)
                .HasColumnType("int").IsRequired();

            mb.Entity<Product>().Property(x => x.ProductName)
                .HasColumnType("text").IsRequired();

            mb.Entity<Product>().Property(x => x.Brand)
                .HasColumnType("varchar(64)").IsRequired();

            mb.Entity<Product>().Property(x => x.UnitPrice)
                .HasColumnType("money").IsRequired();

            mb.Entity<Product>().Property(x => x.QtAvailable)
                .HasColumnType("int").IsRequired();

            mb.Entity<Product>().Property(x => x.ProductDescription)
                .HasColumnType("text");

            mb.Entity<Product>().Property(x => x.ProducerCode)
                .HasColumnType("varchar(255)").IsRequired();

            //ProductParameter
            mb.Entity<ProductParameter>().HasKey("ProductID", "ParameterID");
            mb.Entity<ProductParameter>().Property(x => x.ProductID)
                .HasColumnType("int").IsRequired();
            mb.Entity<ProductParameter>().Property(x => x.ParameterID)
                .HasColumnType("int").IsRequired();

            mb.Entity<ProductParameter>().Property(x => x.ParameterDecimal)
                .HasColumnType("decimal(5,2)");

            mb.Entity<ProductParameter>().Property(x => x.ParameterValueInt)
                .HasColumnType("int");

            mb.Entity<ProductParameter>().Property(x => x.ParameterValueText)
                .HasColumnType("text");

            //ProductPicture
            mb.Entity<ProductPicture>().HasKey(x => x.PictureID);
            mb.Entity<ProductPicture>().Property(x => x.PictureID)
                .UseIdentityColumn(1, 1).HasColumnType("int").IsRequired();

            mb.Entity<ProductPicture>().Property(x => x.ProductID)
                .HasColumnType("int").IsRequired();

            mb.Entity<ProductPicture>().Property(x => x.Picture)
                .HasColumnType("varbinary(max)").IsRequired();

            //VAT
            mb.Entity<VAT>().HasKey(x => x.DateSince);
            mb.Entity<VAT>().Property(x => x.DateSince)
                .HasColumnType("datetime").IsRequired();

            mb.Entity<VAT>().Property(x => x.DateChanged)
                .HasColumnType("datetime");

            mb.Entity<VAT>().Property(x => x.Value)
                .HasColumnType("decimal(3,2)").IsRequired();
        }
    }
}
