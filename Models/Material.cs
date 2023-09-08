using BagShop.Data.Base;
using BagShop.Models;
using BagShop.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BagShop.Models
{
    public class Material : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 chars")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Density")]
        [Required(ErrorMessage = "Density is required")]
        public decimal Density { get; set; }

        [Display(Name = "Price")]
        [Range(0.1, 100, ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        //Relationships
        public List<Material_Bag> Materials_Bags { get; set; }
    }
}
