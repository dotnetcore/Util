import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'

//路由配置
const routes: Routes = [
    { path: '', redirectTo: 'demo', pathMatch: 'full' },
    { path: 'demo', loadChildren: "./demo/demo.module#DemoModule" },
    { path: '**', redirectTo: '/' }
];

/**
 * 路由配置模块
 */
@NgModule({
    imports: [RouterModule.forRoot(routes)]
})
export class AppRoutingModule { }