using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.Models.Entities;

namespace Project2.Models.ViewModels
{
    public class ProjectGroupVM
    {
        public string ProjectName { get; set; }
        public IEnumerable<ProjectRole> ProjectRoles { get; set; }
    }
}
