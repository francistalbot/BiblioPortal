using BiblioPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiblioPortal.Controllers
{
    public class ClientsController : Controller
    {
        private BiblioDbContext _context;
        public ClientsController(BiblioDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IActionResult Index()
        {
            //Generate elements of MembershipType linked to Clients
            var clients = _context.Clients.Include(c => c.MembershipType);
            return View(clients);
        }
    }
}
