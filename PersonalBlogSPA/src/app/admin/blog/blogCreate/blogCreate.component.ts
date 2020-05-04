import { Component, OnInit, ViewChild } from '@angular/core';
import { Post } from 'src/app/_models/post';
import { Tag } from 'src/app/_models/tag';
import { BlogService } from 'src/app/_services/blog.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { NgForm } from '@angular/forms';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-blogCreate',
  templateUrl: './blogCreate.component.html',
  styleUrls: ['./blogCreate.component.css']
})
export class BlogCreateComponent implements OnInit {
  @ViewChild('createForm') createForm: NgForm;
  post: Post = {} as Post;
  tags: Tag[];

  constructor(private blogService: BlogService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  createPost() {
    this.blogService.createPost(this.post).subscribe(next => {
      this.alertify.success('مقاله جدید با موفقیت ثبت گردید');
      this.createForm.reset(this.post);
    }, error => {
      this.alertify.error(error);
      console.log(error);
    });
  }

}
