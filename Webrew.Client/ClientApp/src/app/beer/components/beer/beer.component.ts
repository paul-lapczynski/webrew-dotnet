import { Component, OnInit } from '@angular/core';
import { BeersService } from 'src/app/services/beer.service';
import { ActivatedRoute } from '@angular/router';
import { switchMap, map } from 'rxjs/operators';
import { Beer } from 'src/app/shared/models/beer';
import { Review } from 'src/app/shared/models/review';

@Component({
    selector: 'beer',
    templateUrl: './beer.component.html',
    styleUrls: ['./beer.component.scss']
})
export class BeerComponent implements OnInit {
    beer: Beer;
    reviews: Review[];

    constructor(private beersService: BeersService, private activeRoute: ActivatedRoute) {
    }
    
    ngOnInit() {
        this.activeRoute.params.pipe(switchMap(params => this.beersService.fetchBeer(params['id']))).subscribe(res => { this.beer = res });
        this.activeRoute.params.pipe(switchMap(params => this.beersService.fetchReviews(params['id']))).subscribe(res => { this.reviews = res });
    }
}
