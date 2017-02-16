import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { PerfilService } from '../../services/perfil.service';
import { Perfil } from '../../models/perfil';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';

@Component({
  moduleId: module.id,
  selector: 'app-perfis',
  templateUrl: './perfis.component.html',
  styleUrls: ['./perfis.component.css']
})
export class PerfisComponent implements OnInit {

  public perfis: Perfil[] = [];
  constructor(private toastr: ToastsManager, vRef: ViewContainerRef, private service: PerfilService) { 
    this.toastr.setRootViewContainerRef(vRef);
  }

  private carregarPerfis(): void {
    this.service.listarPerfis()
      .subscribe((res) => {
        if(res.success) {
          this.perfis = res.result;
        } else {
          console.log(res.errors);
        }
      })
  }

  ngOnInit() {
    this.carregarPerfis();
  }

  removerPerfil(id: number) {
    this.service.removerPerfil(id)
      .subscribe((res) => {
        if(res.success) {
          this.carregarPerfis();
          this.toastr.success("Perfil removido com sucesso.");
        } else {
          console.log(res.errors);
          this.toastr.error("Falha ao remover Perfil.");
        }
      });
  }
}
