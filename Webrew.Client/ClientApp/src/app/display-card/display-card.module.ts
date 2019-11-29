import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DisplayCardComponent } from './components/display-card/display-card.component';
import { MatCardModule, MatDividerModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { RouterModule } from '@angular/router';
import { StarRatingModule } from '../star-rating/star-rating.module';

@NgModule({
    declarations: [DisplayCardComponent],
    imports: [CommonModule, MatCardModule, FlexLayoutModule, MatDividerModule, RouterModule, StarRatingModule],
    exports: [DisplayCardComponent]
})
export class DisplayCardModule {}
