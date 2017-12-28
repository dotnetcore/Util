import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { SearchMenuComponent } from "./public/searchMenu";
import { DemoComponent} from "./demo/demo.component";

//路由配置
const routes: Routes = [
    { path: '', redirectTo: 'demo', pathMatch: 'full' },
    { path: 'demo', component: DemoComponent },
    { path: 'searchmenu', component: SearchMenuComponent },
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