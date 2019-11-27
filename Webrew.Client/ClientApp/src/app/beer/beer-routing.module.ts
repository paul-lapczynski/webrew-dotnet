import { RouterModule, Route } from '@angular/router';
import { BeerComponent } from './components/beer/beer.component';
import { NgModule } from '@angular/core';
import { BeerReviewComponent } from './components/beer-review/beer-review.component';

const routes: Route[] = [
    { path: ':id', component: BeerComponent },
    { path: ':id/review', component: BeerReviewComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)]
})
export class BeerRoutingModule {}
