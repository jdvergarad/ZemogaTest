import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { PostServiceService } from '../Services/post-service.service';
import { postsList } from '../models/postsList';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public logedUsername : string;
  public posts: Observable<postsList>;
  public postToShow: postsList;

  constructor(protected _postService: PostServiceService, private router: Router) {
    this.logedUsername = JSON.parse(localStorage.getItem('user')).username
  }

  ngOnInit() {
    if (JSON.parse(localStorage.getItem('user')) != null) {
      this.GetPublishedPost();
    }
  }
  async GetPublishedPost(){
    this.postToShow = await this._postService.GetAllPublishedPosts().toPromise();
  }

  Open(postId : string){
    this.router.navigate(['./post/' + postId]);
  }
}
