import { Injectable } from '@angular/core';
import { User } from '../login/user';

@Injectable()
export class AccountService {

  constructor() { }

  loggedIn = false;

  login(user: User): boolean {
    if (user.userName == "ehlullah" && user.password == "12345") {
      return true;
      this.loggedIn = true;
      localStorage.setItem("isLogged", user.userName);
    }
    return false;
  }

  isLoggedIn() {
    return this.loggedIn;
  }

  logOut() {
    localStorage.removeItem("isLogged");
    this.loggedIn = false;
  }
}
