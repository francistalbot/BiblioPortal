
using BiblioPortal.Models;
using BiblioPortal.ViewModels;
using Microsoft.AspNetCore.Mvc;

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

        public ViewResult Details(int id)
        {
            var outil = _context.Outils.SingleOrDefault(c => c.Id == id);
            return View(outil);
        }
        //GET: Outils/Random
        public IActionResult Random()
        {
            var outil = new Outil() { name = "Marteau" };
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
        public ActionResult Edit(int id)
        {
            return Content("id="+id);
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
