using System.ComponentModel.DataAnnotations;

namespace INET_Project.Models
{
    /// <summary>
    /// Describes database table
    /// </summary>
    public class ProductPicture
    {
        [Key]
        public int PictureID { get; set; }  //Primary Key
        public int ProductID { get; set; }  //ForeignKey
        public string PicturePath { get; set; }
    }
}
