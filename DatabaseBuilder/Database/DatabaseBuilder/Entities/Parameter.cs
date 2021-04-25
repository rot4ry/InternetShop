using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBuilder.Entities
{
    public class Parameter
    {
        public int ParameterID { get; set; }    //Primary Key  
        public string ParameterName { get; set; }
        public string ParameterDescription { get; set; }    //Not nullable!
    }
}
