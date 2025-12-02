using gesEmpWeb.Models;

namespace gesEmpWeb.Services
{
    public interface IDepartementService
    {
        IEnumerable<Departement> GetAllDepartements();
    }
}