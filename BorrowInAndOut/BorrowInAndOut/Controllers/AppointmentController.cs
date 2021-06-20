using System;
using Microsoft.AspNetCore.Mvc;

namespace BorrowInAndOut.Controllers
{
    public class AppointmentController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return Ok("You have entered id ={id}" + id);
        }
    }
}