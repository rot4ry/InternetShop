using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INET_Project.Models
{
    public class CategoryDetail
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Nazwa kategorii jest wymagana")]
        [StringLength(30, ErrorMessage = "Wymagane są minimum 3 znaki", MinimumLength = 3)]
        public string CategoryName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
    public class ProductDetail
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Wymagane są minimum 3 znaki", MinimumLength = 3)]
        public string ProductName { get; set; }
        [Required]
        [Range(1, 50)]
        public Nullable<int> CategoryId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        [Required(ErrorMessage = "Opis jest wymagany")]
        public string Description { get; set; }
        public string ProductImage { get; set; }
        [Required]
        [Range(typeof(int), "1", "500", ErrorMessage = "Nieprawidłowa ilość")]
        public Nullable<int> Quantity { get; set; }
        [Range(typeof(decimal), "1", "500000", ErrorMessage = "Nieprawidłowa cena")]
        public Nullable<decimal> Price { get; set; }
    }
}