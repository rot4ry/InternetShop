using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBuilder.Entities
{
    public class ProductParameter
    {
        public int ParameterID { get; set; }    //Primary && Foreign Key
        public int ProductID { get; set; }  //Primary && Foreign Key
        public string ParameterValueText { get; set; }  //Not nullable!
        public int? ParameterValueInt { get; set; }
        public decimal? ParameterDecimal { get; set; }   
    }
}
