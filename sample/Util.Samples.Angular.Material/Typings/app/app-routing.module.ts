import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './base/not-found.component';

//路由配置
const routes: Routes = [
    { path: 'systems', loadChildren: "./systems/system.module#SystemModule" },
    { path: '', redirectTo: '/systems/application', pathMatch: 'full' },
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