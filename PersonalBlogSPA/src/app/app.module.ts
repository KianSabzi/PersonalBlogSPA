import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule , ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule, TabsModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { CKEditorModule } from 'ckeditor4-angular';
import { TagInputModule } from 'ngx-chips';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // this is needed!
import { FileManagerModule, NavigationPaneService, ToolbarService, DetailsViewService } from '@syncfusion/ej2-angular-filemanager';

import { AppComponent } from './app.component';
import { WeatherComponent } from './weather/weather.component';
import { NavComponent } from './nav/nav.component';
import { LoginComponent } from './login/login.component';
import { HeaderComponent } from './header/header.component';
import { AuthService } from './_services/auth.service';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { AlertifyService } from './_services/alertify.service';
import { HomeComponent } from './home/home.component';
import { BlogManagementComponent } from './admin/blog/blogManagement/blogManagement.component';
import { ProjectManagementComponent } from './projectManagement/projectManagement.component';
import { appRoutes } from './routes';
import { AuthGuard } from './_guards/auth.guard';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { BlogListComponent } from './admin/blog/blogList/blogList.component';
import { FooterComponent } from './footer/footer.component';
import { BlogService } from './_services/blog.service';
import { PostDetailResolver } from './_resolvers/post-detail.resolver';
import { BlogEditComponent } from './admin/blog/blogEdit/blogEdit.component';
import { BlogCreateComponent } from './admin/blog/blogCreate/blogCreate.component';
import { BlogDetailComponent } from './admin/blog/blogDetail/blogDetail.component';
import { FileManagerComponent } from './admin/file-manager/file-manager.component';


export function tokenGetter() {
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      WeatherComponent,
      HeaderComponent,
      NavComponent,
      FooterComponent,
      LoginComponent,
      HomeComponent,
      BlogManagementComponent,
      ProjectManagementComponent,
      AdminPanelComponent,
      BlogListComponent,
      BlogEditComponent,
      BlogCreateComponent,
      BlogDetailComponent,
      FileManagerComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      TagInputModule,
      BrowserAnimationsModule,
      BsDropdownModule.forRoot(),
      TabsModule.forRoot(),
      CKEditorModule,
      RouterModule.forRoot(appRoutes),
      JwtModule.forRoot({
         config: {
            tokenGetter: tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/auth']
         }
      }),
      FileManagerModule
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AlertifyService,
      AuthGuard,
      BlogService,
      PostDetailResolver,
      NavigationPaneService,
      ToolbarService,
      DetailsViewService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
