using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.Models.Entities;

namespace Project2.Services.Interfaces
{
    public interface IProjectRoleRepo
    {
        ICollection<ProjectRole> ReadAll();
        ProjectRole Read(int id);
        void Update(int id, ProjectRole projectrole);
        void Delete(int id);
    }
}
