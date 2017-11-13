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
    public class DbRoleRepo : IRoleRepo
    {
        private ProjectRoleDbContext _db;

        public DbRoleRepo(ProjectRoleDbContext db)
        {
            _db = db;
        }

        public Role Create(Role role)
        {
            _db.Roles.Add(role);
            _db.SaveChanges();
            return role;
        }

        public void Delete(int id)
        {
            Role role = _db.Roles.Find(id);
            _db.Roles.Remove(role);
            _db.SaveChanges();
        }

        public Role Read(int id)
        {
            return _db.Roles.Include(p => p.ProjectRoles)
                .FirstOrDefault(p => p.Id == id);
        }

        public ICollection<Role> ReadAll()
        {
            return _db.Roles.Include(p => p.ProjectRoles).ToList();
        }

        public void Update(int id, Role role)
        {
            _db.Entry(role).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
