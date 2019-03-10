import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutDefaultComponent } from './home/layout/default/default.component';
import { NotFoundComponent } from './home/not-found.component';
import { DashboardV1Component } from './home/dashboard/v1/v1.component';

//路由配置
const routes: Routes = [
    {
        path: '',
        component: LayoutDefaultComponent,
        //canActivate: [SimpleGuard],
        //canActivateChild: [SimpleGuard],
        children: [
            { path: '', redirectTo: 'dashboard/v1', pathMatch: 'full' },
            { path: 'dashboard', redirectTo: 'dashboard/v1', pathMatch: 'full' },
            { path: 'dashboard/v1', component: DashboardV1Component }
        ]
    },
    { path: '**', component: NotFoundComponent }
];

/**
 * 路由配置模块
 */
@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ]
})
export class AppRoutingModule { }