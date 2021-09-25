using Microsoft.AspNetCore.Mvc;
using myApp.Data;
using myApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDBContext _db;
        public ExpenseController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;
            return View(objList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Expense obj)
        {
            if (ModelState.IsValid)
            {

                _db.Expenses.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        
        public IActionResult Delete(int? Id)
        {
            if (Id != null || Id != 0)
            {
                Expense obj = _db.Expenses.Find(Id);
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(obj);
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            Expense obj = _db.Expenses.Find(Id);
            if(obj != null)
            {
                _db.Expenses.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
               return NotFound();
            }

        }

        public IActionResult Update(int? Id)
        {
            if(Id != null || Id !=0)
            {
                Expense obj = _db.Expenses.Find(Id);

                if (obj == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(obj);
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
