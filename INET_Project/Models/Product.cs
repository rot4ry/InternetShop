namespace INET_Project.Models
{
    /// <summary>
    /// Describes database table
    /// </summary>
    public class Product
    {
        public int ProductID { get; set; }  //Primary Key
        public int CategoryID { get; set; } //Foreign Key
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public decimal UnitPrice { get; set; }
        public int QtAvailable { get; set; }
        public string ProducerCode { get; set; }
        
        #nullable enable
        public string? ProductDescription { get; set; } 
    }
}
