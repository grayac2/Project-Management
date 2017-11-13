using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Project2.Models.Entities;

namespace Project2.Models.ViewModels
{
    public class CreateRoleVM
    {
        [Required, StringLength(30)]
        public string Name { get; set; }

        [StringLength(450)]
        public string Description { get; set; }

        public Role CreateRole()
        {
            return new Role { Name = Name, Description = Description };
        }
    }
}
