using System.ComponentModel.DataAnnotations;

namespace INET_Project.Models
{
    /// <summary>
    /// Describes database table
    /// </summary>
    public class OrderDetail
    {
        [Key]
        public int OrderID { get; set; }    //Primare && Foreign Key
        public int ProductID { get; set; }  //Primare && Foreign Key
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
