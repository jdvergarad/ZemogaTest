import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { login } from '../models/login';
import { logedUser } from '../models/logedUser';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

const httpOption = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {
  errorMessage : string;
  constructor(protected http: HttpClient, @Inject('BASE_URL') protected baseUrl: string) {}

  public LoginUser(loginRequest : login) : Observable<logedUser> {
    console.log(this.baseUrl);
    return this.http.post<logedUser>(this.baseUrl + 'api/User/Login', loginRequest, httpOption)
    .pipe( catchError(
      (error: any) => {
        this.errorMessage = 'Login Error';
        alert(this.errorMessage);
        return Observable.throw(this.errorMessage);
      }));
  }
}
