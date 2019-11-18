import { RouterModule, Route } from '@angular/router';
import { UserprofileComponent } from './components/userprofile/userprofile.component';
import { NgModule } from '@angular/core';

const routes: Route[] = [{ path: '', component: UserprofileComponent }];

@NgModule({
    imports: [RouterModule.forChild(routes)]
})
export class UserprofileRoutingModule {}
