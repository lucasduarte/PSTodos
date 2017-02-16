import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { PerfilService } from '../../../services/perfil.service';
import { Perfil } from '../../../models/perfil';
import { Router } from '@angular/router';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';

@Component({
  selector: 'app-cadastrar-perfil',
  templateUrl: './cadastrar-perfil.component.html',
  styleUrls: ['./cadastrar-perfil.component.css']
})
export class CadastrarPerfilComponent implements OnInit {
  public perfil: Perfil = new Perfil();
  constructor(private toastr: ToastsManager, vRef: ViewContainerRef, private service: PerfilService, private router: Router) { 
    this.toastr.setRootViewContainerRef(vRef);
  }

  ngOnInit() {
  }

  cadastrarPerfil() {
    this.service.cadastrarPerfil(this.perfil)
      .subscribe((res) => {
        if(res.success) {
          this.router.navigate(['/perfis'])
            .then(() => {
              this.toastr.success("Perfil cadastrado com sucesso.");
          });
        } else {
          alert('Erro ao cadastrar perfil.');
          this.toastr.error("Falha ao cadastrar Perfil.");
        }
      });
  }
}
