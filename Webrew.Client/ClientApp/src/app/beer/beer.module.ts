import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BeerComponent } from './components/beer/beer.component';
import { BeerRoutingModule } from './beer-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { BeersService } from "../services/beer.service";

@NgModule({
    declarations: [BeerComponent],
    imports: [CommonModule, BeerRoutingModule, HttpClientModule],
    providers: [BeersService]
})
export class BeerModule { }