import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};

  constructor(private authService: AuthService , private alertify: AlertifyService,
    private router: Router) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('ورود موفقیت آمیز');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.router.navigate(['/admin/admin-panel']);
    });

  }

  // loggedIn() {
  //   return this.authService.loggedIn();
  // }

  // public onLoginClick() {
  //   this.router.navigate(['./home']);
  // }

}
