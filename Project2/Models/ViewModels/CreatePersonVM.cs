using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Project2.Models.Entities;

namespace Project2.Models.ViewModels
{
    public class CreatePersonVM
    {
        [Required, StringLength(30), DisplayName("First Name")]
        public string FirstName { get; set; }

        [StringLength(30), DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [Required, StringLength(30), DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public Person CreatePerson()
        {
            return new Person { FirstName = FirstName, MiddleName = MiddleName, LastName = LastName, Email = Email };
        }
    }
}
