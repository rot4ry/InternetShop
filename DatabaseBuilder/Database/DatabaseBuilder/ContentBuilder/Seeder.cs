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
        }

        public void AddProducts()
        {

        }

        public void AddClients()
        {
            Console.WriteLine("---------\nCreating Clients:");
            ClientCreator clientCreator = new ClientCreator(ConnectionString);
            clientCreator.SaveToDatabaseSequentially();
        }
        public void AddCategories()
        {
            Console.WriteLine("---------\nCreating Categories:");
            CategoryCreator categoryCreator = new CategoryCreator(ConnectionString);
            categoryCreator.SaveToDatabaseSequentially();
        }
        public void AddParameters()
        {
            Console.WriteLine("---------\nCreating Parameters:");
            ParameterCreator parameterCreator = new ParameterCreator(ConnectionString);
            parameterCreator.SaveToDatabaseSequentially();
        }
        public void AddVat()
        {
            Console.WriteLine("---------\nCreating VAT:");
            VatCreator vatCreator = new VatCreator(ConnectionString);
            vatCreator.SaveToDatabaseSequentially();
        }
    }
}
