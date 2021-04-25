namespace DatabaseBuilder.Entities
{
    public class Category
    {
        public int CategoryID { get; set; } //Primary Key
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }   //Not nullable!
    }
}
