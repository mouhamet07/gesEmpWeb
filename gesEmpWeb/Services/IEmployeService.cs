using gesEmpWeb.Models;

namespace gesEmpWeb.Services
{
    public interface IEmployeService
    {
        IEnumerable<Employe> GetAllEmployes(int page = 1, int? deptId = null);
        int CountEmployes(int page = 1, int? deptId = null);
    }
}