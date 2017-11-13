using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project2.Models.DbContexts;
using Project2.Models.Entities;
using Project2.Services.Interfaces;

namespace Project2.Services
{
    public class DbPersonRepo : IPersonRepo
    {
        private ProjectRoleDbContext _db;

        public DbPersonRepo(ProjectRoleDbContext db)
        {
            _db = db;
        }

        public Person Create(Person person)
        {
            _db.People.Add(person);
            _db.SaveChanges();
            return person;
        }

        public void Delete(int id)
        {
            Person person = _db.People.Find(id);
            _db.People.Remove(person);
            _db.SaveChanges();
        }

        public Person Read(int id)
        {
            return _db.People.Include(p => p.ProjectRoles)
                .FirstOrDefault(p => p.Id == id);
        }

        public ICollection<Person> ReadAll()
        {
            return _db.People.Include(p => p.ProjectRoles).ToList();
        }

        public void Update(int id, Person person)
        {
            _db.Entry(person).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void AssignProjectRole(int id, ProjectRole pr)
        {
            var person = Read(id);
            if (person != null)
            {
                person.ProjectRoles.Add(pr);
                _db.Entry(person).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}
