using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OrderSystem.Data
{
    public partial class OrderLines
    {
        public int LineNumber { get; set; }
        public int OrdernNumber { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public virtual Items Item { get; set; }
        public virtual Orders OrdernNumberNavigation { get; set; }
    }
}
