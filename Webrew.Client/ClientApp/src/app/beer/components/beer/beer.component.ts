import { Component, OnInit } from '@angular/core';
import { BeersService } from 'src/app/services/beer.service';
import { ActivatedRoute } from '@angular/router';
import { switchMap, map, tap } from 'rxjs/operators';
import { Beer } from 'src/app/shared/models/beer';
import { Review } from 'src/app/shared/models/review';
import { Observable } from 'rxjs';
import { FormGroup, FormControl } from '@angular/forms';
import { ReviewReadyEvent, ReviewComponent } from '../review/review.component';
import { MatDialog } from '@angular/material';

@Component({
    selector: 'beer',
    templateUrl: './beer.component.html',
    styleUrls: ['./beer.component.scss']
})
export class BeerComponent implements OnInit {
    beer: Beer;
    reviews$: Observable<Review[]>;
    form: FormGroup;
    starRating = new FormControl(0);

    constructor(private beersService: BeersService, private activeRoute: ActivatedRoute) {}

    ngOnInit() {
        this.starRating.disable();
        this.activeRoute.params.pipe(switchMap(params => this.beersService.fetchBeer(params['id']))).subscribe(res => {
            this.beer = res;
            this.starRating.patchValue(res.avgRating);
        });
        this.reviews$ = this.activeRoute.params.pipe(
            switchMap(params => this.beersService.fetchReviews(params['id'])),
            tap(console.log)
        );
    }

    onReviewReady(event: ReviewReadyEvent) {
        this.form = event.form;
        this.form.patchValue({ beerId: this.beer ? this.beer.id : '' });
    }

    onImageLoad(img: HTMLImageElement) {
        console.log(img.naturalHeight);
        console.log(img.naturalWidth);
    }

    addReview() {}
}
