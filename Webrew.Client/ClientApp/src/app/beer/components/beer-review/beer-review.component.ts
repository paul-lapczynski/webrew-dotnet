import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BeersService } from 'src/app/services/beer.service';
import { Review } from 'src/app/shared/models/review';
import { ReviewReadyEvent } from '../review/review.component';
import { FormGroup } from '@angular/forms';

@Component({
    selector: 'beer-review',
    templateUrl: './beer-review.component.html',
    styleUrls: ['./beer-review.component.scss']
})
export class BeerReviewComponent implements OnInit {
    get id() {
        return this.route.snapshot.params['id'] as string;
    }
    form: FormGroup;

    constructor(private route: ActivatedRoute, private service: BeersService) {}

    ngOnInit() {
        Promise.resolve().then(() => {
            (window.document.getElementById('beer-review') as HTMLElement).scrollIntoView({ behavior: 'smooth' });
        });
    }

    submitReview() {
        const review = this.form.getRawValue() as Review;
        review.beerId = this.id;

        this.service.addReview(review).subscribe(res => {
            if (!res) {
                alert('An Error happened');
            }
        });
    }

    onFormReady(event: ReviewReadyEvent) {
        this.form = event.form;
    }
}
