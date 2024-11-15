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
        public IActionResult Index()
        {
            var clients = _context.Clients;
            return View(clients);
        }
    }
}
