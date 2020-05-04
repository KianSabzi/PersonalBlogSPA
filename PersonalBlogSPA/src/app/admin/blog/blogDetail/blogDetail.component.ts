import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/_models/post';
import { BlogService } from 'src/app/_services/blog.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-blogDetail',
  templateUrl: './blogDetail.component.html',
  styleUrls: ['./blogDetail.component.css']
})
export class BlogDetailComponent implements OnInit {
  post: Post;
  constructor(private blogService: BlogService, private alertify: AlertifyService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.loadPost();
  }

  loadPost() {
    this.blogService.getPost(this.route.snapshot.params['id']).subscribe((post: Post) => {
      this.post = post;
    }, error => {
      this.alertify.error(error);
    });
  }

}
