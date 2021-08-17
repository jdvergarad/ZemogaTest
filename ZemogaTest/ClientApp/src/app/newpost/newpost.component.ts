import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { post } from '../models/post';
import { PostServiceService } from '../Services/post-service.service';

@Component({
  selector: 'app-newpost',
  templateUrl: './newpost.component.html',
  styleUrls: ['./newpost.component.css']
})
export class NewpostComponent implements OnInit {

  public post = new post();
  public postId: string;
  public role: string;
  public username: string;

  constructor(protected _postService: PostServiceService,
                   private activatedRoute: ActivatedRoute, private router: Router) {
    this.postId = this.activatedRoute.snapshot.paramMap.get('id');
    var logedUser = JSON.parse(localStorage.getItem('user'));
    this.role = logedUser.role;
    this.username = logedUser.username;
  }
  
  ngOnInit() {
    this.post.authorUsername = this.username;
  }

  async Create() {

    if(this.post.title != undefined && this.post.content != undefined) {
        await this._postService.CreatePost(this.post).toPromise();
        this.router.navigate(['./myposts']);
    }
  }
}
