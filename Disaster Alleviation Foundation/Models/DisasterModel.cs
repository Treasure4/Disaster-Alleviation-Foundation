using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Disaster_Alleviation_Foundation.Models
{
    public class DisasterModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "You need to enter the Start Date")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "You need to enter the End Date")]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "You need to enter the Location")]
        [Display(Name = "Location")]
        [StringLength(100)]
        public string Location { get; set; }

        [Required(ErrorMessage = "You need to enter the Description")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Aid Type")]
        public string AidType { get; set; }

        [Display(Name = "Active disaster")]
        public bool ActiveDisasters { get; set; }

        public List<AllocationsModel> MoneyAllocations { get; set;}
        public List<GoodsDonationModel> GoodsAllocation { get; set;}
    }
}
