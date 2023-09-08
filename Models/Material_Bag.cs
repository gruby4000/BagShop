
namespace BagShop.Models
{
    public class Material_Bag
    {
        public int BagId { get; set; }
        public Bag Bag { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }
    }
}
