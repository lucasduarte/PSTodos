import { Component, OnInit, ViewContainerRef, NgZone } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UsuarioService } from '../../../services/usuario.service';
import { UsuarioPerfilService } from '../../../services/usuario-perfil.service';
import { PerfilService } from '../../../services/perfil.service';
import { Usuario } from '../../../models/usuario';
import { Perfil } from '../../../models/perfil'
import { ToastsManager } from 'ng2-toastr/ng2-toastr';
declare  var $:any;

@Component({
  selector: 'app-editar-usuario',
  templateUrl: './editar-usuario.component.html',
  styleUrls: ['./editar-usuario.component.css']
})
export class EditarUsuarioComponent implements OnInit {
  public usuario: Usuario = new Usuario();
  public perfis: Perfil[] = [];
  public perfil: number;
  constructor(private toastr: ToastsManager, vRef: ViewContainerRef, 
              private service: UsuarioService, private router: Router, 
              private activatedRoute: ActivatedRoute, private perfilService: PerfilService,
              private usuarioPerfilService: UsuarioPerfilService, private zone: NgZone) { 
    this.toastr.setRootViewContainerRef(vRef);
  }

  private carregaUsuario(): void {
    this.activatedRoute.params.subscribe((params) => {
      let id = params['id'];
      this.service.obterUsuario(id)
        .subscribe((res) => {
          if(res.success) {
            this.usuario = res.result;
          } else {
            console.log(res.errors);
          }
        }, (err) => {
          this.router.navigate(['/usuarios']).then(() =>{
            this.toastr.error("Falha ao carregar Usuário.");
           });  
        });
    });
  }

  private carregaPerfis(): void {
    this.perfilService.listarPerfis()
      .subscribe((res) => {
        if(res.success) {
          this.perfis = res.result;
        } else {
          console.log(res.errors);
        }
      });
  }

  ngOnInit() {
    this.carregaUsuario();    
    this.carregaPerfis();
  }

  alterarUsuario() {
    this.service.alterarUsuario(this.usuario)
      .subscribe((res) => {
        if(res.success) {      
          this.router.navigate(['/usuarios']).then(() =>{
            this.toastr.success("Usuário alterado com sucesso.");
           });      
        } else {
          this.toastr.error("Falha ao alterar Usuário.");
        }
    });
  }

  adicionarPerfil() {
    this.usuarioPerfilService.adicionarPerfil(this.usuario.id, this.perfil)
      .subscribe((res) => {
        if(res.success) {
            this.carregaUsuario();;
            this.toastr.success("Perfil inserido com sucesso.");
        }
      }, (err) => {
            this.toastr.error("Falha ao incluir Perfil.");
          });
  }

  removerPerfil(perfilId: number) {
    this.usuarioPerfilService.removerPerfil(this.usuario.id, perfilId)
      .subscribe((res) => {
        if(res.success) {
            this.carregaUsuario();
            this.toastr.success("Perfil removido com sucesso.");
        }
      }, (err) => {
            this.toastr.error("Falha ao remover Perfil.");
          });
  }


}
