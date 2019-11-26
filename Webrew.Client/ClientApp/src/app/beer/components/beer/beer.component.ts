import { Component, OnInit } from '@angular/core';
import { BeersService } from 'src/app/services/beer.service';
import { ActivatedRoute } from '@angular/router';
import { switchMap, map } from 'rxjs/operators';
import { Beer } from 'src/app/shared/models/beer';
import { Review } from 'src/app/shared/models/review';
import { Observable } from 'rxjs';
import { FormGroup } from '@angular/forms';
import { ReviewReadyEvent } from '../review/review.component';

@Component({
    selector: 'beer',
    templateUrl: './beer.component.html',
    styleUrls: ['./beer.component.scss']
})
export class BeerComponent implements OnInit {
    beer: Beer;
    reviews$: Observable<Review[]>;
    form: FormGroup;
    constructor(private beersService: BeersService, private activeRoute: ActivatedRoute) {}

    ngOnInit() {
        this.activeRoute.params.pipe(switchMap(params => this.beersService.fetchBeer(params['id']))).subscribe(res => {
            this.beer = res;
        });
        this.reviews$ = this.activeRoute.params.pipe(switchMap(params => this.beersService.fetchReviews(params['id'])));
    }

    onReviewReady(event: ReviewReadyEvent) {
        this.form = event.form;
        this.form.patchValue({ beerId: this.beer ? this.beer.id : '' });
    }
}
