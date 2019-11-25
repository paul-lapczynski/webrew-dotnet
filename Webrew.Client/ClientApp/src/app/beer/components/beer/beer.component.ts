import { Component, OnInit } from '@angular/core';
import { BeersService } from 'src/app/services/beer.service';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { ReviewComponent, ReviewReadyEvent } from '../review/review.component';
import { Beer } from 'src/app/shared/models/beer';

@Component({
    selector: 'beer',
    templateUrl: './beer.component.html',
    styleUrls: ['./beer.component.scss']
})
export class BeerComponent implements OnInit {
    constructor(private beersService: BeersService, private fb: FormBuilder) {}

    beer: Beer;

    isDataAvailable: boolean = false;
    form: FormGroup;
    fetchBeer(beerId) {
        // this.beer = this.beersService.fetchBeer(beerId);
    }

    ngOnInit() {
        // TODO get beerID
        var beerId = '5dc8da9f0bc4f34070941710';
        this.fetchBeer(beerId);
    }

    onReviewReady(event: ReviewReadyEvent) {
        this.form = event.form;
        this.form.patchValue({ beerId: this.beer ? this.beer.id : '' });
    }
}
