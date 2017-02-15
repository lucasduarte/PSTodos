import { NgModule }              from '@angular/core';
import { RouterModule, Routes }  from '@angular/router';
import { UsuariosComponent }   from './components/usuarios/usuarios.component';
import { PerfisComponent } from './components/perfis/perfis.component'

const appRoutes: Routes = [
  { path: 'usuarios', component: UsuariosComponent },
  { path: '',   redirectTo: '/usuarios', pathMatch: 'full' },
  { path: 'perfis', component: PerfisComponent }
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