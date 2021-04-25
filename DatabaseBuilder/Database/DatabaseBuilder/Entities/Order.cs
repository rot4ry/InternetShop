using System;

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


        //Image type -> byte[] ?
        public byte[] Invoice { get; set; }
        public byte[] InvoiceCopy { get; set; }
    }
}
