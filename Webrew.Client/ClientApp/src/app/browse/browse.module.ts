import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowseComponent } from './components/browse/browse.component';
import { BrowseRoutingModule } from './browse-routing.module';
import { DisplayCardModule } from '../display-card/display-card.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpClientModule } from '@angular/common/http';
import { BeersService } from "../services/beer.service";

@NgModule({
    declarations: [BrowseComponent],
    imports: [CommonModule, BrowseRoutingModule, DisplayCardModule, FlexLayoutModule, HttpClientModule],
    providers: [BeersService]
})
export class BrowseModule { }