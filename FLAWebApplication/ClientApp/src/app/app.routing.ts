import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { LoginComponent } from './Login/login.component';
import { AuthGuard } from './_helpers/auth.guard';
import { CreateClientComponent } from './Client/client-create/client-create.component';
import { CreateRoleComponent } from './Permission/create-role/create-role.component';

export const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'client-create', component: CreateClientComponent },
  { path: 'create-role', component: CreateRoleComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

export const appRoutingModule = RouterModule.forRoot(routes);
