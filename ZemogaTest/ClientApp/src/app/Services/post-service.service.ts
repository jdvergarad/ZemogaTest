import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';
import { postsList } from '../models/postsList';
import { post } from '../models/post';
import { comment } from '../models/comment';

@Injectable({
  providedIn: 'root'
})
export class PostServiceService {
  errorMessage: string;
  constructor(protected http: HttpClient, @Inject('BASE_URL') protected baseUrl: string) {
  }

  public GetAllPublishedPosts(): Observable<postsList> {
    var httpOption = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + JSON.parse(localStorage.getItem('user')).token
      })
    };

    return this.http.get<postsList>(this.baseUrl + 'api/Post/GetAllPublisedPost', httpOption)
    .pipe( catchError(
      (error: any) => {
        this.errorMessage = 'Getting all posts error';
        alert(this.errorMessage);
        return Observable.throw(this.errorMessage);
      }));
  }

  public GetPostById(postId: string): Observable<post> {
    
    var httpOption = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + JSON.parse(localStorage.getItem('user')).token
      })
    };

    return this.http.get<post>(this.baseUrl + 'api/Post/GetPostById/'+ postId, httpOption)
    .pipe( catchError(
      (error: any) => {
        this.errorMessage = 'Getting post error';
        alert(this.errorMessage);
        return Observable.throw(this.errorMessage);
      }));
  }

  public AddComment(comment: comment): Observable<post> {
    
    var httpOption = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + JSON.parse(localStorage.getItem('user')).token
      })
    };

    return this.http.post<post>(this.baseUrl + 'api/Post/AddComment', comment, httpOption)
    .pipe( catchError(
      (error: any) => {
        this.errorMessage = 'Adding comment to post error';
        alert(this.errorMessage);
        return Observable.throw(this.errorMessage);
      }));
  }
}
