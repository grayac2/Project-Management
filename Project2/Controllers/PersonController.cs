using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Project2.Models.Entities;
using Project2.Models.ViewModels;
using Project2.Services.Interfaces;

namespace Project2.Controllers
{
    public class PersonController : Controller
    {
        private IPersonRepo _people;

        public PersonController(IPersonRepo people)
        {
            _people = people;
        }

        public IActionResult Index()
        {
            return View(_people.ReadAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreatePersonVM personvm)
        {
            if (ModelState.IsValid)
            {
                Person person = personvm.CreatePerson();
                _people.Create(person);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var person = _people.Read(id);
            if (person == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(person);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditPersonVM model)
        {
            if (ModelState.IsValid)
            {
                var person = _people.Read(id);
                person.FirstName = model.FirstName;
                person.MiddleName = model.MiddleName;
                person.LastName = model.LastName;
                person.Email = model.Email;
                _people.Update(id, person);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var person = _people.Read(id);
            if (person == null)
            {
                return RedirectToAction("Index");
            }
            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _people.Delete(id);
            return RedirectToAction("Index");
        }
    }
}