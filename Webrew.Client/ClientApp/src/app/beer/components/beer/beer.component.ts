import { Component, OnInit } from '@angular/core';
import { BeersService } from 'src/app/services/beer.service';

@Component({
    selector: 'beer',
    templateUrl: './beer.component.html',
    styleUrls: ['./beer.component.scss']
})
export class BeerComponent implements OnInit {
    constructor(private beersService: BeersService) {}

    beer;
    isDataAvailable: boolean = false;

    fetchBeer(beerId) {
        this.beer = this.beersService.fetchBeer(beerId);
    }

    ngOnInit() {
        // TODO get beerID
        var beerId = "5dc8da9f0bc4f34070941710";
        this.fetchBeer(beerId);
    }
}
