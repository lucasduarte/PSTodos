using System;
using System.Collections.Generic;

namespace PSTodos.Model.Entities
{
    public class Usuario : EntityBase
    {
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public DateTime DtInclusao { get; set; }

        public ICollection<OperacaoUsuario> OperacoesUsuario { get; set; }
        public ICollection<UsuarioPerfil> UsuariosPerfil { get; set; }
    }
}
