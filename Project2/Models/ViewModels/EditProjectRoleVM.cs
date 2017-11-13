using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models.ViewModels
{
    public class EditProjectRoleVM
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public IEnumerable<PersonNameVM> PersonNames { get; set; }

        public IEnumerable<RoleNameVM> RoleNames { get; set; }
    }
}
