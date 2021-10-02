using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsPackage
{
    public class CustomerVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool RegisteredForNewsLetter { get; set; }
    }
}
