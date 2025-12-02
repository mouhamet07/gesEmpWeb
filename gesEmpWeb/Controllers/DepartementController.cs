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
        public IActionResult Index()
        {
            try
            {
                var departements = _departementService.GetAllDepartements();
                return View(departements);
            }catch(Exception)
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