using gesEmpWeb.Controllers;
using gesEmpWeb.Data;
using gesEmpWeb.Models;
using gesEmpWeb.Services;

namespace gesEmpWeb.Services.Impl
{
    public class DepartementService : IDepartementService
    {
        private readonly GesEmpDbContext _context;
        ILogger<DepartementController> _logger;
        public DepartementService(ILogger<DepartementController> logger, GesEmpDbContext context)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<Departement> GetAllDepartements()
        {
            try
            {
                return _context.Departements
                .Where(d => d.IsActive)
                .OrderByDescending(d => d.DateCreation)
                .ToList();
            }
            catch (Exception)
            {
                _logger.LogError("Erreur lors de la récupération des départements");
                throw;
            }
        }
    }
}