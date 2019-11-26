import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BeerComponent } from './components/beer/beer.component';
import { BeerRoutingModule } from './beer-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { BeersService } from '../services/beer.service';
import { ReviewComponent } from './components/review/review.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule, MatSliderModule } from '@angular/material';
import { StarRatingModule } from '../star-rating/star-rating.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatInputModule } from '@angular/material/input';
@NgModule({
    declarations: [BeerComponent, ReviewComponent],
    imports: [
        CommonModule,
        BeerRoutingModule,
        HttpClientModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatSliderModule,
        StarRatingModule,
        MatInputModule,
        FlexLayoutModule
    ],
    providers: [BeersService]
})
export class BeerModule {}
