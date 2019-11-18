import { RouterModule, Route } from '@angular/router';
import { NewComponent } from './components/new/new.component';
import { NgModule } from '@angular/core';

const routes: Route[] = [{ path: '', component: NewComponent }];

@NgModule({
    imports: [RouterModule.forChild(routes)]
})
export class NewRoutingModule {}
