import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { GenericResultBase, GenericResult } from '../models/genericResult';
import { Usuario } from '../models/usuario';
import { environment } from '../../environments/environment';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';


@Injectable()
export class UsuarioService {
    private baseUrl = `${environment.baseUrl}/Usuarios`;
    constructor(private http: Http) { }

    public listarUsuarios(): Observable<GenericResult<Usuario[]>> {
        return this.http.get(this.baseUrl)
            .map(res => res.json());
    }

    public obterUsuario(id: number): Observable<GenericResult<Usuario>> {
        let url = `${this.baseUrl}/${id}`;

        return this.http.get(url)
            .map(res => res.json());
    }

    public alterarUsuario(usuario: Usuario): Observable<GenericResult<Usuario>> {
        let url = `${this.baseUrl}/${usuario.id}`;

        return this.http.put(url, usuario)
            .map(res => res.json());
    }

    public cadastrarUsuario(usuario: Usuario): Observable<GenericResult<Usuario>> {
        return this.http.post(this.baseUrl, usuario)
            .map(res => res.json());
    }

    public removerUsuario(id: number): Observable<GenericResult<Usuario>> {
        let url = `${this.baseUrl}/${id}`;
        return this.http.delete(url, id)
            .map(res => res.json());
    }
}
