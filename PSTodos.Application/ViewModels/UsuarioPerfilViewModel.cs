using PSTodos.Model.Entities;

namespace PSTodos.Application.ViewModels
{
    public class UsuarioPerfilViewModel
    {
        public int UsuarioId { get; set; }
        public virtual UsuarioViewModel Usuario { get; set; }
        public int PerfilId { get; set; }
        public virtual PerfilViewModel Perfil { get; set; }
        public bool Ativo { get; set; }
    }
}
