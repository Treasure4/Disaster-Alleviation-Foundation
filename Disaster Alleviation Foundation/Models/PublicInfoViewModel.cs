using Disaster_Alleviation_Foundation.Models;

namespace Disaster_Alleviation_Foundation.Controllers
{
    public class PublicInfoViewModel
    {
        public decimal TotalMonetaryDonations { get; set; }
        public int TotalGoodsReceived { get; set; }
        public List<DisasterModel> ActiveDisasters { get; set; }
        public List<AllocationsModel> Allocations { get; set; }
        public List<GoodsAllocationModel> Goods { get; set; }
    }
}
