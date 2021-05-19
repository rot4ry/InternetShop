using DatabaseBuilder.Entities;
using System.Collections.Generic;

namespace DatabaseBuilder.RandomCreator
{
    /// <summary>
    /// Randomizes Product data and saves it in the DB
    /// </summary>
    public class ProductCreator
    { 
        private MyContext __Context { get; set; }
        private List<Category> Categories { get; set; }     //list of categories in the db
        private List<Parameter> Parameters { get; set; }    //list of parameters in the db
        public ProductCreator(string connectionString)
        {
            __Context = new MyContext(connectionString);
            __Context.Database.EnsureCreated();
        }

        public void Randomize()
        {
            //Category category =  select random from categories - > id 
            //Category -> selects picture
            //category selects parameters

            Product product = new Product()
            {
                CategoryID = 2,
                ProductName = "",
                Brand = "",
                UnitPrice = 20.3M,
                QtAvailable = 3,
                ProducerCode = "",
                ProductDescription = ""
            };
        }

        public bool SaveToDatabase()
        {
            return true;
        }
    }
}
