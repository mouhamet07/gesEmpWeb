using gesEmpWeb.Controllers;
using gesEmpWeb.Data;
using gesEmpWeb.Models;
using gesEmpWeb.Services;
using Microsoft.EntityFrameworkCore;

namespace gesEmpWeb.Services.Impl
{
    public class EmployeService : IEmployeService
    {
        private readonly GesEmpDbContext _context;
        private readonly ILogger<EmployeController> _logger;
        private const int size = 10; 
        public EmployeService(ILogger<EmployeController> logger, GesEmpDbContext context)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<Employe> GetAllEmployes(int page = 1, int? deptId = null)
        {
            try
            {
                if (page < 1) page = 1;
                int offset = (page - 1) * size;
                var query = _context.Employes.Where(e => e.IsActive);
                if (deptId != null)
                {
                    query = query.Where(e => e.DepartementId == deptId);
                }
                return query
                    .OrderByDescending(e => e.DateCreation)
                    .Skip(offset)
                    .Take(size)
                    .ToList();
            }
            catch (Exception)
            {
                _logger.LogError("Erreur lors de la récupération des Employes - Page {Page}", page);
                throw;
            }
        }
        public int CountEmployes(int page = 1, int? deptId = null)
        {
            try
            {
                if (page < 1) page = 1;
                int offset = (page - 1) * size;
                var query = _context.Employes.Where(e => e.IsActive);
                if (deptId != null)
                {
                    query = query.Where(e => e.DepartementId == deptId);
                }
                return query
                .Skip(offset)
                .Take(size)
                .Count();
            }
            catch (Exception)
            {
                _logger.LogError("Erreur lors du comptage des Employes");
                throw;
            }
        }
    }
}