import { MaterializeModule } from 'angular2-materialize';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppRoutingModule } from './app.routing.module';

import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';

import { UsuariosComponent } from './components/usuarios/usuarios.component';
import { CadastrarUsuarioComponent } from './components/usuarios/cadastrar-usuario/cadastrar-usuario.component';
import { EditarUsuarioComponent } from './components/usuarios/editar-usuario/editar-usuario.component';
import { UsuarioService } from './services/usuario.service';

import { PerfisComponent } from './components/perfis/perfis.component';
import { EditarPerfilComponent } from './components/perfis/editar-perfil/editar-perfil.component';
import { CadastrarPerfilComponent } from './components/perfis/cadastrar-perfil/cadastrar-perfil.component';
import { PerfilService } from './services/perfil.service';

import { UsuarioPerfilService } from './services/usuario-perfil.service'

import {ToastModule} from 'ng2-toastr/ng2-toastr';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    UsuariosComponent,
    PerfisComponent,
    EditarPerfilComponent,
    CadastrarPerfilComponent,
    CadastrarUsuarioComponent,
    EditarUsuarioComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    AppRoutingModule,
    MaterializeModule,
    ToastModule.forRoot()
  ],
  providers: [PerfilService, UsuarioService, UsuarioPerfilService],
  bootstrap: [AppComponent]
})
export class AppModule { }
