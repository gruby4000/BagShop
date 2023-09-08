using BagShop.Models;
using System.Collections.Generic;

namespace BagShop.Data.ViewModels
{
    public class NewBagDropdownsVM
    {
        public NewBagDropdownsVM()
        {
            Manufacturers = new List<Manufacturer>();
            Designers = new List<Designer>();
            Materials = new List<Material>();
        }

        public List<Manufacturer> Manufacturers { get; set; }
        public List<Designer> Designers { get; set; }
        public List<Material> Materials { get; set; }
    }
}
