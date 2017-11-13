using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models.ViewModels
{
    public class ProjectRoleVM
    {
        //Add PRId for Index View
        public int ProjectRoleId { get; set; }
        public string ProjectName { get; set; }
        public string PersonName { get; set; }
        public string RoleName { get; set; }
    }
}
