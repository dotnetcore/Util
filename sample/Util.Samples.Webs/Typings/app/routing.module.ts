import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'

//路由配置
const routes: Routes = [
    //{ path: '', redirectTo: '', pathMatch: 'full' },
    { path: '**', redirectTo: '/' }
];

/**
 * 路由配置模块
 */
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class RoutingModule { }