import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';
import { Usuario } from '../../models/usuario';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  public usuarios: Usuario[] = [];
  constructor(private toastr: ToastsManager, vRef: ViewContainerRef, private service: UsuarioService) { 
    this.toastr.setRootViewContainerRef(vRef);
  }

  private carregarUsuarios(): void {
    this.service.listarUsuarios()
      .subscribe((res) => {
        if(res.success) {
          this.usuarios = res.result;
        } else {
          console.log(res.errors);
        }
      })
  }

  ngOnInit() {
    this.carregarUsuarios();
  }

  removerUsuario(id: number) {
    this.service.removerUsuario(id)
      .subscribe(res => {
        if(res.success) {
          this.carregarUsuarios();
          this.toastr.success("Usuário removido com sucesso.");
        } else {
          this.toastr.error("Falha ao remover Usuário.");
        }
      }, err => { this.toastr.error("Falha ao remover Usuário.") });
  }

}
