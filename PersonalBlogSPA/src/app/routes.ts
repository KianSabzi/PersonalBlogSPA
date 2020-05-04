import {Routes} from '@angular/router';
import { LoginComponent} from './login/login.component';
import { BlogManagementComponent } from './admin/blog/blogManagement/blogManagement.component';
import { ProjectManagementComponent } from './projectManagement/projectManagement.component';
import { AuthGuard } from './_guards/auth.guard';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { BlogDetailComponent } from './admin/blog/blogDetail/blogDetail.component';
import { BlogEditComponent } from './admin/blog/blogEdit/blogEdit.component';
import { BlogCreateComponent } from './admin/blog/blogCreate/blogCreate.component';
import { FileManagerComponent } from './admin/file-manager/file-manager.component';

export const appRoutes: Routes = [
    { path: '', component: LoginComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'admin/admin-panel', component: AdminPanelComponent },
            { path: 'admin/file-manager', component: FileManagerComponent },
            { path: 'admin/blog/blogManagement', component: BlogManagementComponent },
            { path: 'admin/blog/blogDetail/:id', component: BlogDetailComponent },
            { path: 'admin/blog/blogCreate', component: BlogCreateComponent },
            { path: 'admin/blog/blogEdit/:id', component: BlogEditComponent },
            { path: 'projectManagement', component: ProjectManagementComponent}
        ]
    },
    { path: '**', redirectTo: '' , pathMatch: 'full' }

];
