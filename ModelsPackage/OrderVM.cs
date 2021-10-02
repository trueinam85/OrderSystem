using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelsPackage
{
    public class OrderVM
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        [Required]

        public DateTime OrderDate { get; set; }
        public List<OrderLineVM> OrderLines { get; set; } = new List<OrderLineVM>();

    }
}
