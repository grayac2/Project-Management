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
    public class DbProjectRoleRepo : IProjectRoleRepo
    {
        private ProjectRoleDbContext _db;

        public DbProjectRoleRepo(ProjectRoleDbContext db)
        {
            _db = db;
        }

        public ICollection<ProjectRole> ReadAll()
        {
            return _db.ProjectRoles
                .Include(pr => pr.Person)
                .Include(pr => pr.Project)
                .Include(pr => pr.Role)
                .ToList();
        }

        public void Delete(int id)
        {
            ProjectRole projectrole = _db.ProjectRoles.Find(id);
            _db.ProjectRoles.Remove(projectrole);
            _db.SaveChanges();
        }

        public ProjectRole Read(int id)
        {
            return _db.ProjectRoles
                .Include(pr => pr.Person)
                .Include(pr => pr.Project)
                .Include(pr => pr.Role)
                .FirstOrDefault(p => p.Id == id);
        }

        public void Update(int id, ProjectRole projectrole)
        {
            _db.Entry(projectrole).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}