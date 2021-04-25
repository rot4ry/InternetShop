namespace DatabaseBuilder.Entities
{
    public class Product
    {
        public int ProductID { get; set; }  //Primary Key
        public int CategoryID { get; set; } //Foreign Key
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string ProductDescription { get; set; }  //Not nullable!
        public string ProducerCode { get; set; }
    }
}
