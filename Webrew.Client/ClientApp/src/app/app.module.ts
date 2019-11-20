import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule, MatButtonModule, MatInputModule, MatCheckboxModule, MatSidenavModule } from '@angular/material';
import { NavBarModule } from './nav-bar/nav-bar.module';

@NgModule({
    declarations: [AppComponent],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot(
            [
                { path: 'home', loadChildren: () => import('./home/home.module').then(m => m.HomeModule) },
                { path: 'browse', loadChildren: () => import('./browse/browse.module').then(m => m.BrowseModule) },
                { path: 'new', loadChildren: () => import('./new/new.module').then(m => m.NewModule) },
                { path: 'chat', loadChildren: () => import('./chat/chat.module').then(m => m.ChatModule) },
                { path: 'about', loadChildren: () => import('./about/about.module').then(m => m.AboutModule) },
                {
                    path: 'userprofile',
                    loadChildren: () => import('./userprofile/userprofile.module').then(m => m.UserprofileModule)
                },
                { path: 'login', loadChildren: () => import('./login/login.module').then(m => m.LoginModule) },
                { path: 'beer', loadChildren: () => import('./beer/beer.module').then(m => m.BeerModule) },
                { path: '', redirectTo: 'home', pathMatch: 'full' },
                { path: '**', redirectTo: 'login' }
            ],
            { enableTracing: true }
        ),
        BrowserAnimationsModule,
        MatCardModule,
        MatButtonModule,
        MatInputModule,
        MatCheckboxModule,
        NavBarModule,
        MatSidenavModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {}
