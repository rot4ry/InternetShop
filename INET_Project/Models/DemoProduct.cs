using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INET_Project.Models
{
    public class DemoProduct
    {
        [Required]
        [Display(Name = "Nazwa produktu")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Opis produktu")]
        public string Description { get; set; }
        [Display(Name = "Zdjęcie produktu")]
        public string ProductImage { get; set; }
        [Required]
        [Display(Name = "Cena produktu")]
        public decimal Price { get; set; }
    }
}
