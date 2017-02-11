namespace PSTodos.Model.Entities
{
    public class UsuarioPerfil : EntityBase
    {
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int PerfilId { get; set; }
        public virtual Perfil Perfil { get; set; }
        public bool Ativo { get; set; }
    }
}
