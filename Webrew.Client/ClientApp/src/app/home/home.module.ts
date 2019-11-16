import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { HomeRoutingModule } from './home-routing.module';
import { DisplayCardModule } from '../display-card/display-card.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpClientModule } from '@angular/common/http';
import { BeersService } from "../services/beer.service";

@NgModule({
    declarations: [HomeComponent],
    imports: [CommonModule, HomeRoutingModule, DisplayCardModule, FlexLayoutModule, HttpClientModule],
    providers: [BeersService]
})
export class HomeModule {}
