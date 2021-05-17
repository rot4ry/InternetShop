using DatabaseBuilder.FixedCreator;
using DatabaseBuilder.RandomCreator;
using System;

namespace DatabaseBuilder.ContentBuilder
{
    /// <summary>
    /// Uses ClientCreator, ProductCreator, CategoryCreator, ParameterCreator and VatCreator
    /// to fill the database with random OR fixed (required) values.
    /// </summary>
    public class Seeder
    {
        private string ConnectionString { get; set; }
        private int ProductsQt { get; set; }
        public Seeder(string connectionString, int products)
        {
            ConnectionString = connectionString;
            ProductsQt = products;
        }

        public void AddProducts()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("---------\nCreating Products:");
            ProductCreator productCreator = new ProductCreator(ConnectionString);
            for(int i=0; i<=ProductsQt; i++)
            {
                productCreator.SaveToDatabase();
            }
            Console.ResetColor();
        }

        public void AddClients()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------\nCreating Clients:");
            IFix clientCreator = new ClientCreator(ConnectionString);
            clientCreator.SaveToDatabaseSequentially();
            Console.ResetColor();
        }

        public void AddCategories()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---------\nCreating Categories:");
            IFix categoryCreator = new CategoryCreator(ConnectionString);
            categoryCreator.SaveToDatabaseSequentially();
            Console.ResetColor();
        }

        public void AddParameters()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("---------\nCreating Parameters:");
            IFix parameterCreator = new ParameterCreator(ConnectionString);
            parameterCreator.SaveToDatabaseSequentially();
            Console.ResetColor();
        }

        public void AddVat()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("---------\nCreating VAT:");
            IFix vatCreator = new VatCreator(ConnectionString);
            vatCreator.SaveToDatabaseSequentially();
            Console.ResetColor();
        }
    }
}
