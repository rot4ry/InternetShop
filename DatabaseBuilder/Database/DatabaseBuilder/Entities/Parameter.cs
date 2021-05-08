namespace DatabaseBuilder.Entities
{
    /// <summary>
    /// Describes database table
    /// </summary>
    public class Parameter
    {
        public int ParameterID { get; set; }    //Primary Key  
        public string ParameterName { get; set; }

        #nullable enable
        public string? ParameterDescription { get; set; }  
    }
}
