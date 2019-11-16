import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
    form = new FormGroup({
        rating: new FormControl(2.3)
    });

    constructor() {}

    ngOnInit() {
        this.form.get('rating').valueChanges.subscribe(r => console.log(r));
    }
}
