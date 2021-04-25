//using System.Drawing;

namespace DatabaseBuilder.Entities
{
    public class ProductPicture
    {
        public int PictureID { get; set; }  //Primary Key
        public int ProductID { get; set; }  //ForeignKey
        //public Image Picture { get; set; }
    }
}
