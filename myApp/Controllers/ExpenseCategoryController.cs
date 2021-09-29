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

        public IActionResult Delete(int? Id)
        {   
            if(Id >= 0)
            {
                ExpenseCate obj = _db.ExpenseCategory.Find(Id);
                if(obj != null)
                {
                    return View(obj);
                }
                else
                {
                    return NotFound();
                }
                
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            if(Id != null)
            {
                ExpenseCate obj = _db.ExpenseCategory.Find(Id);
                if (obj != null)
                {
                    _db.ExpenseCategory.Remove(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }


            }
            else
            {
                return NotFound();
            }

            
        }

        public IActionResult Update(int? Id)
        {
            if(Id != null)
            {
                ExpenseCate obj = _db.ExpenseCategory.Find(Id);
                if(obj != null)
                {
                    return View(obj);
                }
                else
                {
                    return NotFound();
                }
                
            }
            else
            {
                return NotFound();
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseCate obj)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseCategory.Update(obj);
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
