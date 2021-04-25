using System;

namespace DatabaseBuilder.Entities
{
    public class VAT
    {
        public DateTime DateSince { get; set; } //Primary Key
        public DateTime? DateChanged { get; set; }
        public decimal Value { get; set; }
    }
}
