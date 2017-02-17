import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { UsuarioService } from '../../../services/usuario.service';
import { Usuario } from '../../../models/usuario';
import { Router } from '@angular/router';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
@Component({
  selector: 'app-cadastrar-usuario',
  templateUrl: './cadastrar-usuario.component.html',
  styleUrls: ['./cadastrar-usuario.component.css']
})
export class CadastrarUsuarioComponent implements OnInit {
  public usuario: Usuario = new Usuario();
  constructor(private toastr: ToastsManager, vRef: ViewContainerRef, private service: UsuarioService, private router: Router) { 
    this.toastr.setRootViewContainerRef(vRef);
  }

  ngOnInit() {
  }

  cadastrarUsuario() {
    this.service.cadastrarUsuario(this.usuario)
      .subscribe((res) => {
        if(res.success) {
          this.router.navigate(['/usuarios'])
            .then(() => {
              this.toastr.success("Usuario cadastrado com sucesso.");
          });
        } else {
          this.toastr.error("Falha ao cadastrar Usuario.");
        }
      });
  }

}
