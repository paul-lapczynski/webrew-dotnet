import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserprofileComponent } from './components/userprofile/userprofile.component';
import { UserprofileRoutingModule } from './userprofile-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { BeersService } from "../services/beer.service";

@NgModule({
    declarations: [UserprofileComponent],
    imports: [CommonModule, UserprofileRoutingModule, HttpClientModule],
    providers: [BeersService]
})
export class UserprofileModule { }