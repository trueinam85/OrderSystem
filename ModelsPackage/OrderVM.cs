using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsPackage
{
    public class OrderVM
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderLineVM> OrderLines { get; set; } = new List<OrderLineVM>();

    }
}
