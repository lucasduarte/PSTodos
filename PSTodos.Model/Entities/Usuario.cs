using System;

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
    }
}
