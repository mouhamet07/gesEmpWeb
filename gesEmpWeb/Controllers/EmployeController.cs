using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Metadata;
using gesEmpWeb.Models;
using gesEmpWeb.Services;

namespace gesEmpWeb.Controllers
{
    public class EmployeController : Controller
    {
        private readonly IEmployeService _employeService;
        private readonly ILogger<EmployeController> _logger;
        public EmployeController(ILogger<EmployeController> logger, IEmployeService employeService)
        {
            _employeService = employeService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index(int page = 1, int? deptId = null)
        {
            try
            {
                int total = deptId.HasValue ? _employeService.CountEmployes(page,deptId.Value) : _employeService.CountEmployes(page);
                int nbrPages = (int)Math.Ceiling((double)total / 10);
                var employes = _employeService.GetAllEmployes(page, deptId);
                ViewBag.NbrPages = nbrPages;
                ViewBag.CurrentPage = page;
                ViewBag.DepartementId = deptId;
                return View(employes);
            }
            catch (Exception)
            {
                _logger.LogError("Erreur lors de l'affichage des employés");
                return View(new List<Employe>());
            }
        }
        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }
    }
}