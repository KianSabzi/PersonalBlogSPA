import { Component, OnInit, Input } from '@angular/core';
import { Post } from 'src/app/_models/post';

@Component({
  selector: 'app-blogList',
  templateUrl: './blogList.component.html',
  styleUrls: ['./blogList.component.css']
})
export class BlogListComponent implements OnInit {
  @Input() post: Post;
  constructor() { }

  ngOnInit() {
  }

}
