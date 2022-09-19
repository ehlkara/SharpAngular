import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginUser } from '../models/loginUser';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AlertifyService } from './alertify.service';
import { RegisterUser } from '../models/registerUser';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private alertifyService: AlertifyService
  ) { }

  path = "https://localhost:7073/api/Users/";
  userToken: any;
  decodedToken: any;
  jwtHelper = new JwtHelperService();
  TOKEN_KEY = "accessToken";

  login(loginUser: LoginUser) {
    this.httpClient.post(this.path + "login", loginUser).subscribe(data => {
      this.saveToken(data['accessToken']);
      this.userToken = data['accessToken'];
      this.decodedToken = this.jwtHelper.decodeToken(data['accessToken']);
      this.alertifyService.success("Login to system");
      this.router.navigateByUrl('/city');
    });
  }

  register(registerUser: RegisterUser) {
    this.httpClient.post(this.path + "register", registerUser).subscribe(data => {

    })
  }

  saveToken(token) {
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  logOut() {
    localStorage.removeItem(this.TOKEN_KEY);
    this.alertifyService.error("Logout to system");
  }

  loggedIn():boolean {
    // return tokenNotExpired(this.TOKEN_KEY);
    if(!this.TOKEN_KEY){
      return this.jwtHelper.isTokenExpired(this.TOKEN_KEY);
    }
    else {
      return !this.jwtHelper.isTokenExpired(this.TOKEN_KEY);
    }
  }

  get token() {
    return localStorage.getItem(this.TOKEN_KEY);
  }

  getCurrentUserId() {
    return this.jwtHelper.decodeToken(this.token).id;
  }

}
