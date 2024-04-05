using System.ComponentModel.DataAnnotations;

namespace InfnetMVC.Models
{
    public class Endereco
    {
        [Key]
        [Display(Name = "ID Endereço")]
        public int EnderecoId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Logradouro { get; set; }

        [Required]
        [MaxLength(50)]
        public string Bairro { get; set; }

        [Required]
        [MaxLength(50)]
        public string Municipio { get; set; }

        [Required]
        [MaxLength(2)]
        public string Estado { get; set; }

        [Required]
        [MaxLength(8)]
        public string Cep { get; set; }
        public ICollection<Funcionario>? Funcionarios { get; set; } // Relacionamento 1:N

        public Endereco()
        {
            Funcionarios = new HashSet<Funcionario>();
        }
    }
}