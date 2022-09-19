import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private authService: AuthService) { }

  loginUser: any = {}

  ngOnInit(): void {
  }

  login() {
    this.authService.login(this.loginUser);
  }

  logOut() {
    this.authService.logOut();
  }

  isAuthenticated() {
    return this.authService.loggedIn();
  }

}
