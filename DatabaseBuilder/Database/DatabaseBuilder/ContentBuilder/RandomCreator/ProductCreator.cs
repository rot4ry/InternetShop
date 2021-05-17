using DatabaseBuilder.Entities;

namespace DatabaseBuilder.RandomCreator
{
    /// <summary>
    /// Randomizes Product data and saves it in the DB
    /// </summary>
    public class ProductCreator : IRandomize<Product>
    {
        private MyContext __Context { get; set; }
        public ProductCreator(string connectionString)
        {
            __Context = new MyContext(connectionString);
            __Context.Database.EnsureCreated();
        }

        public Product Randomize()
        {

            return new Product();
        }

        public bool SaveToDatabase()
        {
            return true;
        }
    }
}
