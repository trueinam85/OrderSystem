using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelsPackage
{
    public class CustomerVM
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = true), MinLength(3), MaxLength(49)]

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Display(Name = "Last Name")]

        [Required(AllowEmptyStrings = true), MinLength(3), MaxLength(49)]

        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Registered for newsLetter")]
        public bool RegisteredForNewsLetter { get; set; }
    }
}
