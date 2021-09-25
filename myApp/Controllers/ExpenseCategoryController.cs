using Microsoft.AspNetCore.Mvc;
using myApp.Data;
using myApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        private readonly ApplicationDBContext _db;
        public ExpenseCategoryController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseCate> objList = _db.ExpenseCategory;

            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(ExpenseCate obj)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseCategory.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound(obj);
            }
        }
    }
}
