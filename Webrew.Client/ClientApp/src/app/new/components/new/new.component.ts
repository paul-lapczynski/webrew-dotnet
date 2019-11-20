import { Component, OnInit } from '@angular/core';
import { BeersService } from 'src/app/services/beer.service';

@Component({
    selector: 'new',
    templateUrl: './new.component.html',
    styleUrls: ['./new.component.scss']
})
export class NewComponent implements OnInit {
    constructor(private beersService: BeersService) {}

    beer$;
    isDataAvailable: boolean = false;

    addBeer() {
        // TODO get beer data from page and update beer service
        var beerId = "5dc8da9f0bc4f34070941710";
        this.beer$ = this.beersService.fetchBeer(beerId);
    }

    ngOnInit() {
    }
}
