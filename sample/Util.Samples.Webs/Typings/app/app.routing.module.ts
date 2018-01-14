import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { SearchMenuComponent } from "./public/searchMenu";

//路由配置
const routes: Routes = [
    { path: '', redirectTo: 'demo', pathMatch: 'full' },
    { path: 'searchmenu', component: SearchMenuComponent },
    { path: 'demo', loadChildren: "./demo/demo.module#DemoModule" },
    { path: '**', redirectTo: '/' }
];

/**
 * 路由配置模块
 */
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }