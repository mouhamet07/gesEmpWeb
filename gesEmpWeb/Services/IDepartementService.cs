using gesEmpWeb.Models;

namespace gesEmpWeb.Services
{
    public interface IDepartementService
    {
        IEnumerable<Departement> GetAllDepartements(int page = 1);
        int CountDepartements(int page = 1);
            
    }
}