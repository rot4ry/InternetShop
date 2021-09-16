using System.ComponentModel.DataAnnotations;

namespace INET_Project.Models
{
    /// <summary>
    /// Describes database table
    /// </summary>
    public class Product
    {
        public int ProductID { get; set; }  //Primary Key
        public int CategoryID { get; set; } //Foreign Key

        [Display(Name = "Produkt")]
        public string ProductName { get; set; }
        [Display(Name = "Marka")]
        public string Brand { get; set; }
        [Display(Name = "Koszt")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Ilość produktów")]
        public int QtAvailable { get; set; }
        [Display(Name = "Kod producenta")]
        public string ProducerCode { get; set; }

        #nullable enable
        [Display(Name = "Opis produktu")]
        public string? ProductDescription { get; set; } 
    }
}
