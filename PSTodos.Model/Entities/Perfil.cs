using System.Collections.Generic;

namespace PSTodos.Model.Entities
{
    public class Perfil : EntityBase
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public ICollection<UsuarioPerfil> Usuarios { get; set; }
    }
}
