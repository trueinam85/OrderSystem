using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelsPackage
{
    public class OrderLineVM
    {
        public int LineNumber { get; set; }
        public int OrdernNumber { get; set; }
        public int ItemId { get; set; }
        public string ItenBrand { get; set; }
        public string ItemModel { get; set; }
        public string ItemColor { get; set; }

        [Range(0, 999999999)]
        [Required]
        public int Price { get; set; }
        [Range(0, 999999999)]
        [Required]
        public int Quantity { get; set; }
    }
}
