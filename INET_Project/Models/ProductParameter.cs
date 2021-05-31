namespace INET_Project.Models
{
    /// <summary>
    /// Describes database table
    /// </summary>
    public class ProductParameter
    {
        public int ParameterID { get; set; }    //Primary && Foreign Key
        public int ProductID { get; set; }  //Primary && Foreign Key
        public int? ParameterValueInt { get; set; }
        public decimal? ParameterDecimal { get; set; }
        
        #nullable enable
        public string? ParameterValueText { get; set; } 
    }
}
