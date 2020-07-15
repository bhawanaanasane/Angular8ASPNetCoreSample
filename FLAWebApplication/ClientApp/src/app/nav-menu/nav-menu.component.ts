import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserLogin } from '../../ViewModel/UserLogin';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  login: UserLogin;
  superadmin: boolean = false;
  admin: boolean = false;
  constructor(private _Route: Router) {

    if (localStorage.getItem('currentUser') != '' && localStorage.getItem('currentUser') != null) {
      this.login = JSON.parse(localStorage.getItem('currentUser'));
      if (this.login.parentId == 0 && this.login.clientId == 0) {
        this.superadmin = true;
        this.admin = false;
      }
      else {
        this.superadmin = false;
        this.admin = true;
      }
    }
    
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  Logout() {
   
    localStorage.clear();
    this._Route.navigate(['']);
  }
}

