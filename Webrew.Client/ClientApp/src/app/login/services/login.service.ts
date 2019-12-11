import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';
import { UserLogin } from '../models/user-login';

@Injectable({
    providedIn: 'root'
})
export class LoginService {
    constructor(private http: HttpClient, @Inject('API_BASE_URL') private baseUrl: string) {}

    createAccount(user: User) {
        return this.http.post<any>(this.baseUrl + 'UserManagement/CreateAccount', user);
    }

    loginAccount(userLogin: UserLogin) {
        return this.http.post<any>(this.baseUrl + 'UserManagement/Login', userLogin);
    }
}
