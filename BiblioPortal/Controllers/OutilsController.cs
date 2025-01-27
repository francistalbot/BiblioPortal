
using BiblioPortal.Models;
using BiblioPortal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiblioPortal.Controllers
{
    public class OutilsController : Controller
    {
        private BiblioDbContext _context;
        public OutilsController(BiblioDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var outils = _context.Outils;
            return View(outils);
        }

        public ActionResult Details(int id)
        {
            var outil = _context.Outils
                .Include(o => o.Locations)      //Inclut les Location en relations
                .ThenInclude(l => l.Client)     //Charge aussi les Client en relations avec les Locations
                .SingleOrDefault(c => c.Id == id);
            if (outil == null)
            {
                return NotFound(); // Renvoie une erreur 404 si l'outil n'existe pas
            }
            return View(outil);
        }
        //GET: Outils/Random
        public IActionResult Random()
        {
            var outil = new Outil() { Name = "Marteau" };
            var clients = new List<Client>()
            {
                new Client() { Id = 1, Name = "Francis"},
                new Client() { Id = 2, Name = "Patrick"},
            };

            var viewModel = new RandomOutilsViewModels
            {
                Outil = outil,
                Clients = clients
            };
            return View(viewModel);
        }
        public IActionResult Edit(int id)
        {
            var outil = _context.Outils
                .SingleOrDefault(c => c.Id == id);

            if (outil == null)
                return NotFound(); // Renvoie une erreur 404 si l'outil n'existe pas
            return View("OutilForm", outil);
        }
        public IActionResult New()
        {
            var outil = new Outil();
            
            return View("OutilForm", outil);
        }
        public IActionResult Save(Outil outil)
        {
            if (outil.Id == 0)
                _context.Outils.Add(outil);
            else
            {
                var outilInDb = _context.Outils.Single(c => c.Id == outil.Id);
                outilInDb.Name = outil.Name;
                outilInDb.Description = outil.Description;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Outils");
        }
        public ActionResult List(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "name";
            return Content(String.Format("pageIndex={0}}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("outils/released/{year:regex(\\d{{4}})}/{month:regex(\\d{{2}}):range(1, 12)}")] // /outils/released/1234/01
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}
