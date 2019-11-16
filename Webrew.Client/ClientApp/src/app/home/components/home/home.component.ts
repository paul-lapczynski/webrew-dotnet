import { Component, OnInit } from '@angular/core';
import { BeersService } from 'src/app/services/beer.service';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
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
