namespace PSTodos.RESTServices.ViewModels
{
    public class UsuarioPerfilViewModel : BaseViewModel
    {
        public int UsuarioId { get; set; }
        public virtual UsuarioViewModel Usuario { get; set; }
        public int PerfilId { get; set; }
        public virtual PerfilViewModel Perfil { get; set; }
        public bool Ativo { get; set; }
    }
}