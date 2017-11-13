using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.Models.Entities;

namespace Project2.Services.Interfaces
{
    public interface IProjectRepo
    {
        Project Create(Project project);

        Project Read(int id);

        ICollection<Project> ReadAll();

        void Update(int id, Project project);

        void Delete(int id);
    }
}
