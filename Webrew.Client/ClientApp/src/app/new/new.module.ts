import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewComponent } from './components/new/new.component';
import { NewRoutingModule } from './new-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { BeersService } from "../services/beer.service";
import { ReactiveFormsModule } from '@angular/forms';
import {
    MatFormFieldModule,
    MatSliderModule,
    MatCardModule,
    MatDividerModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule
} from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatInputModule } from '@angular/material/input';
import { RouterModule } from '@angular/router';

@NgModule({
    declarations: [NewComponent],
    imports: [CommonModule, NewRoutingModule, HttpClientModule,ReactiveFormsModule,
        MatFormFieldModule, MatSliderModule, MatCardModule, MatDividerModule,
        MatButtonModule, MatIconModule, MatDialogModule,FlexLayoutModule,MatInputModule,RouterModule],
    providers: [BeersService]
})
export class NewModule { }