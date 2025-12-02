using System.ComponentModel.DataAnnotations;

namespace gesEmpWeb.Models
{
    public class Employe
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom de l'employe est obligatoire")]
        [StringLength(100, ErrorMessage = "Le nom de l'employe ne peut pas dépasser 100 caractères")]
        public string NomComplet { get; set; }

        [Required(ErrorMessage = "Le numero de l'employe est obligatoire")]
        [StringLength(100, ErrorMessage = "Le numero de l'employe ne peut pas dépasser 100 caractères")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Le telephone de l'employe est obligatoire")]
        [StringLength(100, ErrorMessage = "Le telephone de l'employe ne peut pas dépasser 100 caractères")]
        public string Telephone { get; set; }
        
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}