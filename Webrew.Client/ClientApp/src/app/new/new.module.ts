import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewComponent } from './components/new/new.component';
import { NewRoutingModule } from './new-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { BeersService } from "../services/beer.service";

@NgModule({
    declarations: [NewComponent],
    imports: [CommonModule, NewRoutingModule, HttpClientModule],
    providers: [BeersService]
})
export class NewModule { }