import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';
import { postsList } from '../models/postsList';
import { PostServiceService } from '../Services/post-service.service';

@Component({
  selector: 'app-myposts',
  templateUrl: './myposts.component.html',
  styleUrls: ['./myposts.component.css']
})
export class MypostsComponent implements OnInit {

  public logedUsername : string;
  public posts: Observable<postsList>;
  public postToShow: postsList;

  constructor(protected _postService: PostServiceService, private router: Router) {
    this.logedUsername = JSON.parse(localStorage.getItem('user')).username
  }

  ngOnInit() {
    if (JSON.parse(localStorage.getItem('user')) != null) {
      this.GetMyPosts();
    }
  }
  async GetMyPosts(){
    this.postToShow = await this._postService.GetPostsByWriterId(this.logedUsername).toPromise();
  }

  Open(postId : string){
    this.router.navigate(['./post/' + postId]);
  }
}
