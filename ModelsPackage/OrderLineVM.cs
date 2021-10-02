using System.ComponentModel.DataAnnotations;

namespace ModelsPackage
{
    public class OrderLineVM
    {
        [Key]
        public int LineNumber { get; set; }
        public int OrdernNumber { get; set; }
        public int ItemId { get; set; }

        [Display(Name = "Brand")]

        public string ItemBrand { get; set; }
        [Display(Name = "Model")]

        public string ItemModel { get; set; }

        [Display(Name = "Color")]

        public string ItemColor { get; set; }

        [Range(0, 999999999)]
        [Required]
        [Display(Name = "Unit Price")]
        public int Price { get; set; }
        [Range(0, 999999999)]
        [Required]
        public int Quantity { get; set; }
    }
}
