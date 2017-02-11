using System;

namespace PSTodos.Model.Entities
{
    public class OperacaoUsuario : EntityBase
    {
        public DateTime DtLog { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
