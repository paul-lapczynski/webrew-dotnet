import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BeerComponent } from './components/beer/beer.component';
import { BeerRoutingModule } from './beer-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { BeersService } from '../services/beer.service';
import { ReviewComponent } from './components/review/review.component';
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
import { StarRatingModule } from '../star-rating/star-rating.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatInputModule } from '@angular/material/input';
import { ReviewCardModule } from '../review-card/review-card.module';
import { BeerReviewComponent } from './components/beer-review/beer-review.component';
import { RouterModule } from '@angular/router';
@NgModule({
    declarations: [BeerComponent, ReviewComponent, BeerReviewComponent],
    imports: [
        CommonModule,
        BeerRoutingModule,
        HttpClientModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatSliderModule,
        StarRatingModule,
        MatInputModule,
        FlexLayoutModule,
        ReviewCardModule,
        MatCardModule,
        MatDividerModule,
        MatButtonModule,
        MatIconModule,
        RouterModule
    ],
    providers: [BeersService]
})
export class BeerModule {}
