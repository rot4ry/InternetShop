using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INET_Project.Models
{
    public class ProductModel
    {
        public Product Product { get; set; }
        public ProductPicture ProductPicture { get; set; }

        public ProductModel Copy()
        {
            return (ProductModel) this.MemberwiseClone();
        }
    }
}
