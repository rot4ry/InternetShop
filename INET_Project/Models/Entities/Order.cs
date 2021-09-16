using System;
using System.ComponentModel.DataAnnotations;

namespace INET_Project.Models
{
    /// <summary>
    /// Describes database table
    /// </summary>
    public class Order
    {
        [Key]

        [Display(Name = "ID zamówienia ")]
        public int OrderID { get; set; }    //Primary Key
        [Display(Name = "ID klienta ")]
        public int ClientID { get; set; }   //Foreign Key
        public DateTime? ReceivedDate { get; set; }

        [Display(Name = "Data zamówienia: ")]
        public DateTime? PreparedDate { get; set; }
        public DateTime? SentDate { get; set; }
        public string SentToAddress { get; set; }

        [Display(Name = "Zafakturowane ")]
        public bool IsInvoiced { get; set; }


        //Image type -> byte[] ?
        #nullable enable        
        public byte[]? Invoice { get; set; }
        public byte[]? InvoiceCopy { get; set; }
    }
}