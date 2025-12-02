using gesEmpWeb.Data;
using gesEmpWeb.Services;

namespace gesEmpWeb.Services.Impl
{
    public class DepartementService : IDepartementService
    {
        private readonly GesEmpDbContext _context;

        public DepartementService(GesEmpDbContext context)
        {
            _context = context;
        }
    }
}