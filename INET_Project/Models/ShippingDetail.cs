using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INET_Project.Models
{

    public enum TypeOfOrder
    {
        [Display(Name = "Przy odbiorze (+25 zł)")]
        OnDelievery,
        [Display(Name = "Przelewem")]
        BankTransfer,
    }

    public class ShippingDetail
    {
        public Client Client { get; set; }
        public Order Order { get; set; }
        public OrderDetail OrderDetail { get; set; }
        [Display(Name = "Metoda płatności")]
        public TypeOfOrder TypeOfOrder { get; set; }
    }
}
