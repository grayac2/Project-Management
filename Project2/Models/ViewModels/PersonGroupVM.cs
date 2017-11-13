using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.Models.Entities;

namespace Project2.Models.ViewModels
{
    public class PersonGroupVM
    {
        public string PersonName { get; set; }
        public IEnumerable<ProjectRole> ProjectRoles { get; set; }
    }
}
