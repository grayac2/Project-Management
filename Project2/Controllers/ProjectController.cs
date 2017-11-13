using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project2.Models.Entities;
using Project2.Models.ViewModels;
using Project2.Services.Interfaces;

namespace Project2.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectRepo _projects;

        public ProjectController(IProjectRepo projects)
        {
            _projects = projects;
        }

        public IActionResult Index()
        {
            return View(_projects.ReadAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateProjectVM projectvm)
        {
            if (ModelState.IsValid)
            {
                Project project = projectvm.CreateProject();
                _projects.Create(project);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var project = _projects.Read(id);
            if (project == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(project);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditProjectVM model)
        {
            if (ModelState.IsValid)
            {
                var project = _projects.Read(id);
                project.Name = model.Name;
                project.StartDate = model.StartDate;
                project.EndDate = model.EndDate;
                _projects.Update(id, project);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var project = _projects.Read(id);
            if (project == null)
            {
                return RedirectToAction("Index");
            }
            return View(project);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _projects.Delete(id);
            return RedirectToAction("Index");
        }
    }
}