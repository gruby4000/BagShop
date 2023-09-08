using BagShop.Data;
using BagShop.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BagShop.Models
{
    public class NewBagVM
    {
        public int Id { get; set; }

        [Display(Name = "Bag name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Bag description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Bag image URL")]
        [Required(ErrorMessage = "Bag image URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Bag category is required")]
        public BagCategory BagCategory { get; set; }

        //Relationships
        [Display(Name = "Select material(s)")]
        [Required(ErrorMessage = "Material(s) is(are) required")]
        public List<int> MaterialIds { get; set; }

        [Display(Name = "Select a Designer")]
        [Required(ErrorMessage = "Designer is required")]
        public int DesignerId { get; set; }

        [Display(Name = "Select a Manufacturer")]
        [Required(ErrorMessage = "Manufacturer is required")]
        public int ManufacturerId { get; set; }
    }
}
