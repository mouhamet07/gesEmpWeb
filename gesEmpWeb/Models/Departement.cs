using System.ComponentModel.DataAnnotations;

namespace gesEmpWeb.Models
{
    public class Departement
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom du département est obligatoire")]
        [StringLength(100, ErrorMessage = "Le nom du département ne peut pas dépasser 100 caractères")]
        public string Name { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}