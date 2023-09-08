using BagShop.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BagShop.Models
{
    public class Manufacturer:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Manufacturer logo")]
        [Required(ErrorMessage = "Manufacturer logo is required")]
        public string ManufacturerLogoURL { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 chars")]
        public string Name { get; set; }

        [Display(Name = "Foundation Year")]
        [Required(ErrorMessage = "Foundation Year is required")]
        public int FoundationYear { get; set; }

        //Relationships
        public List<Bag> Bags { get; set; }
    }
}
