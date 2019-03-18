import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutDefaultComponent } from './home/layout/default/default.component';
import { DashboardV1Component } from './home/dashboard/v1.component';

//路由配置
const routes: Routes = [
    {
        path: '',
        component: LayoutDefaultComponent,
        children: [
            { path: '', redirectTo: 'dashboard/v1', pathMatch: 'full' },
            { path: 'dashboard', redirectTo: 'dashboard/v1', pathMatch: 'full' },
            { path: 'dashboard/v1', component: DashboardV1Component },
            { path: 'demo', loadChildren: "./demo/demo.module#DemoModule" },
            { path: 'component', loadChildren: "./components/component.module#ComponentModule" }
        ]
    }
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