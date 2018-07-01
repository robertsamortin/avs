using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using avsserv.Models;
using avsserv.Models.Repo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace avsserv.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: /<controller>/
        private IEmployeesRepo _repo;

        public EmployeesController(IEmployeesRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _repo.GetAll();
            if (model == null)
                ModelState.AddModelError("Error", "No Record Found");
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Employees emp)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Invalid Model");
                return View(emp);
            }
            _repo.Add(emp);
            return RedirectToAction("Index","Employees");
        }

        
    }
}
