using BorrowInAndOut.Data;
using BorrowInAndOut.Models__DomainClasses_;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BorrowInAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;

            return View(objList);
        }

        // GET Create
        public ActionResult Create()
        {
            return View();
        }

        // POST Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult Create(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET Delete
        public IActionResult Delete(int? id)
        {           
            if (id == null || id==0)
            {
                return NotFound();
            }
            Expense obj = _db.Expenses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Expenses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
           
            _db.Expenses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET Update       
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Expense obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        // POST Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
