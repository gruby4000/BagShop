using BagShop.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BagShop.Models
{
    public class Designer:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Surname Logo")]
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Birthday year")]
        [Required(ErrorMessage = "Birthday year is required")]
        public int BirthdayYear { get; set; }
        [Display(Name = "Nationality")]
        [Required(ErrorMessage = "Nationality is required")]
        public string Nationality { get; set; }

        //Relationships
        public List<Bag> Bags { get; set; }
    }
}
