using DotNet6_webApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet6_webApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DotNet6_webApp.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactDbContext _context;

        public ContactsController(ContactDbContext db)
        {
            _context = db;
        }

        // GET:  Api/Contacts
        [HttpGet]
        public async Task<ActionResult<Contact>> GetAll()
        {
            List<Contact> contacts = await _context.Contacts.ToListAsync();

            if (contacts == null)
            {
                return NotFound();
            }

            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> GetContact(int id)
        {
            Contact contact = _context.Contacts.FirstOrDefault(contact => contact.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        public void PostContact(Contact contact)
        {
            _context.Add(contact);
            _context.SaveChanges();
        }
    }
}