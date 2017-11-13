using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models.ViewModels
{
    public class EditPersonVM
    {
        [Required, StringLength(30), DisplayName("First Name")]
        public string FirstName { get; set; }

        [StringLength(30), DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [Required, StringLength(30), DisplayName("Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
