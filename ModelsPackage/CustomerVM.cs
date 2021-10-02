using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelsPackage
{
    public class CustomerVM
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false), MinLength(6), MaxLength(49)]

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]

        [Required(AllowEmptyStrings = false), MinLength(6), MaxLength(49)]

        public string LastName { get; set; }

        [Display(Name = "Registered for newsLetter")]
        public bool RegisteredForNewsLetter { get; set; }
    }
}
