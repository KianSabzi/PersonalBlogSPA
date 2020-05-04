import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Post } from 'src/app/_models/post';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { BlogService } from 'src/app/_services/blog.service';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-blogEdit',
  templateUrl: './blogEdit.component.html',
  styleUrls: ['./blogEdit.component.css']
})
export class BlogEditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  post: Post = {} as Post;
  constructor(private route: ActivatedRoute, private alertify: AlertifyService,
    private blogService: BlogService) { }

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

  updatePost() {
     this.blogService.updatePost(this.route.snapshot.params['id'], this.post).subscribe(next => {
       this.alertify.success('مقاله با موفقیت بروز رسانی گردید');
       this.editForm.resetForm(this.post);
     }, error => {
        this.alertify.error(error);
     });

  }

}
