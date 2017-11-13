using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project2.Models.Entities;

namespace Project2.Models.DbContexts
{
    public class ProjectRoleDbContext : DbContext
    {
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ProjectRole> ProjectRoles { get; set; }

        public ProjectRoleDbContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ProjectRole>()
        //        .HasKey(pr => new { pr.ProjectId, pr.PersonId, pr.RoleId });
        //}

    }
}
