import {Injectable} from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Post } from '../_models/post';
import {BlogService} from '../_services/blog.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';


@Injectable()
export class PostDetailResolver implements Resolve<Post> {
    constructor(private blogService: BlogService, private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Post> {
        const id = route.params['id'];
        if (isNaN(id)) {
            this.alertify.error('شماره مقاله بصورت عددی نمی باشد');
            this.router.navigate(['/blog/blogManagement']);
            return of(null);
        }
        return this.blogService.getPost(route.params['id']).pipe(
            catchError(error => {
                this.alertify.error('Problem Retrieving Data');
                this.router.navigate(['/blog/blogManagement']);
                return of(null);
            })
        );
        }
}
