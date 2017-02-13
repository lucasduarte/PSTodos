using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PSTodos.Mvc.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public bool Ativo { get; set; }

        [Required]
        public DateTime DtInclusao { get; set; }

        public IEnumerable<PerfilViewModel> Perfis { get; set; }
    }
}