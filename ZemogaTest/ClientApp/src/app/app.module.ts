import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoginComponent } from './login/login.component';
import { AuthGuardGuard } from './guard/auth-guard.guard';
import { PostComponent } from './post/post.component';
import { NewpostComponent } from './newpost/newpost.component';
import { MypostsComponent } from './myposts/myposts.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    PostComponent,
    NewpostComponent,
    MypostsComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuardGuard] },
      { path: 'login', component: LoginComponent },
      { path: 'post/:id', component: PostComponent, canActivate: [AuthGuardGuard] },
      { path: 'newpost', component: NewpostComponent, canActivate: [AuthGuardGuard] },
      { path: 'myposts', component: MypostsComponent, canActivate: [AuthGuardGuard] },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
