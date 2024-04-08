using System.ComponentModel.DataAnnotations;

namespace InfnetMVC.Models
{
    public class Departamento
    {
        [Key]
        [Display(Name = "ID Departamento")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        public string Local { get; set; }

        public ICollection<Funcionario>? Funcionarios { get; set; } // Relacionamento 1:N
    }
}