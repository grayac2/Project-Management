using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.Models.Entities;

namespace Project2.Services.Interfaces
{
    public interface IPersonRepo
    {
        Person Create(Person person);

        Person Read(int id);

        ICollection<Person> ReadAll();

        void Update(int id, Person person);

        void Delete(int id);
        void AssignProjectRole(int id, ProjectRole model); //May need to be put into each other IRepo
    }
}
