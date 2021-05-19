namespace DatabaseBuilder.Entities
{
    /// <summary>
    /// Describes database table
    /// </summary>
    public class Client
    {
        public int ClientID { get; set; }   //Primary Key
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string EmailAddress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public int? FlatNumber { get; set; }
        public bool IsConstClient { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
