import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginUser } from '../models/loginUser';
import { JwtHelper } from 'angular2-jwt';
import { Router } from '@angular/router';
import { AlertifyService } from './alertify.service';

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
  jwtHelper: JwtHelper = new JwtHelper();

  login(loginUser: LoginUser) {
    let headers = new HttpHeaders();
    headers = headers.append("Content-Type", "application/json");
    this.httpClient.post(this.path + "login", loginUser, { headers: headers }).subscribe(data => {
      this.saveToken(data['accessToken']);
      this.userToken = data['accessToken'];
      this.decodedToken = this.jwtHelper.decodeToken(data['accessToken']);
      this.alertifyService.success("Login to system")
      this.router.navigateByUrl('/city');
    });
  }

  saveToken(token) {
    localStorage.setItem('token', token);
  }
}
