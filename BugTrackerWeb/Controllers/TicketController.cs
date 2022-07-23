using BugTrackerWeb.Data;
using BugTrackerWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugTrackerWeb.Controllers
{
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TicketController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<Ticket> objTicketList = _db.Tickets; 
            return View(objTicketList);
        }
        // GET
        public IActionResult Create()
        {
          
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ticket obj)
        {
            if (ModelState.IsValid)
            {

                _db.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);   
        }
        // GET
        public IActionResult Edit(int? id)
        {
            if(id==0 || id == null)
            {
                return NotFound();
            }
            var TicketFromDb = _db.Tickets.Find(id);
            if (TicketFromDb == null)
            {
                return NotFound();
            }
            return View(TicketFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ticket obj)
        {
            if (ModelState.IsValid)
            {

                _db.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        // GET
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var TicketFromDb = _db.Tickets.Find(id);
            if (TicketFromDb == null)
            {
                return NotFound();
            }
            return View(TicketFromDb);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
           var obj = _db.Tickets.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Tickets.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}
