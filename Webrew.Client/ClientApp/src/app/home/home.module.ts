import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { HomeRoutingModule } from './home-routing.module';
import { DisplayCardModule } from '../display-card/display-card.module';
import { FlexLayoutModule } from '@angular/flex-layout';

@NgModule({
    declarations: [HomeComponent],
    imports: [CommonModule, HomeRoutingModule, DisplayCardModule, FlexLayoutModule]
})
export class HomeModule {}
