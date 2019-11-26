import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReviewCardComponent } from './components/review-card/review-card.component';
import { MatCardModule, MatDividerModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { RouterModule } from '@angular/router';

@NgModule({
    declarations: [ReviewCardComponent],
    imports: [CommonModule, MatCardModule, FlexLayoutModule, MatDividerModule, RouterModule],
    exports: [ReviewCardComponent]
})
export class ReviewCardModule {}
