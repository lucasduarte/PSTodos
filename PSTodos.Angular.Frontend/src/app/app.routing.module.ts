import { NgModule }              from '@angular/core';
import { RouterModule, Routes }  from '@angular/router';
import { UsuariosComponent }   from './components/usuarios/usuarios.component';
import { CadastrarUsuarioComponent }   from './components/usuarios/cadastrar-usuario/cadastrar-usuario.component';
import { EditarUsuarioComponent }   from './components/usuarios/editar-usuario/editar-usuario.component';
import { PerfisComponent } from './components/perfis/perfis.component'
import { EditarPerfilComponent } from './components/perfis/editar-perfil/editar-perfil.component'
import { CadastrarPerfilComponent } from './components/perfis/cadastrar-perfil/cadastrar-perfil.component'
import { HomeComponent } from './components/home/home.component';

const appRoutes: Routes = [
  { path: '',   redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'usuarios', component: UsuariosComponent },
  { path: 'usuarios/cadastrar', component: CadastrarUsuarioComponent },
  { path: 'usuarios/:id', component: EditarUsuarioComponent },
  { path: 'perfis', component: PerfisComponent },
  { path: 'perfis/cadastrar', component: CadastrarPerfilComponent },
  { path: 'perfis/:id', component: EditarPerfilComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule {}