import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';
import { postsList } from '../models/postsList';

var httpOption = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'Bearer ' + JSON.parse(localStorage.getItem('user')).token
  })
};

@Injectable({
  providedIn: 'root'
})
export class PostServiceService {
  errorMessage: string;
  constructor(protected http: HttpClient, @Inject('BASE_URL') protected baseUrl: string) {
  }

  public GetAllPublishedPosts(): Observable<postsList> {
    return this.http.get<postsList>(this.baseUrl + 'api/Post/GetAllPublisedPost', httpOption)
    .pipe( catchError(
      (error: any) => {
        if (error.status === 404) {
          this.errorMessage = 'Employees Not Found';
        } else {
          this.errorMessage = 'Unknown error';
        }
        alert(this.errorMessage);
        return Observable.throw(this.errorMessage);
      }));
  }
}
