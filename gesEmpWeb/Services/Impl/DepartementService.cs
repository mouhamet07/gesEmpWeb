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
        private const int size = 4; 
        public DepartementService(ILogger<DepartementController> logger, GesEmpDbContext context)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<Departement> GetAllDepartements(int page = 1)
        {
            try
            {
                if (page < 1) page = 1;
                int offset = (page - 1) * size;
                return _context.Departements
                .Where(d => d.IsActive)
                .OrderByDescending(d => d.DateCreation)
                .Skip(offset)
                .Take(size)
                .ToList();
            }
            catch (Exception)
            {
                _logger.LogError("Erreur lors de la récupération des départements");
                throw;
            }
        }
        public int CountDepartements(int page = 1)
        {
            try
            {
                if (page < 1) page = 1;
                int offset = (page - 1) * size;
                return _context.Departements
                .Skip(offset)
                .Take(size)
                .Count(d => d.IsActive);
            }
            catch (Exception)
            {
                _logger.LogError("Erreur lors du comptage des départements");
                throw;
            }
        }
    }
}