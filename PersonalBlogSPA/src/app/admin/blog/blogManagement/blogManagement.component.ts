import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/_models/post';
import { BlogService } from 'src/app/_services/blog.service';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-blogManagement',
  templateUrl: './blogManagement.component.html',
  styleUrls: ['./blogManagement.component.css']
})
export class BlogManagementComponent implements OnInit {
  posts: Post[];
  constructor(private blogService: BlogService , private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadAllPosts();
  }

  loadAllPosts() {
    this.blogService.getPosts().subscribe((posts: Post[]) => {
      this.posts = posts;
    }, error => {
      this.alertify.error(error);
    });
  }

}
