using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBuilder.Entities
{
    public class VAT
    {
        public DateTime DateSince { get; set; } //Primary Key
        public DateTime? DateChanged { get; set; }
        public decimal Value { get; set; }
    }
}
