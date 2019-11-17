import { RouterModule, Route } from '@angular/router';
import { BrowseComponent } from './components/browse/browse.component';
import { NgModule } from '@angular/core';

const routes: Route[] = [{ path: 'browse', component: BrowseComponent }];
@NgModule({
    imports: [RouterModule.forChild(routes)]
})
export class BrowseRoutingModule {}
