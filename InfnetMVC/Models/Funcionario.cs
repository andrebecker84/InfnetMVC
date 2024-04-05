using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfnetMVC.Models
{
    public class Funcionario
    {
        [Key]
        [Display(Name = "ID Funcionário")]
        public int FuncionarioId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [ForeignKey("Endereco")]
        [Display(Name = "Endereço")]
        public int EnderecoId { get; set; } // Chave estrangeira para Endereco
        public Endereco? Endereco { get; set; } // Propriedade de navegação para o endereço

        public string Telefone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [ForeignKey("Departamento")]
        [Display(Name = "Departamento")]
        public int DepartamentoId { get; set; } // Chave estrangeira
        public Departamento? Departamento { get; set; } // Propriedade de navegação para o departamento
    }
}