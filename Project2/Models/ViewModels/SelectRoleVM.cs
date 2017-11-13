using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models.ViewModels
{
    public class RoleNameVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SelectRoleVM
    {
        public int ProjectId { get; set; }
        public int PersonId { get; set; }
        public IEnumerable<RoleNameVM> RoleNames { get; set; }
    }
}
