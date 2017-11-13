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
    public class DbProjectRepo : IProjectRepo
    {
        private ProjectRoleDbContext _db;

        public DbProjectRepo(ProjectRoleDbContext db)
        {
            _db = db;
        }

        public Project Create(Project project)
        {
            _db.Projects.Add(project);
            _db.SaveChanges();
            return project;
        }

        public void Delete(int id)
        {
            Project project = _db.Projects.Find(id);
            _db.Projects.Remove(project);
            _db.SaveChanges();
        }

        public Project Read(int id)
        {
            return _db.Projects.Include(p => p.ProjectRoles)
                .FirstOrDefault(p => p.Id == id);
        }

        public ICollection<Project> ReadAll()
        {
            return _db.Projects.Include(p => p.ProjectRoles).ToList();
        }

        public void Update(int id, Project project)
        {
            _db.Entry(project).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
