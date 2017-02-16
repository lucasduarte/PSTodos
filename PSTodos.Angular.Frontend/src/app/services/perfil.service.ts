import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { GenericResultBase, GenericResult } from '../models/genericResult';
import { Perfil } from '../models/perfil';
import { environment } from '../../environments/environment';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';


@Injectable()
export class PerfilService {
    private baseUrl = `${environment.baseUrl}/Perfis`;
    constructor(private http: Http) { }

    public listarPerfis(): Observable<GenericResult<Perfil[]>> {

        return this.http.get(this.baseUrl)
            .map(res => res.json());
    }

    public obterPerfil(id: number): Observable<GenericResult<Perfil>> {
        let url = `${this.baseUrl}/${id}`;

        return this.http.get(url)
            .map(res => res.json());
    }

    public alterarPerfil(perfil: Perfil): Observable<GenericResult<Perfil>> {
        let url = `${this.baseUrl}/${perfil.id}`;

        return this.http.put(url, perfil)
            .map(res => res.json());
    }

    public cadastrarPerfil(perfil: Perfil): Observable<GenericResult<Perfil>> {
        return this.http.post(this.baseUrl, perfil)
            .map(res => res.json());
    }

    public removerPerfil(id: number): Observable<GenericResult<Perfil>> {
        let url = `${this.baseUrl}/${id}`;
        return this.http.delete(url, id)
            .map(res => res.json());
    }
}
