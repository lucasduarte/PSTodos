using System.ComponentModel.DataAnnotations;

namespace PSTodos.RESTServices.ViewModels
{
    public class PerfilViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres.")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }
    }
}