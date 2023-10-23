using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Disaster_Alleviation_Foundation.Models
{
    public class CategoryModel
    {
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "You need to enter the Category Name")]
        [StringLength(50)]
        public string Name { get; set; }

        public int ID { get; set; }

    }
}
