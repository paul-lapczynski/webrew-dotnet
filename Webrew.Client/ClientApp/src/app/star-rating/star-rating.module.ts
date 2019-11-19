import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StarComponent } from './components/star/star.component';
import { MatIconModule, MatRippleModule } from '@angular/material';
import { StarRatingComponent } from './components/star-rating/star-rating.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
    declarations: [StarComponent, StarRatingComponent],
    imports: [CommonModule, MatIconModule, MatRippleModule],
    exports: [StarRatingComponent]
})
export class StarRatingModule {}
