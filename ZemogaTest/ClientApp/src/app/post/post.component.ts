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
  public post = new post();
  public postId: string;
  public role: string;
  public username: string;
  public postStatus = '';
  public decisionMessage = '';
  public canEdit = false;
  public comment = new comment();

  constructor(protected _postService: PostServiceService, private activatedRoute: ActivatedRoute) {
    this.postId = this.activatedRoute.snapshot.paramMap.get('id');
    var logedUser = JSON.parse(localStorage.getItem('user'));
    this.role = logedUser.role;
    this.username = logedUser.username;
  }
  
  async ngOnInit() {
    this.comment.content = '';
    this.post = await this._postService.GetPostById(this.postId).toPromise();
    this.postStatus = this.post.status;

    if(this.post.authorUsername.toString() == this.username.toString()
        && this.post.status != "Published") {
      this.canEdit = true;
    }
  }

  async AddComment(){
    this.comment.postId = this.postId;
    this.comment.authorUsername = this.username;
    await this._postService.AddComment(this.comment).toPromise();
    window.location.reload();
  }
}
