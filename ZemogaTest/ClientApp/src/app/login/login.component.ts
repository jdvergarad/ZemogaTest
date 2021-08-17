import { Component, OnInit } from '@angular/core';
import { login } from '../models/login';
import { LoginServiceService } from '../Services/login-service.service';
import { Router } from '@angular/router'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public loginUser = new login();
  constructor(protected _loginService: LoginServiceService, private router: Router) { }

  ngOnInit() {
  }

  async Login(){
    if (this.loginUser.Username != undefined && this.loginUser.Password != undefined) {
      var token = await this._loginService.LoginUser(this.loginUser).toPromise();
      console.log(token);
      if (token.token != undefined) {
        localStorage.setItem('user', JSON.stringify(token));
        this.router.navigate(['./']);
      }
    }
  }

}
