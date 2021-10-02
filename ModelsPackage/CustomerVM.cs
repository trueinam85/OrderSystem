using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelsPackage
{
    public class CustomerVM
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Registered for newsLetter")]
        public bool RegisteredForNewsLetter { get; set; }
    }
}
