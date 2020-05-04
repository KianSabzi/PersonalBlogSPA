import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Post } from '../_models/post';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
    })
};

@Injectable({
  providedIn: 'root'
})
export class BlogService {
  baseUrl = environment.apiUrl;
constructor(private http: HttpClient) { }

getPosts(): Observable<Post[]> {
  return this.http.get<Post[]>(this.baseUrl + 'admin/posts');
}

getPost(id): Observable<Post> {
  return this.http.get<Post>(this.baseUrl + 'admin/post/' + id);
}

createPost(post: Post) {
  return this.http.post(this.baseUrl + 'admin/newpost', post , httpOptions);
}
updatePost(id: number , post: Post) {
  return this.http.put(this.baseUrl + 'admin/updatepost/' + id , post , httpOptions);
}
}

