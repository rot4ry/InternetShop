namespace DatabaseBuilder.Entities
{
    /// <summary>
    /// Describes database table
    /// </summary>
    public class Category
    {
        public int CategoryID { get; set; } //Primary Key
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }   //Not nullable!
    }
}
