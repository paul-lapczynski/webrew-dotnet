import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChatComponent } from './components/chat/chat.component';
import { ChatRoutingModule } from './chat-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { BeersService } from "../services/beer.service";

@NgModule({
    declarations: [ChatComponent],
    imports: [CommonModule, ChatRoutingModule, HttpClientModule],
    providers: [BeersService]
})
export class ChatModule { }