using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelsPackage
{
    public class ItemVM
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Quantity must be an integer")]
        [Range(1, 999999999)]
        public int Quantity { get; set; }

    }
}
