using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PSTodos.RESTServices.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(250, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(150, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres.")]
        public string Senha { get; set; }

        public bool Ativo { get; set; }

        public DateTime DtInclusao { get; set; }
        
        public IEnumerable<PerfilViewModel> Perfis { get; set; }
    }
}