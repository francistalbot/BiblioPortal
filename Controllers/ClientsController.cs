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
        public IActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new ClientFormViewModel 
            {
                MembershipTypes = membershipTypes
            };
            return View("ClientForm", viewModel);
        }

        [HttpPost]
        public IActionResult Create(Client client) 
        { 
            _context.Clients.Add(client);
            _context.SaveChanges();

            return RedirectToAction("Index", "Clients"); 
        }    
        {
            var client = _context.Clients
                .Include(c => c.MembershipType)     //Inclut les MembershipType en Relation
                .Include(c => c.Locations)          //Inclut les Locations en Relation
                .ThenInclude(c => c.Outil)          //Ensuit inclut les outils en relation avec les Locations
                .SingleOrDefault(c => c.Id == id);
            return View(client);
        }
    }
}
