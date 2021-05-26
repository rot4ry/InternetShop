using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INET_Project.Models
{

    public enum Type
    {
        [Display(Name = "Zwrot")]
        Return,
        [Display(Name = "Reklamacja")]
        Replacement,
    }

    public class ReturnDetail
    {
        [Display(Name = "ID zamówienia")]
        public int OrderId { get; set; }
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [Display(Name = "Data zakupu")]
        public DateTime DateOfPurchase { get; set; }
        [Display(Name = "Data otrzymania zamówienia")]
        public DateTime DateOfReceiving { get; set; }
        [Display(Name = "Nazwa produktu")]
        public string ProductName { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
    }
}
