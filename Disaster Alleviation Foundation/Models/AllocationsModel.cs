using System.ComponentModel.DataAnnotations;

namespace Disaster_Alleviation_Foundation.Models
{
    public class AllocationsModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "You need to enter the Amount")]
        [Display(Name = "Amount")]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Allocation { get; set; }

        [Display(Name = "You need to enter the Catagory")]
        [StringLength(100)]
        public string GoodsCategory { get; set; }

    }
}
