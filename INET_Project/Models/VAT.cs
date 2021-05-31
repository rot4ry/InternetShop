using System;

namespace INET_Project.Models
{
    /// <summary>
    /// Describes database table
    /// </summary>
    public class VAT
    {
        public DateTime DateSince { get; set; } //Primary Key
        public DateTime? DateChanged { get; set; }
        public decimal Value { get; set; }
    }
}
