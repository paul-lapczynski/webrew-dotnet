import { RouterModule, Route } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { NgModule } from '@angular/core';
import { CreateAccountComponent } from './components/create-account/create-account.component';

const routes: Route[] = [{ path: '', component: LoginComponent }, { path: 'new', component: CreateAccountComponent }];

@NgModule({
    imports: [RouterModule.forChild(routes)]
})
export class LoginRoutingModule {}
