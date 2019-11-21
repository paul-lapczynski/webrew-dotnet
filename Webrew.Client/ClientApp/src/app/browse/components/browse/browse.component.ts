import { Component, OnInit } from '@angular/core';
import { BeersService } from 'src/app/services/beer.service';
import { Observable } from 'rxjs';
import { Beer } from 'src/app/shared/models/beer';

@Component({
    selector: 'browse',
    templateUrl: './browse.component.html',
    styleUrls: ['./browse.component.scss']
})
export class BrowseComponent implements OnInit {
    beers$: Observable<Beer[]>;
    
    constructor(private beersService: BeersService) {}    

    fetchBeers() {
        this.beers$ = this.beersService.fetchBeers();
    }

    ngOnInit() {
        this.fetchBeers();
    }
}
