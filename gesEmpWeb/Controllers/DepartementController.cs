using Microsoft.AspNetCore.Mvc;
using gesEmpWeb.Services;
using gesEmpWeb.Models;

namespace gesEmpWeb.Controllers
{
    public class DepartementController : Controller
    {
        
        private readonly IDepartementService _departementService;
        private readonly ILogger<DepartementController> _logger;
        public DepartementController(ILogger<DepartementController> logger, IDepartementService departementService)
        {
            _departementService = departementService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            try
            {
                int total = _departementService.CountDepartements(page);
                int nbrPages = (int)Math.Ceiling((double)total / 4);
                var departements = _departementService.GetAllDepartements(page);
                ViewBag.NbrPages = nbrPages;
                ViewBag.CurrentPage = page;
                return View(departements);
            }
            catch (Exception)
            {
                _logger.LogError("Erreur lors de l'affichage des départements");
                return View(new List<Departement>());
            }
        }
        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }
    }
}