using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.Models.Entities;

namespace Project2.Services.Interfaces
{
    public interface IRoleRepo
    {
        Role Create(Role role);

        Role Read(int id);

        ICollection<Role> ReadAll();

        void Update(int id, Role role);

        void Delete(int id);
    }
}
