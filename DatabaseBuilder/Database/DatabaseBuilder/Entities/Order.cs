using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Drawing.Bitmap;

namespace DatabaseBuilder.Entities
{
    public class Order
    {
        public int OrderID { get; set; }    //Primary Key
        public int ClientID { get; set; }   //Foreign Key
        public DateTime ReceivedDate { get; set; }
        public DateTime? PreparedDate { get; set; }
        public DateTime? SentDate { get; set; }
        public string SentToAddress { get; set; }
        public bool IsInvoiced { get; set; }
        //public Image? Invoice { get; set; }
        //public Image? InvoiceCopy { get; set; }
    }
}
