import { Component, OnInit } from '@angular/core';
import { BeersService } from 'src/app/services/beer.service';

@Component({
    selector: 'browse',
    templateUrl: './browse.component.html',
    styleUrls: ['./browse.component.scss']
})
export class BrowseComponent implements OnInit {
    constructor(private beersService: BeersService) {}

    beers$;
    isDataAvailable: boolean = false;

    fetchBeers() {
        this.beers$ = this.beersService.fetchBeers();
    }

    ngOnInit() {
        this.fetchBeers();
    }
}
