using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models.Entities
{
    public class ProjectRole
    {
        // Added Id to allow for edit and delete
        public int Id { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
