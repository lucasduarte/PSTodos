export class Usuario {
    public id: number;
    public login: string;
    public nome: string;
    public email: string;
    public senha: string;
    public ativo: boolean;
    public dtInclusao: Date;

    constructor() {
        this.id = null;
        this.login = "";
        this.nome = "";
        this.email = "";
        this.senha = "";
        this.ativo = false;
        this.dtInclusao = new Date();
    }
}