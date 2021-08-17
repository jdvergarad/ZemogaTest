import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { postsList } from '../models/postsList';
import { PostServiceService } from '../Services/post-service.service';

@Component({
  selector: 'app-pending-approval',
  templateUrl: './pending-approval.component.html',
  styleUrls: ['./pending-approval.component.css']
})
export class PendingApprovalComponent implements OnInit {

  public logedUsername : string;
  public posts: Observable<postsList>;
  public postToShow: postsList;

  constructor(protected _postService: PostServiceService, private router: Router) {
    this.logedUsername = JSON.parse(localStorage.getItem('user')).username
  }

  ngOnInit() {
    if (JSON.parse(localStorage.getItem('user')) != null) {
      this.GetPostsPendingApproval();
    }
  }
  async GetPostsPendingApproval(){
    this.postToShow = await this._postService.GetAllPendingApproval().toPromise();
  }

  Open(postId : string){
    this.router.navigate(['./post/' + postId]);
  }
}
