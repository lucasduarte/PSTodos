import { MaterializeModule } from 'angular2-materialize';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppRoutingModule } from './app.routing.module';

import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { UsuariosComponent } from './components/usuarios/usuarios.component';
import { PerfisComponent } from './components/perfis/perfis.component';

import { PerfilService } from './services/perfil.service';
import { UsuarioService } from './services/usuario.service';
import { EditarPerfilComponent } from './components/perfis/editar-perfil/editar-perfil.component';
import { CadastrarPerfilComponent } from './components/perfis/cadastrar-perfil/cadastrar-perfil.component';

import {ToastModule} from 'ng2-toastr/ng2-toastr';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    UsuariosComponent,
    PerfisComponent,
    EditarPerfilComponent,
    CadastrarPerfilComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule,
    MaterializeModule,
    ToastModule.forRoot()
  ],
  providers: [PerfilService, UsuarioService],
  bootstrap: [AppComponent]
})
export class AppModule { }
