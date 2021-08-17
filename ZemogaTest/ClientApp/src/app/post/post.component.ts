import { Component, OnInit } from '@angular/core';
import { post } from '../models/post';
import { PostServiceService } from '../Services/post-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { comment } from '../models/comment';
import { approveReject } from '../models/approveReject';

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
  public isSameUser = false;
  public isPublished = true;
  public isPendingApproval = true;
  public isRejected = true;
  public comment = new comment();
  public decisionModel = new approveReject();

  constructor(protected _postService: PostServiceService,
      private activatedRoute: ActivatedRoute, private router: Router) {
    this.postId = this.activatedRoute.snapshot.paramMap.get('id');
    var logedUser = JSON.parse(localStorage.getItem('user'));
    this.role = logedUser.role;
    this.username = logedUser.username;
  }
  
  async ngOnInit() {
    this.comment.content = '';
    this.post = await this._postService.GetPostById(this.postId).toPromise();
    this.postStatus = this.post.status;
    this.isPublished = this.post.status == "Published";
    this.isPendingApproval = this.post.status == "PendingApproval";
    this.isRejected = this.post.status == "Rejected";
    this.isSameUser = this.post.authorUsername.toString() == this.username.toString();
    this.decisionModel.postId = this.post.postId;
  }

  async AddComment(){
    this.comment.postId = this.postId;
    this.comment.authorUsername = this.username;
    await this._postService.AddComment(this.comment).toPromise();
    window.location.reload();
  }

  async SendApproval(){
    await this._postService.SendForApproval(this.post).toPromise();
    this.router.navigate(['./myposts/']);
  }

  async Decision(decision: number){
    this.decisionModel.decision = decision;
    await this._postService.ApproveOrRejectPost(this.decisionModel).toPromise();
    this.router.navigate(['./pending-approval/']);
  }

  async Update(){
    await this._postService.EditPost(this.post).toPromise();
    window.location.reload();
  }
}
