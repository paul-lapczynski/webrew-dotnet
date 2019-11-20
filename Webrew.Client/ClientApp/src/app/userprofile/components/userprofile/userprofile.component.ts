import { Component, OnInit } from '@angular/core';
import { BeersService } from 'src/app/services/beer.service';

@Component({
    selector: 'userprofile',
    templateUrl: './userprofile.component.html',
    styleUrls: ['./userprofile.component.scss']
})
export class UserprofileComponent implements OnInit {
    constructor(private profileService: BeersService) {}

    profile;
    isDataAvailable: boolean = false;

    fetchProfile() {
        // TODO update service and get profile data
        // this.profile = this.profileService.fetchBeer(userId);
        var p = {"id":"userid123"};
        this.profile = p;
    }

    ngOnInit() {
        // TODO need chat service
        this.fetchProfile();
    }
}
