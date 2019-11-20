import { Component, OnInit } from '@angular/core';
import { BeersService } from 'src/app/services/beer.service';

@Component({
    selector: 'chat',
    templateUrl: './chat.component.html',
    styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {
    constructor(private chatService: BeersService) {}

    chats$;
    isDataAvailable: boolean = false;

    fetchBeers() {
        this.chats$ = this.chatService.fetchBeers();
    }

    ngOnInit() {
        // TODO need chat service
        this.fetchBeers();
    }
}
