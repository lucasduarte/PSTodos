using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSTodos.Mvc.ViewModels
{
    public class UsuarioPerfilViewModel
    {
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int PerfilId { get; set; }
        public virtual Perfil Perfil { get; set; }
        public bool Ativo { get; set; }
    }
}