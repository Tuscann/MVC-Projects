using BorrowInAndOut.Data;
using BorrowInAndOut.Models__DomainClasses_;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BorrowInAndOut.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;

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
        public ActionResult Create(Item obj)
        {
            _db.Items.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
