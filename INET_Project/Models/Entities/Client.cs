using System.ComponentModel.DataAnnotations;

namespace INET_Project.Models
{
    /// <summary>
    /// Describes database table
    /// </summary>
    public class Client
    {
        public int ClientID { get; set; }   //Primary Key

        [Required]
        [Display(Name = "Imię: ")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Nazwisko: ")]
        public string SecondName { get; set; }
        [Required]
        [Display(Name = "Adres e-mail: ")]
        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "Kraj: ")]
        public string Country { get; set; }
        [Required]
        [Display(Name = "Miasto: ")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Ulica: ")]
        public string Street { get; set; }
        [Required]
        [Display(Name = "Numer budynku/lokalu: ")]
        public string BuildingNumber { get; set; }
        public int? FlatNumber { get; set; }
        public bool IsConstClient { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
