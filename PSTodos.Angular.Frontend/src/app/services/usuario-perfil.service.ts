import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { GenericResultBase, GenericResult } from '../models/genericResult';
import { UsuarioPerfil } from '../models/usuarioPerfil';
import { environment } from '../../environments/environment';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class UsuarioPerfilService {

  private baseUrl = `${environment.baseUrl}/Usuarios`;
    constructor(private http: Http) { }

    public adicionarPerfil(usuarioId: number, perfilId: number): Observable<GenericResult<UsuarioPerfil>> {
        return this.http.post(`${this.baseUrl}/${usuarioId}/perfis/${perfilId}`, null)
            .map(res => res.json());
    }

    public removerPerfil(usuarioId: number, perfilId: number): Observable<GenericResult<UsuarioPerfil>> {
        return this.http.delete(`${this.baseUrl}/${usuarioId}/perfis/${perfilId}`, null)
            .map(res => res.json());
    }

}
