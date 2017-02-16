import { NgModule }              from '@angular/core';
import { RouterModule, Routes }  from '@angular/router';
import { UsuariosComponent }   from './components/usuarios/usuarios.component';
import { PerfisComponent } from './components/perfis/perfis.component'
import { EditarPerfilComponent } from './components/perfis/editar-perfil/editar-perfil.component'
import { CadastrarPerfilComponent } from './components/perfis/cadastrar-perfil/cadastrar-perfil.component'

const appRoutes: Routes = [
  { path: 'usuarios', component: UsuariosComponent },
  { path: '',   redirectTo: '/usuarios', pathMatch: 'full' },
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