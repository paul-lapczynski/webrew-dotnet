import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';
import { UserLogin } from '../models/user-login';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) {}

  createAccount(user: User) {
      return this.http.post<any>('/api/UserManagement/CreateAccount', user);
  }

  loginAccount(userLogin: UserLogin) {
    return this.http.post<any>('/api/UserManagement/Login', userLogin);
  }

}
