import { RouterModule, Route } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { NgModule } from '@angular/core';

const routes: Route[] = [{ path: '', component: LoginComponent }];

@NgModule({
    imports: [RouterModule.forChild(routes)]
})
export class LoginRoutingModule {}
