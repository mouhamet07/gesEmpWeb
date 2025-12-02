using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Metadata;
using gesEmpWeb.Models;

namespace gesEmpWeb.Controllers
{
    public class EmployeController : Controller
    {
        public EmployeController()
        {
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }
    }
}