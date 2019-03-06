import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './home/not-found.component';

//路由配置
const routes: Routes = [
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