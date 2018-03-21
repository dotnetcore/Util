import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApplicationIndexComponent } from './application/application-index.component';
import { ApplicationEditComponent } from './application/application-edit.component';
import { ApplicationDetailComponent } from './application/application-detail.component';

//路由配置
const routes: Routes = [
    {
        path: '',
        children: [
            {
                path: 'application', children: [
                    { path: '', component: ApplicationIndexComponent },
                    { path: 'create', component: ApplicationEditComponent },
                    { path: 'edit/:id', component: ApplicationEditComponent },
                    { path: 'detail/:id', component: ApplicationDetailComponent }
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