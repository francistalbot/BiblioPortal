using BiblioPortal.Models;
using BiblioPortal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Save(Client client) 
        { 
            if (client.Id == 0) 
                _context.Clients.Add(client);
            else
            {
                var clientInDb = _context.Clients.Single(c => c.Id == client.Id);
                clientInDb.Name = client.Name;
                clientInDb.DateOfBirth = client.DateOfBirth;
                clientInDb.Phone = client.Phone;
                clientInDb.Email = client.Email;
                clientInDb.IsSubscribeToNewsletter
                    = client.IsSubscribeToNewsletter;


            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Clients"); 
        }    
        public IActionResult Details(int id)
        {
            var client = _context.Clients
                .Include(c => c.MembershipType)     //Inclut les MembershipType en Relation
                .Include(c => c.Locations)          //Inclut les Locations en Relation
                .ThenInclude(c => c.Outil)          //Ensuit inclut les outils en relation avec les Locations
                .SingleOrDefault(c => c.Id == id);

            if (client == null)
                return NotFound(); // Renvoie une erreur 404 si l'outil n'existe pas
            return View(client);
        }
        public IActionResult Edit(int id)
        {
            var client = _context.Clients
                .Include(c => c.MembershipType)     //Inclut les MembershipType en Relation
                .Include(c => c.Locations)          //Inclut les Locations en Relation
                .ThenInclude(c => c.Outil)          //Ensuit inclut les outils en relation avec les Locations
                .SingleOrDefault(c => c.Id == id);

            if (client == null)
                return NotFound(); // Renvoie une erreur 404 si l'outil n'existe pas
            var viewmodel = new ClientFormViewModel
            {
                Client = client,
                MembershipTypes = _context.MembershipTypes,
            };
            return View("ClientForm", viewmodel);
        }
    }
}
