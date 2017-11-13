using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Project2.Models.Entities;
using Project2.Models.ViewModels;
using Project2.Services.Interfaces;

namespace Project2.Controllers
{
    public class ProjectRoleController : Controller
    {
        private IProjectRoleRepo _projectroles;
        private IProjectRepo _projects;
        private IPersonRepo _people;
        private IRoleRepo _roles;

        public ProjectRoleController(IProjectRoleRepo projectroles, IProjectRepo projects, IPersonRepo people, IRoleRepo roles)
        {
            _projectroles = projectroles;
            _projects = projects;
            _people = people;
            _roles = roles;
        }


        public IActionResult Index()
        {
            var model = _projectroles.ReadAll()
                .Select(pr => new ProjectRoleVM
                {
                    ProjectRoleId = pr.Id,
                    ProjectName = pr.Project.Name,
                    PersonName = pr.Person.FirstName + " " + pr.Person.MiddleName + " " + pr.Person.LastName,
                    RoleName = pr.Role.Name
                });
            return View(model);
        }

        public IActionResult AssignRole()
        {
            var model = _projects.ReadAll()
                .Select(p => new SelectProjectVM
                {
                    ProjectId = p.Id,
                    ProjectName = p.Name
                });
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SelectPerson(int projectId)
        {
            var names = _people.ReadAll()
                .Select(p => new PersonNameVM
                {
                    Id = p.Id,
                    Name = p.FirstName + " " + p.LastName
                });
            var model = new SelectPersonVM
            {
                ProjectId = projectId, PersonNames = names
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SelectRole(int projectId, int personId)
        {
            var names = _roles.ReadAll()
                .Select(r => new RoleNameVM
                {
                    Id = r.Id,
                    Name = r.Name
                });
            var model = new SelectRoleVM
            {
                ProjectId = projectId,
                PersonId = personId,
                RoleNames = names
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AssignProjectRole(int projectId, int personId, int roleId)
        {
            var project = _projects.Read(projectId);
            var person = _people.Read(personId);
            var role = _roles.Read(roleId);

            var pr = new ProjectRole {Project = project, Person = person, Role = role};
            _people.AssignProjectRole(personId, pr);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var projectrole = _projectroles.Read(id);
            if (projectrole == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var selectprojectvm = _projects.ReadAll()
                .Select(p => new SelectProjectVM
                {
                    ProjectId = p.Id,
                    ProjectName = p.Name
                });

            var personnamevm = _people.ReadAll()
                .Select(p => new PersonNameVM
                {
                    Id = p.Id,
                    Name = p.FirstName + " " + p.LastName
                });

            var rolenamevm = _roles.ReadAll()
                .Select(r => new RoleNameVM
                {
                    Id = r.Id,
                    Name = r.Name
                });

            ViewData["projectvm"] = selectprojectvm;    // Pass Ids and Names through VMs in ViewData params for use in partial views
            ViewData["personvm"] = personnamevm;
            ViewData["rolevm"] = rolenamevm;

            ViewBag.projectid = projectrole.ProjectId;  // Store Ids as ints in ViewBags for use in View Selects
            ViewBag.personid = projectrole.PersonId;
            ViewBag.roleid = projectrole.RoleId;

        return View(projectrole);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditProjectRoleVM model)
        {
            if (ModelState.IsValid)
            {
                var projectrole = _projectroles.Read(id);
                projectrole.ProjectId = model.ProjectId;
                projectrole.PersonId = model.PersonId;
                projectrole.RoleId = model.RoleId;
                _projectroles.Update(id, projectrole);
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Delete(int id)
        {
            var pr = _projectroles.Read(id);
            ProjectRoleVM prVM = new ProjectRoleVM
                {
                    ProjectName = pr.Project.Name,
                    PersonName = pr.Person.FirstName + " " + pr.Person.MiddleName + " " + pr.Person.LastName,
                    RoleName = pr.Role.Name
                };
            return View(prVM);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _projectroles.Delete(id);
            return RedirectToAction("Index");
        }



        // Action to show people and roles grouped by project
        public IActionResult PersonRolesByProject()
        {
            var projects = _projects.ReadAll();
            var projectroles = _projectroles.ReadAll();
            var query = projects
                .GroupJoin(
                    projectroles,
                    p => new {ProjectId = p.Id, ProjectName = p.Name},
                    pr => new {ProjectId = pr.ProjectId, ProjectName = pr.Project.Name},
                    (p, roles) => new {Project = p, ProjectRoles = roles})
                .Select(pg => new ProjectGroupVM
                {
                    ProjectName = pg.Project.Name,
                    ProjectRoles = pg.ProjectRoles
                });
            var model = query.ToList();
            return View(model);
        }

        //Action to show Project and Roles grouped by Person
        public IActionResult ProjectRolesByPerson()
        {
            var people = _people.ReadAll();
            var projectroles = _projectroles.ReadAll();
            var query = people
                .GroupJoin(
                    projectroles,
                    p => new { PersonId = p.Id, PersonName = p.FirstName + " " + p.MiddleName + " " + p.LastName },
                    pr => new { PersonId = pr.PersonId, PersonName = pr.Person.FirstName + " " + pr.Person.MiddleName + " " + pr.Person.LastName },
                    (p, roles) => new { Person = p, ProjectRoles = roles })
                .Select(pg => new PersonGroupVM
                {
                    PersonName = pg.Person.FirstName + " " + pg.Person.MiddleName + " " + pg.Person.LastName,
                    ProjectRoles = pg.ProjectRoles
                });
            var model = query.ToList();
            return View(model);
        }
    }
}
 