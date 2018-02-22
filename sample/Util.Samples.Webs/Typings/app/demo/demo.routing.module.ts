import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { DemoComponent, A1, B1,C1,D1 } from "./demo.component";

//路由配置
const routes: Routes = [
    { path: '', component: DemoComponent, children: [{ path: 'a', component: A1 }, { path: 'b', component: B1 }, { path: 'c', component: C1 }, { path: 'd', component: D1 }] }
];

/**
 * 路由配置模块
 */
@NgModule({
    imports: [RouterModule.forChild(routes)]
})
export class DemoRoutingModule { }