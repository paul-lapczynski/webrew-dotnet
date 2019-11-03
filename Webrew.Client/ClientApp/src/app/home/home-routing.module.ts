import { RouterModule, Route } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { NgModule } from '@angular/core';

const routes: Route[] = [{ path: '', component: HomeComponent }];
@NgModule({
    imports: [RouterModule.forChild(routes)]
})
export class HomeRoutingModule {}
