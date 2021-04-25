using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBuilder.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string ProductDescription { get; set; }  //Not nullable!
        public string ProducerCode { get; set; }
    }
}
