namespace Disaster_Alleviation_Foundation.Models
{
    public class Purchase
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }
    }
}
