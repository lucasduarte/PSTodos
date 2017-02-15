export class Usuario {
    public Id: number;
    public Login: string;
    public Nome: string;
    public Email: string;
    public Senha: string;
    public Ativo: boolean;
    public DtInclusao: Date;

    constructor() {
        this.Id = null;
        this.Login = "";
        this.Nome = "";
        this.Email = "";
        this.Senha = "";
        this.Ativo = false;
        this.DtInclusao = new Date();
    }
}