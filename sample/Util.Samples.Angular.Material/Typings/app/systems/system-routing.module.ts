import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApplicationIndexComponent } from './application/application-index.component';
import { ApplicationEditComponent } from './application/application-edit.component';
import { ApplicationDetailComponent } from './application/application-detail.component';
import { RoleIndexComponent } from './role/role-index.component';
import { RoleEditComponent } from "./role/role-edit.component";
import { RoleDetailComponent } from './role/role-detail.component';
import { SaveGuard } from "../../util";

//路由配置
const routes: Routes = [
    {
        path: '',
        children: [
            {
                path: 'application', children: [
                    { path: '', component: ApplicationIndexComponent },
                    { path: 'create', component: ApplicationEditComponent, canDeactivate: [SaveGuard] },
                    { path: 'update/:id', component: ApplicationEditComponent, canDeactivate: [SaveGuard] },
                    { path: 'detail/:id', component: ApplicationDetailComponent }
                ]
            },
            {
                path: 'role', children: [
                    { path: '', component: RoleIndexComponent },
                    { path: 'create', component: RoleEditComponent, canDeactivate: [SaveGuard] },
                    { path: 'update/:id', component: RoleEditComponent, canDeactivate: [SaveGuard] },
                    { path: 'detail/:id', component: RoleDetailComponent }
                ]
            }
        ]
    }
];

/**
 * systems路由模块
 */
@NgModule({
    imports: [RouterModule.forChild(routes)]
})
export class SystemRoutingModule { }