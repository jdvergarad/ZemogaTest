import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { login } from '../models/login';
import { loginResponse } from '../models/loginResponse';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

const httpOption = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'my-auth_token'
  })
};

@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {
  errorMessage : string;
  constructor(protected http: HttpClient, @Inject('BASE_URL') protected baseUrl: string) {}

  public LoginUser(loginRequest : login) : Observable<loginResponse> {

    return this.http.post<loginResponse>('http://localhost:35296/api/User/Login', loginRequest, httpOption)
    .pipe( catchError(
      (error: any) => {
        this.errorMessage = 'Login Error';
        alert(this.errorMessage);
        return Observable.throw(new loginResponse());
      }));
  }
}
