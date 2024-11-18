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
            var clients = _context.Clients;
            return View(clients);
        }
    }
}
