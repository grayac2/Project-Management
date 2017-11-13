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
    public class RoleController : Controller
    {
        private IRoleRepo _roles;

        public RoleController(IRoleRepo roles)
        {
            _roles = roles;
        }

        public IActionResult Index()
        {
            return View(_roles.ReadAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateRoleVM rolevm)
        {
            if (ModelState.IsValid)
            {
                Role role = rolevm.CreateRole();
                _roles.Create(role);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var role = _roles.Read(id);
            if (role == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(role);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditRoleVM model)
        {
            if (ModelState.IsValid)
            {
                var role = _roles.Read(id);
                role.Name = model.Name;
                role.Description = model.Description;
                _roles.Update(id, role);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var role = _roles.Read(id);
            if (role == null)
            {
                return RedirectToAction("Index");
            }
            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _roles.Delete(id);
            return RedirectToAction("Index");
        }

    }
}