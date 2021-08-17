import { Component, OnInit } from '@angular/core';
import { post } from '../models/post';
import { PostServiceService } from '../Services/post-service.service';
import { ActivatedRoute } from '@angular/router';
import { comment } from '../models/comment';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
  public post: post;
  public postId: string;
  public role: string;
  public username: string;
  public comment = new comment();

  constructor(protected _postService: PostServiceService, private activatedRoute: ActivatedRoute) {
    this.postId = this.activatedRoute.snapshot.paramMap.get('id');
    this.role = JSON.parse(localStorage.getItem('user')).role;
    this.username = JSON.parse(localStorage.getItem('user')).username;
    this.comment.content = '';
  }

  ngOnInit() {
    this.GetPost(this.postId);
  }

  async GetPost(postId: string){
    this.post = await this._postService.GetPostById(postId).toPromise();
    console.log(this.post);
  }

  async AddComment(){
    this.comment.postId = this.postId;
    this.comment.authorUsername = this.username;

    var postCommented = await this._postService.AddComment(this.comment).toPromise();

    console.log(postCommented);
    window.location.reload();
  }
}
