import { RouterModule, Route } from '@angular/router';
import { BeerComponent } from './components/beer/beer.component';
import { NgModule } from '@angular/core';

const routes: Route[] = [{ path: ':id', component: BeerComponent }];

@NgModule({
    imports: [RouterModule.forChild(routes)]
})
export class BeerRoutingModule {}
