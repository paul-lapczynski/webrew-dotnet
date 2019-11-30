import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './components/login/login.component';
import { LoginRoutingModule } from './login-routing.module';
import { CreateAccountComponent } from './components/create-account/create-account.component';
import { MatFormFieldModule, MatInputModule, MatCardModule, MatButtonModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { LoginService } from './services/login.service';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@NgModule({
    declarations: [LoginComponent, CreateAccountComponent],
    imports: [CommonModule, LoginRoutingModule, MatFormFieldModule, MatInputModule, FlexLayoutModule, MatCardModule, MatButtonModule, HttpClientModule, ReactiveFormsModule, RouterModule],
    providers: [LoginService]
})
export class LoginModule { }