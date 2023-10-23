namespace Disaster_Alleviation_Foundation.Models
{
    public class GoodsAllocation
    {
        public int ID { get; set; }
        public int DisasterID { get; set; }
        public string GoodsDescription { get; set; }
        public int Quantity { get; set; }
    }
}
