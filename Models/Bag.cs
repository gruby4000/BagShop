using BagShop.Data;
using BagShop.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BagShop.Models
{
    public class Bag:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public BagCategory BagCategory { get; set; }

        //Relationships
        public List<Material_Bag> Materials_Bags { get; set; }

        //Designer
        public int DesignerId { get; set; }
        [ForeignKey("DesignerId")]
        public Designer Designer { get; set; }

        //Manufacturer
        public int ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public Manufacturer Manufacturer { get; set; }
    }
}
