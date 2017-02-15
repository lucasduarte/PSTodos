export class UsuarioPerfilModel {
    public PerfilId: number;
    public UsuarioId: number;
    public Ativo: boolean;

    constructor() {
        this.PerfilId = null;
        this.UsuarioId = null;
        this.Ativo = false;
    }
}