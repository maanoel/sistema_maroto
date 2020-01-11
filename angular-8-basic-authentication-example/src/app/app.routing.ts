import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home';
import { BoletoComponent } from './boleto';
import { LoginComponent } from './login';
import { ReparoComponent } from './reparo';
import { AuthGuard } from './_helpers';

const routes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'boletos', component: BoletoComponent },
    { path: 'reparo', component: ReparoComponent },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const appRoutingModule = RouterModule.forRoot(routes);