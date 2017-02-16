import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { PerfilService } from '../../../services/perfil.service';
import { Perfil } from '../../../models/perfil';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';

@Component({
  moduleId: module.id,
  selector: 'app-editarperfil',
  templateUrl: './editar-perfil.component.html',
  styleUrls: ['./editar-perfil.component.css']
})
export class EditarPerfilComponent implements OnInit {
  public perfil: Perfil = new Perfil();

  constructor(private toastr: ToastsManager, vRef: ViewContainerRef, private service: PerfilService, private router: Router, private activatedRoute: ActivatedRoute) {
    this.toastr.setRootViewContainerRef(vRef);
   }

  private carregaPerfil(): void {
    this.activatedRoute.params.subscribe((params) => {
      let id = params['id'];
      this.service.obterPerfil(id)
        .subscribe((res) => {
          if(res.success) {
            this.perfil = res.result;
          } else {
            console.log(res.errors);
          }
        })
    });
  }

  ngOnInit() {
    this.carregaPerfil();    
  }

  alterarPerfil() {
    this.service.alterarPerfil(this.perfil)
      .subscribe((res) => {
        if(res.success) {      
          this.router.navigate(['/perfis']).then(() =>{
            this.toastr.success("Perfil alterado com sucesso.");
           });      
        } else {
          alert('Erro ao alterar perfil.');
          this.toastr.error("Falha ao alterar Perfil.");
        }
    });
  }
}
