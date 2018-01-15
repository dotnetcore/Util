import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { DemoComponent } from "./demo.component";

//路由配置
const routes: Routes = [
    { path: '', component: DemoComponent }
];

/**
 * 路由配置模块
 */
@NgModule({
    imports: [RouterModule.forChild(routes)]
})
export class DemoRoutingModule { }