import { RouterModule, Route } from '@angular/router';
import { ChatComponent } from './components/chat/chat.component';
import { NgModule } from '@angular/core';

const routes: Route[] = [{ path: '', component: ChatComponent }];

@NgModule({
    imports: [RouterModule.forChild(routes)]
})
export class ChatRoutingModule {}
