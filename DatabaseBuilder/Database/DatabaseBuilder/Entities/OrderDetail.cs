namespace DatabaseBuilder.Entities
{
    public class OrderDetail
    {
        public int OrderID { get; set; }    //Primare && Foreign Key
        public int ProductID { get; set; }  //Primare && Foreign Key
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
