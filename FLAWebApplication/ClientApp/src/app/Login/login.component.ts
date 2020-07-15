import { Component, OnInit, Injectable } from '@angular/core';
import { UserLogin } from '../../ViewModel/UserLogin';
import { Router } from '@angular/router';
import { LoginService } from '../../Services/LoginService';
import { first } from 'rxjs/operators';
import { AppComponent } from '../app.component';
import { ResponseModel } from '../../ViewModel/ResponseModel';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
@Injectable({ providedIn: 'root' })
export class LoginComponent implements OnInit {
  private _loginservice;
  constructor(private App:AppComponent, private loginservice: LoginService,private _Route: Router) {
    this._loginservice = loginservice;
  }
  
  LoginModel: UserLogin = new UserLogin();
  Response: ResponseModel = new ResponseModel();
 
  ngOnInit(): void {
    let UserDetail = localStorage.getItem('currentUser');
    if (UserDetail != "" && UserDetail != null) {
     
      this._Route.navigate(['/Admin/layout']);
    }
  }


  onSubmit() {
    try {
      this.App.Loading(true);
      this._loginservice.login(this.LoginModel).pipe(first())
        .subscribe(
          data => {
            this.LoginModel = data;
            if (this.LoginModel ==null) {
              this.App.ShowError("UserName or Password is Incorrect.. ");
            } else {
              this.App.ShowSuccess("Login Successfully..");
              this._Route.navigate(['/Admin/layout']);
            }
            
          },
          error => {
            this.App.ShowError("UserName or Password is Incorrect.. ");
            console.log("Login Fail");
          });


      this.App.Loading(false);
    }
    catch (Error)  {
      this.App.Loading(false);
    }
    
  }
}



